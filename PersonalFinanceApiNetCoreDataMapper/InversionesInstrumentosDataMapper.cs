namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase InversionesInstrumentosDataMapper.
    /// </summary>
    public class InversionesInstrumentosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InversionesInstrumentosDataMapper"/> class.
        /// </summary>
        public InversionesInstrumentosDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<InversionInstrumento>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spInvestmentInstrumentsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<InversionInstrumento>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private InversionInstrumento MapperData(MySqlDataReader mySqlDataReader)
        {
            InversionInstrumento entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Codigo = mySqlDataReader["code"].ToString(),
                Detalle = mySqlDataReader["detail"].ToString(),
                Tipo = new InversionTipo()
                {
                    Id = Convert.ToInt32(mySqlDataReader["investmenttypeid"]),
                    Nombre = mySqlDataReader["denomination"].ToString(),
                    Tipo = mySqlDataReader["type"].ToString(),
                },
            };

            return entidad;
        }
    }
}