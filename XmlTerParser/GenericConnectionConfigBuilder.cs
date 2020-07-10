using System;
using System.IO;

namespace XmlTerParser
{
    class GenericConnectionConfigBuilder : IConnectionConfigBuilder
    {

        string connectionstring = string.Empty;
        string filepath = "genericdb";

        public GenericConnectionConfigBuilder()
        {
            if (File.Exists(filepath))
                connectionstring = File.ReadAllText(filepath);
            else
                throw new Exception("file terminaldb not found");
        }

        public IConnectionConfig Build()
        {
            if (string.IsNullOrWhiteSpace(connectionstring))
                throw new Exception("connection string in empty");
            return new ConnectionConfig(connectionstring);
        }
    }
}
