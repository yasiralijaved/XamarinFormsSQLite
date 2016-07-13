using System;

using Xamarin.Forms;

namespace TestSQliteXamForms
{
	public class QuestionDetailPage : ContentPage
	{
		public QuestionDetailPage ()
		{

			this.SetBinding (ContentPage.TitleProperty, "Question");


			NavigationPage.SetHasNavigationBar (this, true);
			var questionTextLabel = new Label { Text = "Question Text" };
			var questionTextEntry = new Entry ();

			questionTextEntry.SetBinding (Entry.TextProperty, "QuestionText");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var question = (Question)BindingContext;
				App.Database.SaveItem (question);
				Navigation.PopAsync ();
			};

			var deleteButton = new Button { Text = "Delete" };

				deleteButton.Clicked += (sender, e) => {
					var question = (Question)BindingContext;
					App.Database.DeleteItem (question.ID);
					Navigation.PopAsync ();
				};



			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (20),
				Children = {
					questionTextLabel, questionTextEntry,
					saveButton, deleteButton, cancelButton
				}
			};
		}
	}
}


