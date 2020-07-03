using System;

namespace XmlTerParser
{
    internal class GenericSqlBuilder : IBuilder
    {
        public string Build(string param)
        {
            return $"INSERT INTO _terr2(spisok, ter_name, created_at, meta) VALUES(1, '{param}','{DateTime.Now.ToString("yyyy-MM-dd")}', METAPHONE3('{param}'));\r\n";
        }
    }
}
