using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Noter.BL;
using Noter.DL.SQLite;

namespace Noter.DL
{
	public class NoterDatabase : SQLite
	{
		static object locker = new object();
		
		public NoterDatabase(string path) : base(path)
		{
			// Create database tables
			CreateTable<Widget>();
			CreateTable<Book>();
			/*
			Do I want any more tables?
				Maybe pages, lines, content are custom classes but are not tables
				How does this affect classes in BL?
				Am I sure that pages, lines, and content should not go in the DB?
			*/
		}
		
		public IEnumerable<T> GetItems<T>() where T : BL.Base.IBusinessEntity, new()
		{
			lock(locker)
			{
				return (from i in Table<T>() select i).ToList();
			}
		}
		
		public T GetItem<T>(int id) where T : BL.Base.IBusinessEntity, new()
		{
			lock(locker)
			{
				return Table<T>().FirstOrDefault(x => x.ID == id);
			}
		}
		
		public int SaveItem<T>(T item) where T : BL.Base.IBusinessEntity, new()
		{
			lock(locker)
			{
				if (item.ID != 0)
				{
					Update(item);
					return item.ID;
				}
				else
				{
					return Insert(item);
				}
			}
		}
		
		public int DeleteItem<T>(int id) where T : BL.Base.IBusinessEntity, new()
		{
			lock(locker)
			{
				return Delete<T>(new T() { ID = id });
			}
		}
	}
	
}