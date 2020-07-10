using System;

namespace XmlTerParser
{
    internal class TerminalV3SqlBuilder : IBuilder
    {
        public string Build(string param)
        {
            return $"INSERT INTO pfods(spisok, tername, created_at) VALUES(1, '{param}','{DateTime.Now.ToString("yyyy-MM-dd")}');\r\n";
        }
    }
}
