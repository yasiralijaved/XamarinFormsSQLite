using System;

using Xamarin.Forms;

namespace TestSQliteXamForms
{
	public class QuestionCell : ViewCell
	{
		public QuestionCell ()
		{
			var label = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			label.SetBinding (Label.TextProperty, "QuestionText");

			var layout = new StackLayout {
				Padding = new Thickness (20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { label }
			};

			View = layout;
		}
	}
}


