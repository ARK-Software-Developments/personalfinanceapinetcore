namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase TarjetasDataMapper.
    /// </summary>
    public class TarjetasDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetasDataMapper"/> class.
        /// </summary>
        public TarjetasDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<Tarjeta>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spCardsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Tarjeta>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Tarjeta>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spCardsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Tarjeta>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCardsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCardsUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Tarjeta MapperData(MySqlDataReader mySqlDataReader)
        {
            Tarjeta entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Nombre = mySqlDataReader["cardname"].ToString(),
                FechaCierre = (DateTime)mySqlDataReader["closingdate"],
                FechaVencimiento = (DateTime)mySqlDataReader["expirationdate"],
                Entidad = new ()
                {
                    Id = Convert.ToInt32(mySqlDataReader["entityid"]),
                    Nombre = mySqlDataReader["entity"].ToString(),
                    Tipo = mySqlDataReader["entitytype"].ToString(),
                },
                Activo = (bool)mySqlDataReader["active"],
            };

            return entidad;
        }
    }
}