namespace PersonalFinanceApiNetCoreDataMapper
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase de conexion a la bd.
    /// </summary>
    public class MySQLConnectionDM
    {
        // <inheritdoc/>
        public const string ConnectionString = "Server=localhost;Database=personalfinance;Uid=desarrollo;Pwd=PersonalFinance2025";

        // <inheritdoc/>
        public MySqlConnection Connection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySQLConnectionDM"/> class.
        /// </summary>
        public MySQLConnectionDM()
        {
            this.Iniciar();
        }

        // <inheritdoc/>
        private void Iniciar()
        {
            this.Connection = new MySqlConnection(ConnectionString);
            this.Connection.Open();
        }

        // <inheritdoc/>
        public MySqlDataReader GetDataReader(string spCommandName, List<Parametro>? parametros = null)
        {
            MySqlCommand cmd = new (spCommandName, this.Connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
            }

            return cmd.ExecuteReader();
        }

        // <inheritdoc/>
        public long Add(string spCommandName, List<Parametro>? parametros)
        {
            MySqlCommand cmd = new (spCommandName, this.Connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
            }

            cmd.ExecuteNonQuery();

            return cmd.LastInsertedId;
        }

        // <inheritdoc/>
        public long Update(string spCommandName, List<Parametro>? parametros)
        {
            MySqlCommand cmd = new(spCommandName, this.Connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
            }

            return cmd.ExecuteNonQuery();
        }
    }
}