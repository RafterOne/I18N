using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I18N.Test
{
	using NUnit.Framework;
	using I18N;
	using System.Xml.Linq;
	using System.IO;
	using System.Reflection;
	using System.Resources;

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

		[Test]
		public void ResourceObjectIsUsable()
		{
			string prefix = "ApplicationResources_";
			string id = "id";

			XDocument doc = XDocument.Load("../../../XliffParser/FrenchXliff.xml");
			//NEED TO GET THE LANGUAGE FOR THE OUTPUT FILE NAME
			
			string nameSpace = doc.Root.GetDefaultNamespace().NamespaceName;
			XName xfile = XName.Get("file", nameSpace);
			string language = doc.Descendants(xfile).FirstOrDefault().Attribute("target-language").Value.ToString();

			XName xname = XName.Get("trans-unit", nameSpace);
			XName xtarget = XName.Get("target", nameSpace);

			string outputPath = Directory.GetCurrentDirectory();

			I18N.Resource r = new Resource();
			Assert.IsNotNull(r);

			r.Write(ref doc, outputPath, language, ref prefix, ref id, ref xname,  ref xtarget);

			ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager("Debug" + prefix + language, "../", null);
			
			var s = resourceManager.GetString("form.label.username", System.Globalization.CultureInfo.CreateSpecificCulture("fr"));
		}
	}
}
