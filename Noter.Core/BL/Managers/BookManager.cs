using System;
using System.Collections.Generic;

namespace Noter.Core.BL.Managers
{
	public static class BookManager
	{
		public static Book GetBook(int id)
		{
			return DAL.NoterRepository.GetBook(id);
		}
		
		public static IList<Book> GetBooks()
		{
			return new List<Book>(DAL.NoterRepository.GetBooks());
		}
		
		public static int SaveBook(Book book)
		{
			return DAL.NoterRepository.SaveBook(book);
		}
		
		public static int DeleteBook(int id)
		{
			return DAL.NoterRepository.DeleteBook(id);
		}
	}
}