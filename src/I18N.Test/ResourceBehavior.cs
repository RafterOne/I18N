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
	public class ResourceBehavior
	{
		[SetUp]
		public void Init()
		{

		}

		[Test]
		public void CanCreateInstanceOfResourceObject()
		{
			I18N.Format.Resource r = new Resource();
			Assert.IsNotNull(r);
		}

		[Test]
		public void CanWriteAndReadFrenchLanguageResourceFile()
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

			I18N.Format.Resource r = new Resource();
			Assert.IsNotNull(r);

			r.Write(ref doc, outputPath, language, ref prefix, ref id, ref xname, ref xtarget);

			ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager("Debug" + prefix + language, "../", null);

			var s = resourceManager.GetString("form.label.username", System.Globalization.CultureInfo.CreateSpecificCulture("fr"));
		}
	}
}
