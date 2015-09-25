using System;
using System.Collections.Generic;

namespace Noter.BL.Managers
{
	public static class WidgetManager
	{
		// Do we need constructor?
		/*
		WidgetManager()
		{
		}
		*/
		
		/*
		--- CRUD ---
			Create, read, update, delete
		
		--- TASKY CASE STUDY ---
			BL.Manager - Get, Gets, Save, Delete
			DAL.Repository - Get, Gets, Save, Delete
			DL.Database - Get, Gets, Save, Delete
		
		--- MWC CASE STUDY ---
			BL.Manager - Gets, Is(bool), Add, Remove, Updates(list), Get(id), GetWithName(string)
				To perform update, delete then save (?)
				Seems kinda wonky... check SQLite for updating DB entries
		
		--- C# MVC W/ EF ---
			Index, Create, Edit, Details, Delete
		
		--- MY THOUGHTS ---
			Going from MVC/EF to Tasky...
				Index == Gets
				Details == Get
				Create == Save
				Delete = Delete
			Does this mean that Save can work for both Create and Edit?
		*/
		
		public static void AddWidget(Widget widget)
		{
			DAL.NoterRepository.SaveWidget(widget);
		}
		
		public static void RemoveWidget(Widget widget)
		{
			DAL.NoterRepository.DeleteWidget(widget);
		}
		
		public static Widget GetWidgetByID(int id)
		{
			return DAL.NoterRepository.GetWidget(id);
		}
		
		public static Widget GetWidgetByTitle(string title)
		{
			return DAL.NoterRepository.GetWidget(title);
		}
		
		public static IList<Widget> GetWidgets()
		{
			List<Widget> widgets = List<Widget>(DAL.NoterRepository.GetWidgets())
			return widgets;
		}
	}
}