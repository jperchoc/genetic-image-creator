using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
		public void startGeneration(object sender, System.EventArgs e)
		{
			progressBar.Value = 0;
			progressBar.Maximum = (int)updownNbGenerations.Value;
			progressBarFitness.Value = 0;
			progressBarFitness.Maximum = (int)updownNbPopulation.Value;
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += (s, a) => {
				LockBitmap lockOrig = new LockBitmap(new Bitmap(imageOriginale.Image));
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
					_EventsWorkerCompleted.Clear();
					progressBarFitness.Invoke(new Action(() => progressBarFitness.Value=0));
					for (int t = 0; t < THREADS; t++)
					{
						_EventsWorkerCompleted.Add(new System.Threading.AutoResetEvent(false));
						BackgroundWorker bg = new BackgroundWorker();
						bg.DoWork += ((av, b) =>
						{
							int nThread = (int)b.Argument;
							//List<RandomForestNode> trees = new List<RandomForestNode>();
							for (int i = 0; i < pool.Count / THREADS; i++)
							{
								int index = nThread*(pool.Count / THREADS) + i;
								var creator = pool[index];

								creator.FitnessScore = GeneticFunctions.GetFitness(lockOrig, new LockBitmap(new Bitmap(creator.Image)));
								//Console.WriteLine(index + " - " + creator.FitnessScore + "%");
								progressBarFitness.Invoke(new Action(() => progressBarFitness.Value++));
							}
							_EventsWorkerCompleted[nThread].Set();
						});
						bg.RunWorkerAsync(t);
					}

					foreach (var eventWait in _EventsWorkerCompleted)
						eventWait.WaitOne();
					/*foreach (var creator in pool)
					{
						//On calcule le score de chaque individu du pool
						if (creator.FitnessScore == -1)
						{
							creator.FitnessScore = GeneticFunctions.GetFitness(lockOrig, new LockBitmap(new Bitmap(creator.Image)));
						}
						Console.WriteLine("Fintess : " + creator.FitnessScore);
					}
					*/
					//On affiche la meilleure image
					pool = pool.OrderByDescending(c => c.FitnessScore).ToList();
					Best = pool[0].FitnessScore;
					this.labelFitness.Invoke(new Action(() => 
					{
						this.imageCalculee.Image = pool[0].Image;
						this.labelFitness.Text = 
							"Generation n° " + generation
							+"\r\nAvg : " +  pool.Average(c=> c.FitnessScore).ToString("00.00")+"%"
							+"\r\nBest : " + Best.ToString("00.00")+"%";
					}));
					//On crée une nouvelle génération
					//Console.WriteLine("Creating generation n°" + generation);
					pool = GeneticFunctions.CreateNewGeneration(pool);
					progressBar.Invoke(new Action(() => progressBar.Value++));
				}
			};
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
					GeneticFunctions.MUTATIONS_COUNT++;
					Console.WriteLine("Mutations : " + GeneticFunctions.MUTATIONS_COUNT);
				}
			}
		}

		protected List<System.Threading.AutoResetEvent> _EventsWorkerCompleted = new List<System.Threading.AutoResetEvent>();

		public void loadImageOriginale(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					imageOriginale.Image = new Bitmap(ofd.FileName);
					GeneticFunctions.MAX_FONT_SIZE = (int)(Math.Max(10, imageOriginale.Image.Height/3));
					//GeneticFunctions.MAX_FONT_SIZE = 10;
					Console.WriteLine("Max font size = " + GeneticFunctions.MAX_FONT_SIZE);

					double score = GeneticFunctions.GetFitness(new LockBitmap(new Bitmap(imageOriginale.Image)), new LockBitmap(new Bitmap(imageOriginale.Image)));

					Console.WriteLine(score);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Impossible de charger l'image : " + ex.Message, "Echec du chargement de l'image");
				}
			}
		}
	}
}

