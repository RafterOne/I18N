using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace PixelMEDIA.I18N
{
    class XliffParser
    {
        private static string FILENAME_PREFIX = "ApplicationResources_";
        private static string FILENAME_SUFFIX = ".properties";
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

                using (StreamWriter writer = CreateOutputStream(outputPath, language))
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static StreamWriter CreateOutputStream(string path, string language)
        {
            string fileName = FILENAME_PREFIX + language + FILENAME_SUFFIX;
            return File.CreateText(path + fileName);
        }

        /* Sample XLIFF file as input
         * 
         * <?xml version="1.0" encoding="UTF-8" ?>
            <xliff version="1.1" xmlns="urn:oasis:names:tc:xliff:document:1.1" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="urn:oasis:names:tc:xliff:document:1.1 xliff-core-schema-1.1.xsd">
                <file datatype="plaintext" original="" source-language="en-US" target-language="zh-CN">
                    <body>
                <trans-unit approved="no" id="1" extradata="navigation.constants.logout" xml:space="preserve">
                  <source xml:lang="en-US">Client ID</source>
                  <target xml:lang="zh-CN">こん</target>
               </trans-unit>
               <trans-unit approved="no" id="2" extradata="login.label.username" xml:space="preserve">
                  <source xml:lang="en-US">Username</source>
                  <target xml:lang="zh-CN">んにち</target>
               </trans-unit>
               <trans-unit approved="no" id="3" extradata="heading.password" xml:space="preserve">
                  <source xml:lang="en-US">Password</source>
                  <target xml:lang="zh-CN">こんにちは</target>
               </trans-unit>
                <trans-unit approved="no" id="4" extradata="label.login_name" xml:space="preserve">
                  <source xml:lang="en-US">Login</source>
                  <target xml:lang="zh-CN">こんちこんにちは</target>
               </trans-unit>
               <trans-unit approved="no" id="5" extradata="label.acct_locked" xml:space="preserve">
                  <source xml:lang="en-US">Account Locked. Please contact your local administrator.</source>
                  <target xml:lang="zh-CN">こんにちは こん</target>
               </trans-unit>
                </body>
            </file>
        </xliff>
        */
    }

}
