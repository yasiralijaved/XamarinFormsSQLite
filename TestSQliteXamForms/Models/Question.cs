using System;
using SQLite;

namespace TestSQliteXamForms
{
	public class Question
	{
		public Question ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string QuestionText { get; set; }
	}
}

