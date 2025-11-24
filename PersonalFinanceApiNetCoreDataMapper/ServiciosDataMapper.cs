namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase ServiciosDataMapper.
    /// </summary>
    public class ServiciosDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiciosDataMapper"/> class.
        /// </summary>
        public ServiciosDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public static List<Servicio> GetAll()
        {
            var lstEntidades = new List<Servicio>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spServicesGetAll");

            Servicio entidad = new ();
            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(MapperData(mySqlDataReader));
            }

            return lstEntidades;
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static List<Servicio> GetId(int id)
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

            Servicio entidad = new Servicio();
            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(MapperData(mySqlDataReader));
            }

            return lstEntidades;
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCategoriesAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCategoriesUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private static Servicio MapperData(MySqlDataReader mySqlDataReader)
        {
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