using System;
using System.Collections.Generic;
using System.IO;
using Noter.BL;

namespace Noter.DAL
{
	public class NoterRepository
	{
		DL.NoterDatabase db = null;
		protected static string dbLocation;
		protected static NoterRepository me;
		
		static NoterRepository()
		{
			me = new NoterRepository();
		}
		
		protected NoterRepository()
		{
			dbLocation = DatabaseFilePath; //?
			db = new Noter.DL.NoterDatabase(dbLocation);
		}
		
		public static string DatabaseFilePath
		{
			get
			{
				var sqliteFilename = "NoterDB.db3";
				#if NETFX_CORE
					var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else
					#if SILVERLIGHT
						var path = sqliteFilename;
					#else
						#if __ANDROID__
							string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
						#else
							string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
							string libraryPath = Path.Combine(documentsPath, "../Library/");
						#endif
						var path = Path.Combine(libraryPath, sqliteFilename);
					#endif
				#endif
				return path;
			}
		}
		
		public static Widget GetWidget(int id)
		{
			return me.db.GetItem<Widget>(id);
		}
		
		public static IEnumerable<Widget> GetWidgets()
		{
			return me.db.GetItems<Widget>();
		}
		
		public static int SaveWidget(Widget item)
		{
			return me.db.SaveItem<Widget>(item);
		}
		
		public static int DeleteWidget(int id)
		{
			return me.db.DeleteItem<Widget>(id);
		}
	}
}