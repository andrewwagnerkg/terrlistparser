using System;
using System.Text;
using System.Xml;

namespace XmlTerParser
{
    internal class ConsolidatedKgXMLParser : IParser
    {
        public string Parse(string path_to_xml, IBuilder builder)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path_to_xml);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/SanctionList/physicPersons");
            foreach (XmlNode node in nodeList)
            {
                foreach(XmlNode child in node.ChildNodes)
                {
                    string prom = child.SelectSingleNode("Patronomic")!=null ? child.SelectSingleNode("Patronomic").InnerText.Trim() : "";
                    stringBuilder.Append(builder.Build($"{child.SelectSingleNode("Name").InnerText.Trim()} {child.SelectSingleNode("Surname").InnerText.Trim()} {prom}"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
