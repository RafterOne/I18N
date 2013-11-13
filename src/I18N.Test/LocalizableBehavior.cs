using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Resources;
using System.IO;

namespace I18N.Test
{
	using I18N.Format;
	using NUnit.Framework;

	[TestFixture]
	public class LocalizableBehavior
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
		public void Test()
		{
		}

		[Test]
		public void CanCreateInstanceOfLocalizedObject()
		{
			I18N.Format.Localizable l = new Localizable();
			Assert.IsNotNull(l);
		}

		[Test]
		public void CanWriteLocalizableFile()
		{
			string prefix = "ApplicationResources_";
			string id = "id";

			XDocument doc = XDocument.Load("../../../I18N.Test/Assets/FrenchXliff.xml");
			string nameSpace = doc.Root.GetDefaultNamespace().NamespaceName;
			XName xfile = XName.Get("file", nameSpace);
			string language = doc.Descendants(xfile).FirstOrDefault().Attribute("target-language").Value.ToString();

			XName xname = XName.Get("trans-unit", nameSpace);
			XName xtarget = XName.Get("target", nameSpace);

			string outputPath = Directory.GetCurrentDirectory();

			I18N.Format.Localizable l = new Localizable();
			Assert.IsNotNull(l);

			Boolean hasWritten = l.Write(ref doc, outputPath, language, ref prefix, ref id, ref xname, ref xtarget);

			Assert.IsTrue(hasWritten);
		}

		#endregion
	}
}
