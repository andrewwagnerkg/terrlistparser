using System;

namespace XmlTerParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start downloading...");
            IXmlDownloader xmlDownloader;
            try
            {
                xmlDownloader = new ConsolidateDownloader();
                xmlDownloader.Download("https://scsanctions.un.org/resources/xml/en/consolidated.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            try
            {
                xmlDownloader = new ConsolidateKGXmlDownloader();
                xmlDownloader.Download("https://fiu.gov.kg/uploads/5ef473e90f77c.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Downloading complete");

            try
            {
                IApplySql applygeneric = new ApplySqlToFile("genericsql.sql");
                IApplySql applyterminalv3 = new ApplySqlToFile("terminalv3sql.sql");

                IParser parser = new ConsolidatedKgXMLParser();
                IParser worldparser = new ConsolidatedWorldXMLParser();

                IBuilder sqlbuilder = new GenericSqlBuilder();
                Console.WriteLine(applygeneric.Apply(parser.Parse("consolidatedKG.xml", sqlbuilder)));

                sqlbuilder = new GenericSqlBuilder();
                Console.WriteLine(applygeneric.Apply(worldparser.Parse("consolidated.xml", sqlbuilder)));

                sqlbuilder = new TerminalV3SqlBuilder();
                Console.WriteLine(applyterminalv3.Apply(parser.Parse("consolidatedKG.xml", sqlbuilder)));

                sqlbuilder = new TerminalV3SqlBuilder();
                Console.WriteLine(applyterminalv3.Apply(worldparser.Parse("consolidated.xml", sqlbuilder)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("finish");
        }
    }
}
