namespace PersonalFinanceApiNetCoreDataMapper
{
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase CategoriasDataMapper.
    /// </summary>
    public class CategoriasDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriasDataMapper"/> class.
        /// </summary>
        public CategoriasDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros de categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public static List<Categoria> GetAll()
        {
            var lstEntidades = new List<Categoria>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spCategoriesGetAll");

            Categoria entidad = new Categoria();
            while (mySqlDataReader.Read())
            {
                entidad.Id = Convert.ToInt32(mySqlDataReader["id"]);
                entidad.Nombre = mySqlDataReader["category"].ToString();
                lstEntidades.Add(entidad);
                entidad = new Categoria();
            }

            return lstEntidades;
        }

        /// <summary>
        /// Metodo para obtener un registro de categorias.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static List<Categoria> GetId(int id)
        {
            var lstEntidades = new List<Categoria>();

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

            Categoria entidad = new Categoria();
            while (mySqlDataReader.Read())
            {
                entidad.Id = Convert.ToInt32(mySqlDataReader["id"]);
                entidad.Nombre = mySqlDataReader["category"].ToString();
                lstEntidades.Add(entidad);
                entidad = new Categoria();
            }

            return lstEntidades;
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo a categorias.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCategoriesAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro nuevo a categorias.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCategoriesUpdate", parametros);
        }
    }
}