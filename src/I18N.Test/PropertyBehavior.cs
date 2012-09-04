using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18N.Test
{
	using I18N.Format;
	using NUnit.Framework;

	[TestFixture]
	public class PropertyBehavior
	{
		[SetUp]
		public void Init()
		{

		}

		[Test]
		public void CanCreateInstanceOfPropertyObject()
		{
			I18N.Format.Property p = new Property();
			Assert.IsNotNull(p);
		}
	}
}
