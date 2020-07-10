namespace XmlTerParser
{
    class ConnectionConfig : IConnectionConfig
    {
        private string Host;
        private string UserId;
        private int Port;
        private string Pwd;
        private string Database;
        bool constring = false;
        string ConnectionString = string.Empty;

        public ConnectionConfig(string Host, int Port, string UserId, string Pwd, string Database)
        {
            this.Host = Host;
            this.Port = Port;
            this.Database = Database;
            this.Pwd = Pwd;
            this.UserId = UserId;
            constring = false;
        }

        public ConnectionConfig(string ConnectionString)
        {
            constring = true;
            this.ConnectionString = ConnectionString;
        }


        public string GetConnectionString()
        {
            if (constring)
                return this.ConnectionString;
            return $"server = {this.Host}; port = {this.Port}; uid = {this.UserId}; pwd = {this.Pwd}; database = {this.Database}";
        }
    }
}
