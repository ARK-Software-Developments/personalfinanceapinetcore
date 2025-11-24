namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TipoGastoDataMapper.
    /// </summary>
    public class TipoGastoDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoGastoDataMapper"/> class.
        /// </summary>
        public TipoGastoDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public static List<TipoGasto> GetAll()
        {
            var lstEntidades = new List<TipoGasto>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spTypeOfExpenseGetAll");

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
        public static List<TipoGasto> GetId(int id)
        {
            var lstEntidades = new List<TipoGasto>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spTypeOfExpenseGetId", parametros);

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
            return new MySQLConnectionDM().Add("spTypeOfExpenseAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spTypeOfExpenseUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private static TipoGasto MapperData(MySqlDataReader mySqlDataReader)
        {
            TipoGasto entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Tipo = mySqlDataReader["type"].ToString(),
                Categoria = new ()
                {
                    Id = Convert.ToInt32(mySqlDataReader["categoriesid"]),
                    Nombre = mySqlDataReader["category"].ToString(),
                },
            };

            return entidad;
        }
    }
}