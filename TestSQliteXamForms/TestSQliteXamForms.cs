using System;

using Xamarin.Forms;

namespace TestSQliteXamForms
{
	public class App : Application
	{
		static QuestionItemDatabase database;
		public static QuestionItemDatabase Database {
			get {
				database = database ?? new QuestionItemDatabase ();
				return database;
			}
		}

		public App ()
		{

			// Reset Data Every time on launch
			App.Database.DeleteAll ();

			// The root page of your application
			var nav = new NavigationPage (new QuestionListPage ());
			nav.BarBackgroundColor = Color.Blue;
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}
	}
}

