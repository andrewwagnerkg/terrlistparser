using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlTerParser
{
    internal class ConsolidatedWorldXMLParser : IParser
    {
        public string Parse(string path_to_xml, IBuilder builder)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_to_xml);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/CONSOLIDATED_LIST/INDIVIDUALS");
            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    string prom = child.SelectSingleNode("THIRD_NAME") != null ? child.SelectSingleNode("THIRD_NAME").InnerText.Trim() : "";
                    string secname = child.SelectSingleNode("SECOND_NAME") != null ? child.SelectSingleNode("SECOND_NAME").InnerText.Trim() : "";
                    string firstname = child.SelectSingleNode("FIRST_NAME") != null ? child.SelectSingleNode("FIRST_NAME").InnerText.Trim() : "";
                    stringBuilder.Append(builder.Build($"{firstname} {secname} {prom}"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
