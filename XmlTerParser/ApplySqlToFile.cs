using System;
using System.IO;

namespace XmlTerParser
{
    internal class ApplySqlToFile : IApplySql
    {
        private string filepath;

        public ApplySqlToFile(string filepath)
        {
            this.filepath = filepath;
            if (File.Exists(filepath))
                File.Move(filepath, $"{DateTime.Now.ToString("yyyyMMddhhmmss")}-{filepath}");
        }

        public string Apply(string sql)
        {
            File.AppendAllText(this.filepath, sql);
            return sql;
        }
    }
}