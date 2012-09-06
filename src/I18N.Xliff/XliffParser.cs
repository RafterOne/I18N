using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace I18N.Xliff
{
	using I18N.Format;
	using I18N.Command;

	public class XliffParser
	{
		private static string FILENAME_PREFIX = "ApplicationResources_";
		private static string NODE_FILE = "file";
		private static string NODE_TRANS_UNIT = "trans-unit";
		private static string NODE_TARGET = "target";
		private static string ATTRIBUTE_ID = "id";

		/// <summary>
		/// Reads an XLIFF file as input and generates a properties file for 
		/// the language contained in the input file. If the input target 
		/// language is zh-CN, the output file will be named 
		/// ApplicationResources_zh-CN.properties. The output file is generated
		/// in the same directory as the input file
		/// </summary>
		/// <param name="args">Arguments are '--help', and '--xliff=' as the fully qualified input filename like C:\Test\XliffParser\TestXliff.xml</param>
		static void Main(string[] args)
		{
			try
			{
				// Command line parsing routine.
				Argument commandLine = new Argument(args);

				if (!String.IsNullOrEmpty(commandLine["help"]) || args.Length == 0)
				{
					Help();
				}
				else {

					if(!String.IsNullOrEmpty(commandLine["xliff"]))
					{
						XDocument doc = XDocument.Load(commandLine["xliff"]);
						//NEED TO GET THE LANGUAGE FOR THE OUTPUT FILE NAME
						string nameSpace = doc.Root.GetDefaultNamespace().NamespaceName;
						XName xfile = XName.Get(NODE_FILE, nameSpace);
						string language = doc.Descendants(xfile).FirstOrDefault().Attribute("target-language").Value.ToString();

						XName xname = XName.Get(NODE_TRANS_UNIT, nameSpace);
						XName xtarget = XName.Get(NODE_TARGET, nameSpace);

						string outputPath = args[0].Substring(0, args[0].LastIndexOf("\\") + 1);

						Resource res = new Resource();
						Property pro = new Property();

						// Write the resource file.
						if (res.Write(ref doc, outputPath, language, ref FILENAME_PREFIX, ref ATTRIBUTE_ID, ref xname, ref xtarget))
						{
							Console.WriteLine("[INFO]	Generated {0} resource file", language);
						}

						// Write the properties file.
						if (pro.Write(ref doc, outputPath, language, ref FILENAME_PREFIX, ref ATTRIBUTE_ID, ref xname, ref xtarget))
						{
							Console.WriteLine("[INFO]	Generated {0} properties file", language);
						}
					}
				}

			} 
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static void Help()
		{
			Console.WriteLine("I18N v0.0.0.2");
			Console.WriteLine("Copyright (c) {0} PixelMEDIA Inc.", DateTime.Now.Year.ToString());
			Console.WriteLine("");
			Console.WriteLine("usage: XliffParser [ARGS]");
			Console.WriteLine("");
			Console.WriteLine("The available commands are:");
			Console.WriteLine("	--help");
			Console.WriteLine("");
			Console.WriteLine("See '--help' for more information on commands.");
		}
	}

}
