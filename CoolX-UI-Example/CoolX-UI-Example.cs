using System;

using Xamarin.Forms;
using CoolXUI;

namespace CoolXUIExample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					Padding = 25,
					Children = {
						new Label {
							Style = CoolXStyle.GetStyle<Label> ("text-color-#000;bg-color-blue;horizontal-center;text-Welcome to CoolX UI!;")
						},
						new ActivityIndicator {
							Style = CoolXUI.CoolXStyle.GetStyle<ActivityIndicator> ("color-red;on;")
						},
						new DatePicker {
							Style = CoolXUI.CoolXStyle.GetStyle<DatePicker> ("min-date:11/12/1999;date:11/10/2000;"),
						},
						new TimePicker {
							Style = CoolXUI.CoolXStyle.GetStyle<TimePicker> ("timespan-secs:2041;"),
						},
						new Switch {
							Style = CoolXUI.CoolXStyle.GetStyle<Switch> ("toggle")
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

