using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using ImageCreatorGenetic;

namespace ImageCreatorGenetic
{
	public class ImageCharCreator
	{
        public static DrawMode DrawingMode = DrawMode.Circles;

		public List<ImageCharProperties> caracteres;
		public int width;
		public int height;
		private Bitmap image = null;
		public double FitnessScore=-1;

		~ImageCharCreator()  // destructor
		{
			Console.WriteLine("Destruction d'un charcreator");
		}
		public ImageCharCreator(int width, int height)
		{
			this.caracteres = new List<ImageCharProperties>();
			this.width = width;
			this.height = height;
		}
		public Bitmap Image
		{
			set{image = value;}
			get{
				if (image != null)
					return image;
				image = new Bitmap(width, height);
				using (Graphics g = Graphics.FromImage(image))
				{
                    g.FillRectangle(new SolidBrush(Color.Black), 0, 0, width, height);
//                    caracteres = caracteres.OrderBy(p => p.charIndex).ToList();
					foreach (var c in caracteres)
					{
						Font f = new Font("Tahoma", c.charSize);
						Brush br = new SolidBrush(c.charColor);
                        switch (DrawingMode)
                        {
                            case DrawMode.Circles:
                                g.FillEllipse(br, c.charPosition.X, c.charPosition.Y, c.charSize, c.charSize);
                                break;
                            case DrawMode.Characters:
                                g.DrawString(c.txt, f, br, c.charPosition);
                                break;
                            default:
                                break;
                        }
					}
				}
				return image;
			}
		}
	}
}

