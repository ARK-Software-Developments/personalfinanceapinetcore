namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase ServiciosDataMapper.
    /// </summary>
    public class ServiciosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiciosDataMapper"/> class.
        /// </summary>
        public ServiciosDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int ano)
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
            var lstEntidades = new List<Servicio>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spServicesGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Servicio>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Servicio>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spCategoriesGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Servicio>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCategoriesAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCategoriesUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Servicio MapperData(MySqlDataReader mySqlDataReader)
        {
            if (mySqlDataReader.RecordsAffected < 0)
            {
                return new ();
            }

            Servicio entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Nombre = mySqlDataReader["servicename"].ToString(),
                Monto = (int)mySqlDataReader["unit"],
                MontoUnitario = (decimal)mySqlDataReader["amount"],
                ValidoDesde = (DateTime)mySqlDataReader["validity"],
            };

            return entidad;
        }
    }
}