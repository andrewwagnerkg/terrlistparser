using System;

namespace XmlTerParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start downloading...");
            IXmlDownloader xmlDownloader = new ConsolidateDownloader();
            xmlDownloader.Download("https://scsanctions.un.org/resources/xml/en/consolidated.xml");
            xmlDownloader = new ConsolidateKGXmlDownloader();
            xmlDownloader.Download("https://fiu.gov.kg/uploads/5ef473e90f77c.xml");
            Console.WriteLine("Downloading complete");

            IApplySql applygeneric = new ApplySqlToFile("genericsql.sql");
            IApplySql applyterminalv3 = new ApplySqlToFile("terminalv3sql.sql");

            IParser parser = new ConsolidatedKgXMLParser();
            IParser worldparser = new ConsolidatedWorldXMLParser();
            
            IBuilder sqlbuilder=new GenericSqlBuilder();
            Console.WriteLine(applygeneric.Apply(parser.Parse("consolidatedKG.xml",sqlbuilder)));

            sqlbuilder = new GenericSqlBuilder();
            Console.WriteLine(applygeneric.Apply(worldparser.Parse("consolidated.xml", sqlbuilder)));

            sqlbuilder = new TerminalV3SqlBuilder();
            Console.WriteLine(applyterminalv3.Apply(parser.Parse("consolidatedKG.xml",sqlbuilder)));

            sqlbuilder = new TerminalV3SqlBuilder();
            Console.WriteLine(applyterminalv3.Apply(worldparser.Parse("consolidated.xml", sqlbuilder)));

            Console.WriteLine("finish");
        }
    }
}
