using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18N.Test
{
	using NUnit.Framework;
	using I18N.Command;

	[TestFixture]
	public class ArgumentBehavior
	{
		#region SetUp / TearDown

		[SetUp]
		public void Init()
		{ }

		[TearDown]
		public void Dispose()
		{ }

		#endregion

		#region Tests

		[Test]
		public void CanParseCommandLineArgs()
		{
			// /name=Jack
			//--name=Jack
			//--name="Multiple words"
			//-name 'Jack'
		
			// String array with 4 elements.
			string[] args = new string[] { " /name=Jack", "--name=Jack", "--name=\"Multiple words\"", "-name 'Jack'" }; // 1
			
			// Command line parsing.
			Argument commandLine = new Argument(args);
			Assert.IsNotNull(commandLine["name"]);
			string val = commandLine["name"];
			Assert.AreEqual("Jack", commandLine["name"]);
			
		}

		#endregion
	}
}
