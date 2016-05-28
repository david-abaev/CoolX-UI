using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CoolXUI
{
	public static class CoolXStyle
	{
		public static Style GetStyle<T> (string coolXClasses)
		{
			return GetStyle<T> (CoolXSetter.GetSetters<T> (coolXClasses));
		}

		public static Style GetStyle<T> (List<Setter> setters)
		{
			Style style = new Style (typeof(T));
			foreach (Setter setter in setters) {
				style.Setters.Add (setter);
			}
			return style;
		}

		public static Style AddSettersToStyle (Style style, List<Setter> setters)
		{
			foreach (Setter setter in setters) {
				style.Setters.Add (setter);
			}
			return style;
		}
	}

}

