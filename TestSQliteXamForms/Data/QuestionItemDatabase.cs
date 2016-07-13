using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TestSQliteXamForms
{
	public class QuestionItemDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		string DatabasePath {
			get { 
				var sqliteFilename = "QuestionSQLite.db3";
				#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
				#else
				#if __ANDROID__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				var path = Path.Combine(documentsPath, sqliteFilename);
				#else
				// WinPhone
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
				#endif
				#endif
				return path;
			}
		}

		public QuestionItemDatabase()
		{
			database = new SQLiteConnection (DatabasePath);
			// create the tables
			database.CreateTable<Question>();
		}

		public IEnumerable<Question> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<Question>() select i).ToList();
			}
		}

		public Question GetItem (int id) 
		{
			lock (locker) {
				return database.Table<Question>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem (Question item)
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<Question>(id);
			}
		}

		public int DeleteAll()
		{
			lock (locker) {
				return database.DeleteAll<Question>();
			}
		}
	}
}

