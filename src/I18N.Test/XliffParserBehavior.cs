using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18N.Test
{
	using NUnit.Framework;
	using I18N;

	[TestFixture]
	public class XliffParserBehavior
	{
		[SetUp]
		public void Init()
		{
		
		}

		[Test]
		public void CanCreateInstanceOfResourceObject()
		{
			I18N.Resource r = new Resource();
			Assert.IsNotNull(r);
		}
	}
}
