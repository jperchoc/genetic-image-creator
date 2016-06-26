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
			this.caracteres.Clear();
			this.image = null;
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
				if (this.image != null)
					return this.image;
				else
				{
					this.image = new Bitmap(width, height);
					Graphics g = Graphics.FromImage(this.image);
					g.Clear(Color.Black);
					//this.caracteres = this.caracteres.OrderBy(p => p.charIndex).ToList();
					Brush br = new SolidBrush(Color.White);
					ImageCharProperties prop = null;
					for(int i=0;i<this.caracteres.Count;i++)
					{
						prop = caracteres[i];
						br = new SolidBrush(prop.charColor);
						switch(DrawingMode)
						{
							case DrawMode.Elipse:
							case DrawMode.Circles:
								g.FillEllipse(br, prop.p1.X, prop.p1.Y, prop.charSize1, prop.charSize2);
								break;
							case DrawMode.Triangle:
								g.FillPolygon(br,new PointF[]{prop.p1,prop.p2,prop.p3});
								break;
							case DrawMode.Characters:
								Font f = new Font("Tahoma", prop.charSize1);
								g.DrawString(prop.txt, f, br, prop.p1);
								f.Dispose();
								break;
							default:
								break;
						}			
					}
					br.Dispose();
					g.Dispose();
					return this.image;
				}
			}
		}
	}
}

