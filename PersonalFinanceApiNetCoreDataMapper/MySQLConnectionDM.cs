namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CS8618
#pragma warning disable SA1600
#pragma warning disable SA1201
#pragma warning disable SA1202
#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using System.Data;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Clase de conexion a la bd.
    /// </summary>
    public class MySQLConnectionDM
    {
        public const string ConnectionString =
            "Server=localhost;Database=personalfinance;Uid=desarrollo;Pwd=PersonalFinance2025;Charset=utf8mb4;";

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

        public void Close()
        {
            this.Connection.Close();
        }

        public MySqlDataReader GetDataReader(string spCommandName, List<Parametro>? parametros = null)
        {
            MySqlDataReader? reader = null;
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
                        cmd.Parameters.AddWithValue($"@{parametro.Nombre}", NormalizeUnicode(parametro.Valor) ?? DBNull.Value);
                    }
                }

                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }

            return reader;
        }

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
                        cmd.Parameters.AddWithValue($"@{parametro.Nombre}", NormalizeUnicode(parametro.Valor) ?? DBNull.Value);
                    }
                }

                id = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
            finally
            {
                this.Connection.Close();
            }

            return id;
        }

        public long Update(string spCommandName, List<Parametro>? parametros)
        {
            long result = 0;

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
                        cmd.Parameters.AddWithValue($"@{parametro.Nombre}", NormalizeUnicode(parametro.Valor) ?? DBNull.Value);
                    }
                }

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
            finally
            {
                this.Connection.Close();
            }

            return result;
        }

        public long ExecuteSP(string spCommandName, List<Parametro>? parametros)
        {
            long result = 0;

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
                        cmd.Parameters.AddWithValue($"@{parametro.Nombre}", NormalizeUnicode(parametro.Valor) ?? DBNull.Value);
                    }
                }

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
            finally
            {
                this.Connection.Close();
            }

            return result;
        }

        private static object NormalizeUnicode(object? value)
        {
            if (value is string s)
            {
                // Normaliza la cadena a NFC (forma compuesta)
                return s.Normalize(NormalizationForm.FormC);
            }

            return value ?? DBNull.Value;
        }

    }
}
