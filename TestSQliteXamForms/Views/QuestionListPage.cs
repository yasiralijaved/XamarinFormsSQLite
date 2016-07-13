using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace TestSQliteXamForms
{
	public class QuestionListPage : ContentPage
	{
		ListView listView;

		public QuestionListPage ()
		{
			Title = "Question";

			NavigationPage.SetHasNavigationBar (this, true);

			listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate (typeof(QuestionCell))
			};

			listView.ItemSelected += (sender, e) => {
				var question = (Question)e.SelectedItem;
				var questionDetailPage = new QuestionDetailPage ();
				questionDetailPage.BindingContext = question;
				Navigation.PushAsync (questionDetailPage);
			};

			/*
			listView.ItemsSource = new Question [] { 
				new Question {QuestionText = "Question 1"}, 
				new Question {QuestionText = "Question 2"},
				new Question {QuestionText = "Question 3"},
				new Question {QuestionText = "Question 4"},
				new Question {QuestionText = "Question 5"},
				new Question {QuestionText = "Question 6"},
						};
						*/

			var layout = new StackLayout ();
			layout.Children.Add (listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			ToolbarItem tbi = null;

			if (Device.OS == TargetPlatform.iOS) {
				tbi = new ToolbarItem ("+", null, () => {
					var questionItem = new Question ();
					var questionDetailPage = new QuestionDetailPage ();
					questionDetailPage.BindingContext = questionItem;
					Navigation.PushAsync (questionDetailPage);
				}, 0, 0);
			}

			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var questionItem = new Question ();
					var questionDetailPage = new QuestionDetailPage ();
					questionDetailPage.BindingContext = questionItem;
					Navigation.PushAsync (questionDetailPage);
				}, 0, 0);
			}

			ToolbarItems.Add (tbi);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			IEnumerable<Question> questions = App.Database.GetItems ();
			listView.ItemsSource = questions;
		}
	}
}


