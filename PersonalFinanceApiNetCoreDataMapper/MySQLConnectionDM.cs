namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Data.Common;
    using System.Reflection.PortableExecutable;

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

        public MySqlDataReader GetDataReader(string spCommandName)
        {
            MySqlCommand cmd = new (spCommandName, this.Connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            return cmd.ExecuteReader();
        }
    }
}