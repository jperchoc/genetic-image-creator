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
        private List<ImageCharCreator> pool = new List<ImageCharCreator>();
        private const int THREADS = 8;
		private const int percentElite = 2; //on garde 5% des meilleurs
        int gen = 0;

		public ImageCreator()
		{
			InitializeComponent();
			GeneticFunctions.ELITEPERCENT = percentElite;
			GeneticFunctions.MUTATIONS_COUNT = 1;


            bw.WorkerSupportsCancellation = true;
            bw.DoWork += (s, a) =>
            {
                progressBar.Invoke(new Action(() => progressBar.Value = 0));
                progressBar.Invoke(new Action(() => progressBar.Maximum = (int)updownNbGenerations.Value));


                Stopwatch swComputeFitness = new Stopwatch();

                LockBitmap lockOrig = new LockBitmap(new Bitmap(imageOriginale.Image));
                lockOrig.LockBits();

                for (int generation = 0; generation < updownNbGenerations.Value; generation++)
                {
                    gen++;
                    if (bw.CancellationPending)
                    {
                        progressBar.Invoke(new Action(() => progressBar.Value++));
                        break;
                    }
                    //On calcule le score de chaque individu du pool
                    swComputeFitness.Restart();
                    progressBarFitness.Invoke(new Action(() => progressBarFitness.Value = 0));
                    GeneticFunctions.ComputeFitness(lockOrig, pool, THREADS, progressBarFitness);
                    swComputeFitness.Stop();
                    //Console.WriteLine("Temps de calcul de fitness : " + swComputeFitness.ElapsedMilliseconds + "ms");
                    //On affiche la meilleure image
                    pool = pool.OrderByDescending(c => c.FitnessScore).ToList();
                    Best = pool[0].FitnessScore;
                    this.labelFitness.Invoke(new Action(() =>
                    {
                        if (this.imageCalculee.Image != null)
                            this.imageCalculee.Image.Dispose();
                        this.imageCalculee.Image = new Bitmap(pool[0].Image);
                        this.labelFitness.Text =
                            "Generation n° " + gen
                            + "\r\nAvg : " + pool.Average(c => c.FitnessScore).ToString("00.00") + "%"
                            + "\r\nBest : " + Best.ToString("00.00") + "%";

                        if (generation % 20 == 0)
                        {
                            this.imageCalculee.Image.Save(saveDir.FullName + "/generation_" + gen.ToString("0000") + ".png");
                        }
                    }));
                    //On crée une nouvelle génération
                    GeneticFunctions.CreateNewGeneration(ref pool);
                    progressBar.Invoke(new Action(() => progressBar.Value++));
                    GC.Collect();
                }
                lockOrig.UnlockBits();
            };
            bw.RunWorkerCompleted += (a, b) =>
            {
                if (b.Error != null)
                {
                    MessageBox.Show(b.Error.Message + Environment.NewLine + b.Error.StackTrace);
                }
                //boutonStart.Enabled = true;
                this.button1.Enabled = true;
                this.boutonStart.Text = "Continue";
            };
        }
        DirectoryInfo saveDir=null;
		public void btn_startClick(object sender, System.EventArgs e)
        {
            if (this.boutonStart.Text == "Start")
            {
                //Create new generation and iterate
                this.boutonStart.Text = "Stop";
                StartNewGeneration();
                Iterate();
            }
            else if(this.boutonStart.Text=="Resume" || this.boutonStart.Text == "Continue")
            {
                //Resume iterations
                Iterate();
                this.boutonStart.Text = "Stop";
            }
            else
            {
                //Pause iteration
                bw.CancelAsync();
                this.boutonStart.Text = "Resume";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //clean generation
            this.button1.Enabled = false;
            this.boutonStart.Text = "Start";
        }

        private void StartNewGeneration()
        {
            gen = 0;
            if (radioButton1.Checked)
                ImageCharCreator.DrawingMode = DrawMode.Circles;
            else if (radioButton2.Checked)
                ImageCharCreator.DrawingMode = DrawMode.Characters;
            else if (radioButton3.Checked)
                ImageCharCreator.DrawingMode = DrawMode.Elipse;
            else if (radioButton4.Checked)
                ImageCharCreator.DrawingMode = DrawMode.Triangle;

            GeneticFunctions.MAX_FONT_SIZE = (int)(Math.Max(10, imageOriginale.Image.Height / 10));

            GeneticFunctions.MUTATIONS_COUNT = (int)updownNbChar.Value / 500;
            String dirName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
            FileInfo root = new FileInfo(Application.ExecutablePath);
            saveDir = Directory.Exists(root.Directory.FullName + "/" + dirName) ?
                new DirectoryInfo(root.Directory.FullName + "/" + dirName)
                :
                Directory.CreateDirectory(root.Directory.FullName + "/" + dirName);

            //On crée le pool de départ
            this.pool = new List<ImageCharCreator>();
            for (int individu = 0; individu < updownNbPopulation.Value; individu++)
            {
                ImageCharCreator icc = new ImageCharCreator(imageOriginale.Image.Width, imageOriginale.Image.Height);
                for (int i = 0; i < updownNbChar.Value; i++)
                {
                    icc.caracteres.Add(GeneticFunctions.GetRandomChar(icc.width, icc.height));
                }
                pool.Add(icc);
            }

            progressBar.Value = 0;
            progressBar.Maximum = (int)updownNbGenerations.Value;
            progressBarFitness.Value = 0;
            progressBarFitness.Maximum = (int)updownNbPopulation.Value;
            
        }
        BackgroundWorker bw = new BackgroundWorker();
        private void Iterate()
        {
            this.button1.Enabled = false;
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
					Bitmap img = new Bitmap(ofd.FileName);
					imageOriginale.Image = new Bitmap(ofd.FileName);
                    boutonStart.Enabled = true;
					ImageCharCreator.BackColor = CalculateAverageColor(img);
                    button2.BackColor = ImageCharCreator.BackColor;

                }
				catch(Exception ex)
				{
                    boutonStart.Enabled = false;
                    MessageBox.Show("Impossible de charger l'image : " + ex.Message, "Echec du chargement de l'image");
				}
			}
		}
		private System.Drawing.Color CalculateAverageColor(Bitmap bm)
		{
			LockBitmap lockbm = new LockBitmap(bm);
			lockbm.LockBits();
			long red=0, green=0, blue=0;
			int minDiversion = 15;
			int dropped = 0;
			for (int i = 0; i < bm.Width; i++)
			{
				for (int j = 0; j < bm.Height; j++)
				{
					Color c = lockbm.GetPixel(i, j);
					if (Math.Abs(c.R - c.G) > minDiversion || Math.Abs(c.R - c.B) > minDiversion || Math.Abs(c.G - c.B) > minDiversion)
					{
						red += c.R;
						green += c.G;
						blue += c.B;
					}
					else
					{
						dropped++;
					}
				}
			}
			long cnt = bm.Width * bm.Height - dropped;;
			return Color.FromArgb((int)(red / cnt), (int)(green / cnt), (int)(blue / cnt));
		}

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                ImageCharCreator.BackColor = cd.Color;
                button2.BackColor = cd.Color;
            }
        }
    }
}

