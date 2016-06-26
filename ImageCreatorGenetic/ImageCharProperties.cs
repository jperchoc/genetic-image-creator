using System;
using System.Drawing;

namespace ImageCreatorGenetic
{
	public class ImageCharProperties
	{
		public Color charColor { get; set;}
		public int charSize1 { get; set;}
		public int charSize2 { get; set;}
		public int charIndex { get; set;}
		public PointF p1 { get; set;}
		public PointF p2 { get; set;}
		public PointF p3 { get; set;}
		public String txt { get; set;}

		public ImageCharProperties()
		{
		}
		public ImageCharProperties(String txt, PointF charPosition, Color charColor, int charSize, int charIndex)
		{
			this.charColor = charColor;
			this.charSize1 = charSize;
			this.charIndex = charIndex;
			this.p1 = charPosition;
			this.txt = txt;
		}
	}
}

