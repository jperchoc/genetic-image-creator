using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using ImageCreatorGenetic;

namespace ImageCreatorGenetic
{
	public class ImageCharCreator
	{
		public List<ImageCharProperties> caracteres;
		public int width;
		public int height;
		private Bitmap image = null;
		public double FitnessScore=-1;

		public ImageCharCreator(int width, int height)
		{
			this.caracteres = new List<ImageCharProperties>();
			this.width = width;
			this.height = height;
		}
		public Image Image
		{
			get{
				if (image != null)
					return image;
				image = new Bitmap(width, height);
				using (Graphics g = Graphics.FromImage(image))
				{
					foreach (var c in caracteres.OrderBy(p => p.charIndex).ToList())
					{
						Font f = new Font("Tahoma", c.charSize);
						Brush br = new SolidBrush(c.charColor);
						//g.DrawString(c.txt, f, br, c.charPosition);
						g.FillEllipse(br,c.charPosition.X , c.charPosition.Y, c.charSize, c.charSize);
					}
				}
				return image;
			}
		}
	}
}

