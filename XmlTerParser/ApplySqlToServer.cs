using MySql.Data.MySqlClient;

namespace XmlTerParser
{
    class ApplySqlToServer : IApplySql
    {
        IConnectionConfig config;

        public ApplySqlToServer(IConnectionConfig config)
        {
            this.config = config;
        }

        public string Apply(string sql)
        {
            using (MySqlConnection connection=new MySqlConnection(config.GetConnectionString()))
            {
                connection.Open();
                MySqlCommand command=connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                connection.Close();
            }
            return sql;
        }
    }
}
