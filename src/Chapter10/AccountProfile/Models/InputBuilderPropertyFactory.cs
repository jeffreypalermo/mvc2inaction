using System;
using System.Collections.Generic;
using MvcContrib.UI.InputBuilder.Conventions;

namespace AccountProfile.Models
{
	public class InputBuilderPropertyFactory : List<IPropertyViewModelFactory>
	{
		public InputBuilderPropertyFactory()
		{
			Add(new GuidPropertyConvention());
			Add(new DefaultProperyConvention());
		}
	}
}