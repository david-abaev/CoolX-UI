using System;

using Xamarin.Forms;
using CoolXUI;

namespace CoolXUIExample
{
	public class App : Application
	{
		public App ()
		{
			Style labelStyle = new Style (typeof(Label));
			labelStyle.Setters.Add (new Setter { 
				Property = Label.TextColorProperty, 
				Value = Color.Red
			});
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					Padding = 25,
					Children = {
						new Label {
							Style = CoolXStyle.AddSettersToStyle (labelStyle, CoolXSetter.GetSetters<Label> ("bg-color:blue;horizontal-center;tEXt:Welcome to CoolX UI!;font-attr:italic;"))
						},
						new ActivityIndicator {
							Style = CoolXUI.CoolXStyle.GetStyle<ActivityIndicator> ("color:rED;on;")
						},
						new DatePicker {
							Style = CoolXUI.CoolXStyle.GetStyle<DatePicker> ("min-date:11/12/1999;date:11/10/2000;"),
						},
						new TimePicker {
							Style = CoolXUI.CoolXStyle.GetStyle<TimePicker> ("timespan-secs:2041;"),
						},
						new Switch {
							Style = CoolXUI.CoolXStyle.GetStyle<Switch> ("not-toggle;")
						},
						new Button {
							Style = CoolXUI.CoolXStyle.GetStyle<Button> ("border-radius:12;border-color:red;text:Click Me;font-size:22;"),
							BorderWidth = 10
						}


					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

