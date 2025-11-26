namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase EntidadesDataMapper.
    /// </summary>
    public class EntidadesDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntidadesDataMapper"/> class.
        /// </summary>
        public EntidadesDataMapper()
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
            var lstEntidades = new List<Entidad>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spEntitiesGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Entidad>));
        }

        /// <summary>
        /// Metodo para obtener un registro de entidades.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Entidad>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spEntitiesGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Entidad>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo a entidades.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spEntitiesAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro nuevo a entidades.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spEntitiesUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Entidad MapperData(MySqlDataReader mySqlDataReader)
        {
            Entidad entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Nombre = mySqlDataReader["entity"].ToString(),
                Tipo = mySqlDataReader["entitytype"].ToString(),
            };

            return entidad;
        }
    }
}