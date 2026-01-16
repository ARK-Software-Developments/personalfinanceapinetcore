namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase CalendariosVencimientosDataMapper.
    /// </summary>
    public class CalendariosVencimientosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendariosVencimientosDataMapper"/> class.
        /// </summary>
        public CalendariosVencimientosDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int ano)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener todos los registros de entidades.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de entidades.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<CalendarioVencimiento>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spDueDatesScheduleGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<CalendarioVencimiento>));
        }

        /// <summary>
        /// Metodo para obtener un registro de entidades.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public List<T> GetId<T>(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo a entidades.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para actualizar un registro nuevo a entidades.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private CalendarioVencimiento MapperData(MySqlDataReader mySqlDataReader)
        {
            CalendarioVencimiento entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                FechaVencimiento = (DateTime)mySqlDataReader["scheduledateexpiration"],
                TipoGastoId = (int)mySqlDataReader["typeofexpenseid"],
                Activo = (bool)mySqlDataReader["active"],
            };

            return entidad;
        }
    }
}