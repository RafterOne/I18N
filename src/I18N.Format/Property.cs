using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System;

namespace I18N.Format
{
	public class Property : IProperty
	{
		private const string FILENAME_SUFFIX = ".properties";

		public bool Write(
			ref XDocument doc,
			string outputPath,
			string language,
			ref string FILENAME_PREFIX,
			ref string ATTRIBUTE_ID,
			ref XName xname,
			ref XName xtarget
		)
		{
			try
			{
				// Basic file writing stream iterating the xml and output to
				// file as key=value pairs.
				using (StreamWriter writer = Create(
					outputPath,
					language,
					FILENAME_PREFIX
					))
				{

					IEnumerable<XElement> de =
						from el in doc.Descendants(xname)
						select el;
					foreach (XElement el in de)
					{
						writer.Write(el.Attribute(ATTRIBUTE_ID).Value);
						writer.Write("=");
						foreach (XElement exl in el.Descendants(xtarget))
						{
							writer.WriteLine(exl.Value);
						}
					}

					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

		}

		public StreamWriter Create(
			string path,
			string language,
			string prefix
			)
		{
			string fileName = prefix + language + FILENAME_SUFFIX;
			return File.CreateText(path + fileName);
		}
	}
}
