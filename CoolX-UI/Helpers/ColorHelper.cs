using System;
using Xamarin.Forms;

namespace CoolXUI
{
	public static class ColorHelper
	{
		public static Color GetColor (string color)
		{
			if (color.Contains ("#")) {
				return ColorFromHex (color);
			}

			switch (color) {

			case "accent":
				return Color.Accent;

			case "aqua":
				return Color.Aqua;

			case "black":
				return Color.Black;

			case "blue":
				return Color.Blue;

			case "fuchsia":
				return Color.Fuchsia;

			case "gray":
				return Color.Gray;

			case "green":
				return Color.Green;

			case "lime":
				return Color.Lime;

			case "maroon":
				return Color.Maroon;

			case "navy":
				return Color.Navy;

			case "olive":
				return Color.Olive;

			case "pink":
				return Color.Pink;

			case "purple":
				return Color.Purple;

			case "red":
				return Color.Red;

			case "silver":
				return Color.Silver;

			case "teal":
				return Color.Teal;

			case "transparent":
				return Color.Transparent;

			case "white":
				return Color.White;

			case "yellow":
				return Color.Yellow;
			}
			return Color.Default;
		}

		private static Color ColorFromHex (string hex)
		{
			return Color.FromHex (hex);
		}
	}

}

