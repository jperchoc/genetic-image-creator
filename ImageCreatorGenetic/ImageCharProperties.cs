using System;
using System.Drawing;

namespace ImageCreatorGenetic
{
	public class ImageCharProperties
	{
		public Color charColor;
		public int charSize;
		public int charIndex;
		public PointF charPosition;
		public String txt;

		public ImageCharProperties()
		{
		}
		public ImageCharProperties(String txt, PointF charPosition, Color charColor, int charSize, int charIndex)
		{
			this.charColor = charColor;
			this.charSize = charSize;
			this.charIndex = charIndex;
			this.charPosition = charPosition;
			this.txt = txt;
		}
	}
}

