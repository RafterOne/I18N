using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace I18N
{
	public class XliffParser
	{
		private static string FILENAME_PREFIX = "ApplicationResources_";
		//private static string FILENAME_SUFFIX = ".properties";
		private static string NODE_FILE = "file";
		private static string NODE_TRANS_UNIT = "trans-unit";
		private static string NODE_TARGET = "target";
		private static string ATTRIBUTE_ID = "id";

		/// <summary>
		/// Reads an XLIFF file as input and generates a properties file for the language contained in the input file. 
		/// If the input target language is zh-CN, the output file will be named ApplicationResources_zh-CN.properties
		/// 
		/// The output file is generated in the same directory as the input file
		/// </summary>
		/// <param name="args">The only argument is the fully qualified input filename like C:\Test\XliffParser\TestXliff.xml</param>
		static void Main(string[] args)
		{
			try
			{
				
				XDocument doc = XDocument.Load(args[0]);
				//NEED TO GET THE LANGUAGE FOR THE OUTPUT FILE NAME
				string nameSpace = doc.Root.GetDefaultNamespace().NamespaceName;
				XName xfile = XName.Get(NODE_FILE, nameSpace);
				string language = doc.Descendants(xfile).FirstOrDefault().Attribute("target-language").Value.ToString();

				XName xname = XName.Get(NODE_TRANS_UNIT, nameSpace);
				XName xtarget = XName.Get(NODE_TARGET, nameSpace);

				string outputPath = args[0].Substring(0, args[0].LastIndexOf("\\") + 1);

				Resource res = new Resource();
				Property pro = new Property();

				res.Write(ref doc, outputPath, language, ref FILENAME_PREFIX, ref ATTRIBUTE_ID, ref xname, ref xtarget);
				pro.Write(ref doc, outputPath, language, ref FILENAME_PREFIX, ref ATTRIBUTE_ID, ref xname, ref xtarget);

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			
		}
	}

}
