namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CS8618
#pragma warning disable SA1600
#pragma warning disable SA1201
#pragma warning disable SA1202
#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma

    using System.Data;
    using System.Diagnostics;
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase de conexion a la bd.
    /// </summary>
    public class MySQLConnectionDM
    {
        // <inheritdoc/>
        public const string ConnectionString = "Server=localhost;Database=personalfinance;Uid=desarrollo;Pwd=PersonalFinance2025;Max Pool Size=250";

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

        public void Close()
        {
            this.Connection.Close();
        }

        // <inheritdoc/>
        public MySqlDataReader GetDataReader(string spCommandName, List<Parametro>? parametros = null)
        {
            MySqlDataReader? mySqlDataReader = null;
            try
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

                mySqlDataReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Aplication", ex.ToString(), EventLogEntryType.Error);
            }

            return mySqlDataReader;
        }

        // <inheritdoc/>
        public long Add(string spCommandName, List<Parametro>? parametros)
        {
            long id = 0;
            try
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

                id = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Aplication", ex.ToString(), EventLogEntryType.Error);
            }
            finally
            {
                this.Connection.Close();
            }

            return id;
        }

        // <inheritdoc/>
        public long Update(string spCommandName, List<Parametro>? parametros)
        {
            long id = 0;
            try
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

                id = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Aplication", ex.ToString(), EventLogEntryType.Error);
            }
            finally
            {
                this.Connection.Close();
            }

            return id;
        }
    }
}