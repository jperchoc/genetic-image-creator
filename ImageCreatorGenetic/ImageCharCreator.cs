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
		public static Color BackColor = Color.Black;

		public List<ImageCharProperties> caracteres;
		public int width;
		public int height;
		private Bitmap image = null;
		public double FitnessScore=-1;
        public List<Font> fonts = new List<Font>();
		~ImageCharCreator()  // destructor
		{
			this.caracteres.Clear();
            this.fonts.Clear();
			this.image = null;
		}
		public ImageCharCreator(int width, int height)
		{
			this.caracteres = new List<ImageCharProperties>();
			this.width = width;
			this.height = height;
            fonts = new List<Font>();
            for (int i = 1; i <= GeneticFunctions.MAX_FONT_SIZE; i++)
                fonts.Add(new Font("Tahoma", i));
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
					g.Clear(BackColor);
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
                                g.FillEllipse(br, prop.p1.X, prop.p1.Y, prop.charSize1, prop.charSize2);
                                break;
                            case DrawMode.Circles:
								g.FillEllipse(br, prop.p1.X, prop.p1.Y, prop.charSize1, prop.charSize1);
								break;
							case DrawMode.Triangle:
								g.FillPolygon(br,new PointF[]{prop.p1,prop.p2,prop.p3});
								break;
							case DrawMode.Characters:
								//Font f = ;
								g.DrawString(prop.txt, fonts[prop.charSize1], br, prop.p1);
								//f.Dispose();
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

