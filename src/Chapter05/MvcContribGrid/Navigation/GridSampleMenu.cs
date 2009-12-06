using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib.UI.MenuBuilder;

namespace MvcContrib.Samples.UI.Navigation
{
	using UI.Controllers;

	public class GridSampleMenu
	{
		public static MenuItem MainMenu(UrlHelper url)
		{
			Menu.DefaultIconDirectory = url.Content("~/Content/");
			Menu.DefaultDisabledClass = "disabled";
			Menu.DefaultSelectedClass = "selected";
			return Menu.Begin(
						Menu.Items("Grid Samples",
							Menu.Action<GridController>(c => c.Index(), "Simple Grid"),
							Menu.Action<GridController>(c => c.Paged(null), "Paged Grid"),
							Menu.Action<GridController>(c => c.UsingGridModel(), "Using a GridModel"),
							Menu.Action<GridController>(c => c.WithSections(), "Using Grid Sections"),
							Menu.Action<GridController>(c => c.WithActionSections(), "Using Grid Action Sections"),
							Menu.Action<GridController>(c => c.AutoColumns(), "Auto-Generated Columns")
						)					).SetListClass("jd_menu");
		}
	}
}