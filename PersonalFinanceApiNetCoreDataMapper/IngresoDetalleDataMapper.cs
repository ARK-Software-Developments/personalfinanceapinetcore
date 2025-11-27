namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CA1822
#pragma warning disable CS8601
#pragma warning disable CS8618
#pragma warning disable SA1623

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase IngresoDetalleDataMapper.
    /// </summary>
    public class IngresoDetalleDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IngresoDetalleDataMapper"/> class.
        /// </summary>
        public IngresoDetalleDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<IngresoDetalle>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spIncomeDetailsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<IngresoDetalle>));
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="ano">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>(int ano)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<IngresoDetalle>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spIncomeDetailsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<IngresoDetalle>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spIncomeDetailsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spIncomeDetailstUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private IngresoDetalle MapperData(MySqlDataReader mySqlDataReader)
        {
            IngresoDetalle entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Codigo = (int)mySqlDataReader["code"],
                Detalle = mySqlDataReader["detail"].ToString(),
            };

            return entidad;
        }
    }
}