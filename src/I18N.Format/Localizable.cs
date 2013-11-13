using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System;

namespace I18N.Format
{
	public class Localizable : ILocalizable
	{
		private const string FILENAME_SUFFIX = ".strings";

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
				// file as "KEY" = "VALUE"; pairs. See the Apple Develper documentation
				// https://developer.apple.com/library/ios/documentation/MacOSX/Conceptual/BPInternational/Articles/StringsFiles.html#//apple_ref/doc/uid/20000005-SW1
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
						StringBuilder sb = new StringBuilder();
						sb.AppendFormat("\"{0}\" = ", el.Attribute(ATTRIBUTE_ID).Value);
						foreach (XElement exl in el.Descendants(xtarget))
						{
							sb.AppendFormat("\"{0}\";", exl.Value);
						}

						writer.WriteLine(sb.ToString());
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
