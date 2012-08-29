using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml.Linq;

namespace I18N
{
	public class Resource : IResource
	{
		private const string FILENAME_SUFFIX = ".resx";

		public void Write(
			ref XDocument doc, 
			string outputPath, 
			string language,
			ref string FILENAME_PREFIX,
			ref string ATTRIBUTE_ID,
			ref XName xname,
			ref XName xtarget
			)
		{
			// Creates a resource writer. This provides a default implementation
			// of the IResourceWriter interface. It enables you to programmatically
			// create a binary resource (.resources) file.
			using (ResourceWriter writer = Create(
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
					string key = el.Attribute(ATTRIBUTE_ID).Value;
					StringBuilder value = new StringBuilder();

					foreach (XElement exl in el.Descendants(xtarget))
					{
						value.AppendLine(exl.Value);
					}

					// Adds resources to the resource writer.
					writer.AddResource(key, value.ToString());
				}
			}
		
		}

		public ResourceWriter Create(
			string path, 
			string language, 
			string prefix
		)
		{
			string fileName = prefix + language + FILENAME_SUFFIX;
			return new ResourceWriter(path + fileName);
		}

	}
}
