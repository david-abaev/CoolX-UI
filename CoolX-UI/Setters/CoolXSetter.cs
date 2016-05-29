using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace CoolXUI
{
	public static class CoolXSetter
	{
		public static List<Setter> GetSetters<T> (string classes)
		{
			List<Setter> setters = new List<Setter> ();
			List<string> classesList = new List<string> ();

			#region Prepare classes
			foreach (string CoolXClass in classes.Split (';')) {
				string className = CoolXClass.Split (':') [0].ToLower ();
				string newCoolXClass = String.Empty;
				if (className != "text" && className != "placeholder") {
					newCoolXClass = CoolXClass.ToLower ();
				} else {
					newCoolXClass = className + ":" + CoolXClass.Split (':') [1];
				}
				classesList.Add (newCoolXClass);
			}
			#endregion

			try {
				GetBaseSetters (ref setters, ref classesList);

				switch (typeof(T).Name) {
				case "Label":
					GetSettersForLabel (ref setters, classesList);
					break;

				case "Button":
					GetSettersForButton (ref setters, classesList);
					break;

				case "Switch":
					GetSettersForSwitch (ref setters, classesList);
					break;

				case "Entry":
					GetSettersForEntry (ref setters, classesList);
					break;

				case "ActivityIndicator":
					GetSettersForActivityIndicator (ref setters, classesList);
					break;

				case "BoxView":
					GetSettersForBoxView (ref setters, classesList);
					break;
			
				case "DatePicker":
					GetSettersForDatePicker (ref setters, classesList);
					break;

				case "ProgressBar":
					GetSettersForProgressBar (ref setters, classesList);
					break;

				case "Editor":
					GetSettersForEditor (ref setters, classesList);
					break;

				case "Image":
					GetSettersForImage (ref setters, classesList);
					break;


				case "Stepper":
					GetSettersForStepper (ref setters, classesList);
					break;

				case "Slider":
					GetSettersForSlider (ref setters, classesList);
					break;


				case "TimePicker":
					GetSettersForTimePicker (ref setters, classesList);
					break;
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
			return setters;
		}

		private static void GetSettersForActivityIndicator (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("color:")) {
					setters.Add (new Setter { 
						Property = ActivityIndicator.ColorProperty,
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass == "on") {
					setters.Add (new Setter { 
						Property = ActivityIndicator.IsRunningProperty, 
						Value = true
					});
				}

				if (CoolXClass == "off") {
					setters.Add (new Setter { 
						Property = ActivityIndicator.IsRunningProperty, 
						Value = false
					});
				}
			}

		}

		private static void GetSettersForBoxView (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("color:")) {
					setters.Add (new Setter { 
						Property = BoxView.ColorProperty, 
						Value = ColorHelper.GetColor (CoolXClass.Split ('-') [1]) 
					});
					continue;
				}
			}

		}

		private static void GetSettersForButton (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("text-color:")) {
					setters.Add (new Setter { 
						Property = Button.TextColorProperty,
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass.StartsWith ("border-")) {
					switch (CoolXClass.Split ('-') [1].Split (':') [0]) {
					case "radius":
						setters.Add (new Setter { 
							Property = Button.BorderRadiusProperty,
							Value = Convert.ToInt32 (CoolXClass.Split (':') [1])
						});
						break;

					case "width":
						setters.Add (new Setter { 
							Property = Button.BorderWidthProperty,
							Value = Convert.ToDouble (CoolXClass.Split (':') [1])
						});
						break;

					case "color":
						setters.Add (new Setter { 
							Property = Button.BorderColorProperty,
							Value = ColorHelper.GetColor (CoolXClass.Split (':') [1])
						});
						break;
					}
				}
				if (CoolXClass.StartsWith ("font-size:")) {
					double fontSize = Convert.ToDouble (CoolXClass.Split (':') [1]);
					setters.Add (new Setter{ Property = Button.FontSizeProperty, Value = fontSize });
					continue;
				}
				if (CoolXClass.StartsWith ("text-color:")) {
					setters.Add (new Setter {
						Property = Button.TextProperty,
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.StartsWith ("text:")) {
					setters.Add (new Setter{ Property = Button.TextProperty, Value = CoolXClass.Split (':') [1] });
					continue;
				}

			}
		}

		private static void GetSettersForDatePicker (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				if (CoolXClass.StartsWith ("min-date:")) {
					setters.Add (new Setter { 
						Property = DatePicker.MinimumDateProperty, 
						Value = Convert.ToDateTime (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.StartsWith ("max-date:")) {
					setters.Add (new Setter { 
						Property = DatePicker.MaximumDateProperty, 
						Value = Convert.ToDateTime (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.StartsWith ("date:")) {
					setters.Add (new Setter { 
						Property = DatePicker.DateProperty, 
						Value = Convert.ToDateTime (CoolXClass.Split (':') [1])
					});
					continue;
				}
			}
		}

		private static void GetSettersForEditor (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("text:")) {
					setters.Add (new Setter { 
						Property = Editor.TextProperty, 
						Value = CoolXClass.Split (':') [1]
					});
					continue;
				}
			}
		}

		private static void GetSettersForEntry (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("text-color:")) {
					setters.Add (new Setter { 
						Property = Entry.TextColorProperty, 
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass.Contains ("placeholder:")) {
					setters.Add (new Setter { 
						Property = Entry.PlaceholderProperty, 
						Value = CoolXClass.Split (':') [1]
					});
					continue;
				}

				if (CoolXClass.Contains ("text:")) {
					setters.Add (new Setter { 
						Property = Entry.TextProperty, 
						Value = CoolXClass.Split (':') [1]
					});
					continue;
				}

				switch (CoolXClass) {
				case "password":
					setters.Add (new Setter { 
						Property = Entry.IsPasswordProperty, 
						Value = true
					});
					break;
				}
			}
		}

		private static void GetSettersForImage (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				switch (CoolXClass) {
				case "loading":
					setters.Add (new Setter { 
						Property = Image.IsLoadingProperty, 
						Value = true
					});
					break;


				case "not-loading":
					setters.Add (new Setter { 
						Property = Image.IsLoadingProperty, 
						Value = false
					});
					break;

				case "opaque":
					setters.Add (new Setter { 
						Property = Image.IsOpaqueProperty,
						Value = true
					});
					break;


				case "not-opaque":
					setters.Add (new Setter { 
						Property = Image.IsOpaqueProperty, 
						Value = false
					});
					break;

				case "aspect-fit":
					setters.Add (new Setter { 
						Property = Image.AspectProperty, 
						Value = Aspect.AspectFit
					});
					break;

				case "aspect-fill":
					setters.Add (new Setter { 
						Property = Image.AspectProperty, 
						Value = Aspect.AspectFill
					});
					break;

				case "fill":
					setters.Add (new Setter { 
						Property = Image.AspectProperty, 
						Value = Aspect.Fill
					});
					break;
				}
			}
		}

		private static void GetSettersForLabel (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("text-color:")) {
					setters.Add (new Setter { 
						Property = Label.TextColorProperty, 
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass.StartsWith ("line-break")) {
					switch (CoolXClass.Split (':') [1]) {
					case "none":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.NoWrap });
						break;
					case "word":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.WordWrap });
						break;
					case "character":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.CharacterWrap });
						break;
					case "head":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.HeadTruncation });
						break;
					case "tail":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.TailTruncation });
						break;
					case "middle":
						setters.Add (new Setter{ Property = Label.LineBreakModeProperty, Value = LineBreakMode.MiddleTruncation });
						break;
					}
					continue;
				}

				if (CoolXClass.StartsWith ("font-attr:")) {
					switch (CoolXClass.Split (':') [1]) {
					case "none":
						setters.Add (new Setter{ Property = Label.FontAttributesProperty, Value = FontAttributes.None });
						break;
					case "bold":
						setters.Add (new Setter{ Property = Label.FontAttributesProperty, Value = FontAttributes.Bold });
						break;
					case "italic":
						setters.Add (new Setter{ Property = Label.FontAttributesProperty, Value = FontAttributes.Italic });
						break;
					}
					continue;
				}

				if (CoolXClass.StartsWith ("font-size:")) {
					double fontSize = Convert.ToDouble (CoolXClass.Split (':') [1]);
					setters.Add (new Setter{ Property = Label.FontSizeProperty, Value = fontSize });
					continue;
				}

				if (CoolXClass.StartsWith ("text:")) {
					setters.Add (new Setter{ Property = Label.TextProperty, Value = CoolXClass.Split (':') [1] });
					continue;
				}


				switch (CoolXClass) {
				case "horizontal-start":
				case "horizontal-center":
				case "horizontal-end":
					setters.Add (new Setter { 
						Property = Label.XAlignProperty,
						Value = CoolXClass.Split ('-') [1] == "center" ? TextAlignment.Center : (CoolXClass.Split ('-') [1] == "start" ? TextAlignment.Start : TextAlignment.End)
					});
					break;

				case "vertical-start":
				case "vertical-center":
				case "vertical-end":
					setters.Add (new Setter { 
						Property = Label.YAlignProperty, 
						Value = CoolXClass.Split ('-') [1] == "center" ? TextAlignment.Center : (CoolXClass.Split ('-') [1] == "start" ? TextAlignment.Start : TextAlignment.End)
					});
					break;
				}
			}
		}

		private static void GetSettersForProgressBar (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("progress:")) {
					setters.Add (new Setter { 
						Property = ProgressBar.ProgressProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}
			}
		}

		private static void GetSettersForSearchBar (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				if (CoolXClass.Contains ("cancel-color:")) {
					setters.Add (new Setter { 
						Property = SearchBar.CancelButtonColorProperty, 
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass.Contains ("placeholder:")) {
					setters.Add (new Setter { 
						Property = SearchBar.PlaceholderProperty, 
						Value = CoolXClass.Split (':') [1]
					});
					continue;
				}

				if (CoolXClass.Contains ("text:")) {
					setters.Add (new Setter { 
						Property = SearchBar.TextProperty, 
						Value = CoolXClass.Split (':') [1]
					});
					continue;
				}
			}
		}

		private static void GetSettersForSlider (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				if (CoolXClass.Contains ("min:")) {
					setters.Add (new Setter { 
						Property = Slider.MinimumProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.Contains ("max:")) {
					setters.Add (new Setter { 
						Property = Slider.MaximumProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}


				if (CoolXClass.Contains ("value:")) {
					setters.Add (new Setter { 
						Property = Slider.ValueProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}
			}
		}

		private static void GetSettersForStepper (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				if (CoolXClass.Contains ("min:")) {
					setters.Add (new Setter { 
						Property = Stepper.MinimumProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.Contains ("max:")) {
					setters.Add (new Setter { 
						Property = Stepper.MaximumProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.Contains ("increment:")) {
					setters.Add (new Setter { 
						Property = Stepper.IncrementProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}

				if (CoolXClass.Contains ("value:")) {
					setters.Add (new Setter { 
						Property = Stepper.ValueProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1])
					});
					continue;
				}
			}
		}

		private static void GetSettersForSwitch (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {
				switch (CoolXClass) {

				case "toggle":
					setters.Add (new Setter { 
						Property = Switch.IsToggledProperty, 
						Value = true
					});
					break;

				case "not-toggle":
					setters.Add (new Setter { 
						Property = Switch.IsToggledProperty, 
						Value = false
					});
					break;
				}
			}
		}

		private static void GetSettersForTimePicker (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				if (CoolXClass.Contains ("timespan-")) {

					double _span = Convert.ToDouble (CoolXClass.Split (':') [1]);

					switch (CoolXClass.Split ('-') [1].Split (':') [0]) {

					case "millisecs":
						setters.Add (new Setter { 
							Property = TimePicker.TimeProperty, 
							Value = TimeSpan.FromMilliseconds (_span)
						});
						break;

					case "secs":
						setters.Add (new Setter { 
							Property = TimePicker.TimeProperty, 
							Value = TimeSpan.FromSeconds (_span)
						});
						break;

					case "mins":
						setters.Add (new Setter { 
							Property = TimePicker.TimeProperty, 
							Value = TimeSpan.FromMinutes (_span)
						});
						break;

					case "hours":
						setters.Add (new Setter { 
							Property = TimePicker.TimeProperty, 
							Value = TimeSpan.FromHours (_span)
						});
						break;

					case "days":
						setters.Add (new Setter { 
							Property = TimePicker.TimeProperty, 
							Value = TimeSpan.FromDays (_span)
						});
						break;
					}
				}
			}

		}

		private static void GetSettersForWebView (ref List<Setter> setters, List<string> classes)
		{
			foreach (string CoolXClass in classes) {

				switch (CoolXClass) {
				case "can-back":
					setters.Add (new Setter { 
						Property = WebView.CanGoBackProperty, 
						Value = true
					});
					break;

				case "can-forward":
					setters.Add (new Setter { 
						Property = WebView.CanGoForwardProperty, 
						Value = true
					});
					break;

				case "cant-back":
					setters.Add (new Setter { 
						Property = WebView.CanGoBackProperty, 
						Value = false
					});
					break;

				case "cant-forward":
					setters.Add (new Setter { 
						Property = WebView.CanGoForwardProperty, 
						Value = false
					});
					break;
				}

			}
		}

		private static void GetBaseSetters (ref List<Setter> setters, ref List<string> classes)
		{
			List<string> currentClasses = new List<string> (classes);
			foreach (string CoolXClass in currentClasses) {
				if (CoolXClass.Contains ("bg-color")) {
					setters.Add (new Setter { 
						Property = VisualElement.BackgroundColorProperty, 
						Value = ColorHelper.GetColor (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("anchor-x")) {
					setters.Add (new Setter { 
						Property = VisualElement.AnchorXProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					continue;
				}

				if (CoolXClass.Contains ("anchor-y")) {
					setters.Add (new Setter { 
						Property = VisualElement.AnchorYProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("height")) {
					setters.Add (new Setter { 
						Property = VisualElement.HeightProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("min-height")) {
					setters.Add (new Setter { 
						Property = VisualElement.MinimumHeightRequestProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("height-request")) {
					setters.Add (new Setter { 
						Property = VisualElement.HeightRequestProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("width")) {
					setters.Add (new Setter { 
						Property = VisualElement.WidthProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("min-width")) {
					setters.Add (new Setter { 
						Property = VisualElement.MinimumWidthRequestProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.Contains ("width-request")) {
					setters.Add (new Setter { 
						Property = VisualElement.WidthRequestProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("rotation")) {
					setters.Add (new Setter { 
						Property = VisualElement.RotationProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("rotation-x")) {
					setters.Add (new Setter { 
						Property = VisualElement.RotationXProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("rotation-y")) {
					setters.Add (new Setter { 
						Property = VisualElement.RotationYProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("translation-x")) {
					setters.Add (new Setter { 
						Property = VisualElement.TranslationXProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("translation-y")) {
					setters.Add (new Setter { 
						Property = VisualElement.TranslationYProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("x-")) {
					setters.Add (new Setter { 
						Property = VisualElement.XProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("y-")) {
					setters.Add (new Setter { 
						Property = VisualElement.YProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}

				if (CoolXClass.StartsWith ("opacity")) {
					setters.Add (new Setter { 
						Property = VisualElement.OpacityProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}


				if (CoolXClass.StartsWith ("scale")) {
					setters.Add (new Setter { 
						Property = VisualElement.ScaleProperty, 
						Value = Convert.ToDouble (CoolXClass.Split (':') [1]) 
					});
					classes.Remove (CoolXClass);
					continue;
				}


				switch (CoolXClass) {

				case "hidden":
					setters.Add (new Setter { 
						Property = VisualElement.IsVisibleProperty, 
						Value = false
					});
					classes.Remove (CoolXClass);
					break;

				case "visible":
					setters.Add (new Setter { 
						Property = VisualElement.IsVisibleProperty, 
						Value = true
					});
					classes.Remove (CoolXClass);
					break;

				case "enable":
					setters.Add (new Setter { 
						Property = VisualElement.IsEnabledProperty, 
						Value = true
					});
					classes.Remove (CoolXClass);
					break;

				case "disable":
					setters.Add (new Setter { 
						Property = VisualElement.IsEnabledProperty, 
						Value = false
					});
					classes.Remove (CoolXClass);
					break;
				}
			}
		}
	}
}

