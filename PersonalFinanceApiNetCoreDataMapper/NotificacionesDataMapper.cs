namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase NotificacionesDataMapper.
    /// </summary>
    public class NotificacionesDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificacionesDataMapper"/> class.
        /// </summary>
        public NotificacionesDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<Notificacion>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spNotificationsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Notificacion>));
        }

        /// <inheritdoc/>
        public long AddEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int ano)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<T> GetId<T>(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public long UpdateEntity(List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Notificacion MapperData(MySqlDataReader mySqlDataReader)
        {
            Notificacion entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                FechaNotificacion = (DateTime)mySqlDataReader["notificationdate"],
                Titulo = mySqlDataReader["title"].ToString(),
                Tipo = mySqlDataReader["type"].ToString(),
                Mensaje = mySqlDataReader["messaje"].ToString(),
                Para = mySqlDataReader["to"].ToString(),
                Aplicacion = mySqlDataReader["app"].ToString(),
                Nivel = mySqlDataReader["level"].ToString(),
                Imagen = mySqlDataReader["img"].ToString(),
            };

            return entidad;
        }
    }
}