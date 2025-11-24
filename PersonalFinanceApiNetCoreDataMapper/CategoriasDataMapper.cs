namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase CategoriasDataMapper.
    /// </summary>
    public class CategoriasDataMapper : IDataMapper
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
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<Categoria>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spCategoriesGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Categoria>));
        }

        /// <summary>
        /// Metodo para obtener un registro de categorias.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
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

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Categoria>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo a categorias.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCategoriesAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro nuevo a categorias.
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
        private Categoria MapperData(MySqlDataReader mySqlDataReader)
        {
            Categoria entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Nombre = mySqlDataReader["category"].ToString(),
            };

            return entidad;
        }
    }

    internal record struct NewStruct<T>(List<T> Item1, object Item2)
    {
        public static implicit operator (List<T>, object)(NewStruct<T> value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct<T>((List<T>, object) value)
        {
            return new NewStruct<T>(value.Item1, value.Item2);
        }
    }
}