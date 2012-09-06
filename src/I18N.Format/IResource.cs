using System.Xml.Linq;
using System.Resources;

namespace I18N.Format
{
	interface IResource
	{
		bool Write(ref XDocument doc, string outputPath, string language, ref string FILENAME_PREFIX, ref string ATTRIBUTE_ID, ref XName xname, ref XName xtarget);
		ResourceWriter Create(string path, string language, string prefix);
	}
}
