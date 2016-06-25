using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCreatorGenetic
{
	public partial class ImageCreator : Form
	{
		private const int THREADS = 6;
		private const int percentElite = 2; //on garde 5% des meilleurs

		public ImageCreator()
		{
			InitializeComponent();
			GeneticFunctions.ELITEPERCENT = percentElite;
			GeneticFunctions.MUTATIONS_COUNT = 1;
		}
        DirectoryInfo saveDir;
		public void startGeneration(object sender, System.EventArgs e)
		{
            ImageCharCreator.DrawingMode = radioButton1.Checked ? DrawMode.Circles : DrawMode.Characters;
            GeneticFunctions.DrawingMode = radioButton1.Checked ? DrawMode.Circles : DrawMode.Characters;

            GeneticFunctions.MAX_FONT_SIZE = (int)(Math.Max(10, imageOriginale.Image.Height / 10));
            Console.WriteLine("Max font size = " + GeneticFunctions.MAX_FONT_SIZE);

            GeneticFunctions.MUTATIONS_COUNT = (int)updownNbChar.Value/500;
            String dirName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
            saveDir = Directory.CreateDirectory(dirName);
             
			progressBar.Value = 0;
			progressBar.Maximum = (int)updownNbGenerations.Value;
			progressBarFitness.Value = 0;
			progressBarFitness.Maximum = (int)updownNbPopulation.Value;
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += (s, a) => {
                Stopwatch swComputeFitness = new Stopwatch();
                Stopwatch swCreateGeneration = new Stopwatch();

                LockBitmap lockOrig = new LockBitmap(new Bitmap(imageOriginale.Image));
                lockOrig.LockBits();
                //On crée le pool de départ
                List<ImageCharCreator> pool = new List<ImageCharCreator>();
				for (int individu = 0; individu < updownNbPopulation.Value; individu++)
				{
					ImageCharCreator icc = new ImageCharCreator(imageOriginale.Image.Width, imageOriginale.Image.Height);

					for (int i = 0; i < updownNbChar.Value; i++)
					{
						icc.caracteres.Add(GeneticFunctions.GetRandomChar(icc.width, icc.height));
					}
					pool.Add(icc);
				}
				for (int generation = 0; generation < updownNbGenerations.Value; generation++)
                {
                    //On calcule le score de chaque individu du pool
                    swComputeFitness.Restart();
                    progressBarFitness.Invoke(new Action(() => progressBarFitness.Value = 0));
                    GeneticFunctions.ComputeFitness(lockOrig, pool, THREADS, progressBarFitness);
                    swComputeFitness.Stop();
                    Console.WriteLine("Temps de calcul de fitness : " + swComputeFitness.ElapsedMilliseconds + "ms");
                    //On affiche la meilleure image
                    pool = pool.OrderByDescending(c => c.FitnessScore).ToList();
                    Best = pool[0].FitnessScore;
                    this.labelFitness.Invoke(new Action(() =>
                    {
                        this.imageCalculee.Image = pool[0].Image;
                        this.labelFitness.Text =
                            "Generation n° " + generation
                            + "\r\nAvg : " + pool.Average(c => c.FitnessScore).ToString("00.00") + "%"
                            + "\r\nBest : " + Best.ToString("00.00") + "%";

                        if (generation % 20 == 0)
                        {
                            imageCalculee.Image.Save(saveDir.FullName + "\\generation_" + generation.ToString("0000") + ".jpg");
                        }
                    }));
                    //On crée une nouvelle génération
                    pool = GeneticFunctions.CreateNewGeneration(pool);
                    progressBar.Invoke(new Action(() => progressBar.Value++));
                }
                lockOrig.UnlockBits();
			};
            bw.RunWorkerCompleted+=(a,b) =>
            {
                boutonStart.Enabled = true;
            };
            boutonStart.Enabled = false;
            bw.RunWorkerAsync();
		}

        
        private double best=0;
		public double Best
		{
			get{
				return best;
			}
			set{
				if (value != best)
				{
					GeneticFunctions.MUTATIONS_COUNT = 1;
					best = value;
				}
				else
				{
					//GeneticFunctions.MUTATIONS_COUNT++;
					//Console.WriteLine("Mutations : " + GeneticFunctions.MUTATIONS_COUNT);
				}
			}
		}


		public void loadImageOriginale(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					imageOriginale.Image = new Bitmap(ofd.FileName);
                    boutonStart.Enabled = true;
                    
				}
				catch(Exception ex)
				{
                    boutonStart.Enabled = false;
                    MessageBox.Show("Impossible de charger l'image : " + ex.Message, "Echec du chargement de l'image");
				}
			}
		}
	}
}

