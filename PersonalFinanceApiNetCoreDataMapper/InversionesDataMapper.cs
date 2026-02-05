namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase InversionesDataMapper.
    /// </summary>
    public class InversionesDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InversionesDataMapper"/> class.
        /// </summary>
        public InversionesDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int parentid)
        {
            var lstEntidades = new List<Inversion>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pParentId",
                    Valor = parentid,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spMainMenusGetAllByParentId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Inversion>));
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<Inversion>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pLevel",
                    Valor = 1,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spInvestmentsGetAll", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Inversion>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Inversion>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spTransactionsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Inversion>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spInvestmentsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spInvestmentsUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Inversion MapperData(MySqlDataReader mySqlDataReader)
        {
            Inversion entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Entidad = new ()
                {
                    Id = Convert.ToInt32(mySqlDataReader["entityid"]),
                    Nombre = mySqlDataReader["entity"].ToString(),
                    Tipo = mySqlDataReader["entitytype"].ToString(),
                },
                FechaActualizacion = mySqlDataReader["updatedate"] != DBNull.Value ? (DateTime)mySqlDataReader["updatedate"] : null,
                FechaOperacion = mySqlDataReader["investmentdate"] != DBNull.Value ? (DateTime)mySqlDataReader["investmentdate"] : null,
                MontoGanado = (decimal)mySqlDataReader["investmentprofit"],
                MontoInvertido = (decimal)mySqlDataReader["investmentamount"],
                Estado = mySqlDataReader["state"].ToString(),
                Tipo = new InversionTipo()
                {
                    Id = (int)mySqlDataReader["investmenttypeid"],
                    Nombre = mySqlDataReader["denomination"].ToString(),
                    Tipo = mySqlDataReader["type"].ToString(),
                },
            };

            return entidad;
        }
    }
}