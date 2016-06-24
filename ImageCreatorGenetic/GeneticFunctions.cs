using System;
using System.Drawing;
using System.Collections.Generic;
using ImageCreatorGenetic;

namespace ImageCreatorGenetic
{
	public class GeneticFunctions
	{
		private static Random random = new Random();
		public static int ELITEPERCENT = 5;
		public static int MUTATIONS_COUNT = 1;
		public static int MAX_FONT_SIZE = 30;
		private static List<String> caracteres = new List<string>(){
			"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
			"A","B","C","D","E","F","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
			"0","1","2","3","4","5","6","7","8","9"
		};
		public static double GetFitness(LockBitmap originale, LockBitmap created)
		{
			originale.LockBits();
			created.LockBits();
			double totDiff = 0;
			for (int w = 0; w < originale.Width; w++)
			{
				for (int h = 0; h < originale.Height; h++)
				{
					Color orig = originale.GetPixel(w, h);
					Color crea = created.GetPixel(w, h);

					//pour chaque pixel, diffmax = 3*255
					totDiff += Math.Abs(orig.R-crea.R);
					totDiff += Math.Abs(orig.G-crea.G);
					totDiff += Math.Abs(orig.B-crea.B);

				}
			}
			originale.UnlockBits();
			created.UnlockBits();
			double diffMax = originale.Width * originale.Height * 3 * 255;
			double percentError = (totDiff * 100.0 / diffMax);
			return 100.0 - percentError;
		}

		public static ImageCharCreator Mate(List<ImageCharCreator> newPool, int eliteCount) 
		{
			// get random 2 from elite
			int first = random.Next(eliteCount);
			int second = random.Next(eliteCount);
			while (first == second) {
				second = random.Next(eliteCount);
			}
			// mate the two
			return Mate(newPool[first], newPool[second]);
		}
		public static ImageCharCreator Mate(ImageCharCreator parent1, ImageCharCreator parent2)
		{
			ImageCharCreator icc = new ImageCharCreator(parent1.width, parent1.height);
			for (int i = 0; i < parent1.caracteres.Count; i++) {
				switch (random.Next(2)) {
				case 0:
					icc.caracteres.Add(parent1.caracteres[i]);
					break;
				case 1:
					icc.caracteres.Add(parent2.caracteres[i]);
					break;
				}
			}

			for (int i = 0; i < GeneticFunctions.MUTATIONS_COUNT; i++) {
				icc = mutate(icc);
			}
			return icc;

		}
		public static ImageCharProperties GetRandomChar(int width, int height)
		{
			return new ImageCharProperties(
				caracteres[random.Next(0, caracteres.Count)],
				new PointF(random.Next(0, width), random.Next(0, height)),
				Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
				random.Next(1, MAX_FONT_SIZE),
				random.Next(1, 10));
		}
		public static ImageCharCreator mutate(ImageCharCreator parent)
		{
			//TODO
			int location = random.Next(parent.caracteres.Count);
			parent.caracteres[location] = GetRandomChar(parent.width, parent.height);
			/*
			switch (random.Next(4)) 
			{
				case 0:
					//Console.WriteLine("Mutate : remove and add new random one to the end");
					// remove one and add new prefs to the end
					parent.caracteres.RemoveAt(location);
					parent.caracteres.Add(GetRandomChar(parent.width, parent.height));
					break;
				case 1:
					//Console.WriteLine("Mutate : swap");
					// swap two
					int i1 = location;
					int i2 = random.Next(0, parent.caracteres.Count);
					var tmpchar = parent.caracteres[i1];
					parent.caracteres[i1].charPosition = parent.caracteres[i2].charPosition;
					parent.caracteres[i2].charPosition = tmpchar.charPosition;
					break;
				case 2:
					//Console.WriteLine("Mutate : color change");
					// change ones color
					parent.caracteres[location].charColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
					break;
				case 3:
					//Console.WriteLine("Mutate : replace with random");
					// replace one with new prefs
					parent.caracteres[location] = GetRandomChar(parent.width, parent.height);
					break;
			}
			*/
			return parent;
		}

		public static List<ImageCharCreator> CreateNewGeneration(List<ImageCharCreator> pool)
		{
			List<ImageCharCreator> nouvelleGeneration = new List<ImageCharCreator>();
			int eliteCount = (int)(pool.Count * GeneticFunctions.ELITEPERCENT / 100.0);
			if (eliteCount < 2)
				eliteCount = 2;
			for (int i = 0; i < pool.Count; i++)
			{
					if(i<eliteCount)
					nouvelleGeneration.Add(pool[i]);
				else 
					nouvelleGeneration.Add(Mate(nouvelleGeneration, eliteCount));
			}
			return nouvelleGeneration;
		}
	}
}

