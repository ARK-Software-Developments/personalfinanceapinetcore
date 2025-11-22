namespace PersonalFinanceApiNetCoreDataMapper
{
    using System.Data;
    using System.Data.Common;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Clase de conexion a la bd.
    /// </summary>
    public class MySQLConnectionDM
    {
        public const string ConnectionString = "Server=localhost;Database=personalfinance;Uid=desarrollo;Pwd=PersonalFinance2025";

        public MySqlConnection Connection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySQLConnectionDM"/> class.
        /// </summary>
        public MySQLConnectionDM()
        {
            this.Iniciar();
        }

        private void Iniciar()
        {
            this.Connection = new MySqlConnection(ConnectionString);
            this.Connection.Open();
        }

        public DbDataReader GetDataReader(string spCommandName)
        {
            MySqlCommand cmd = new (spCommandName, this.Connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader;
                }
            }
        }
    }
}