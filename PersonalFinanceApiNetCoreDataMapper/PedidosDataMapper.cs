namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PedidosDataMapper.
    /// </summary>
    public class PedidosDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PedidosDataMapper"/> class.
        /// </summary>
        public PedidosDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public static List<Pedido> GetAll()
        {
            var lstEntidades = new List<Pedido>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spOrdersGetAll");

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
        public static List<Pedido> GetId(int id)
        {
            var lstEntidades = new List<Pedido>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spOrdersGetId", parametros);

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
            return new MySQLConnectionDM().Add("spOrdersAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public static long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spOrdersUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private static Pedido MapperData(MySqlDataReader mySqlDataReader)
        {
            Pedido entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Numero = (int)mySqlDataReader["number"],
                MontoTotal = (decimal)mySqlDataReader["totalamount"],
                FechaPedido = (DateTime)mySqlDataReader["orderdate"],
                FechaRecibido = mySqlDataReader["datereceived"] != DBNull.Value ? (DateTime)mySqlDataReader["datereceived"] : null,
                TipoRecurso = mySqlDataReader["resourcetype"].ToString(),
                Estado = mySqlDataReader["status"].ToString(),
            };

            return entidad;
        }
    }
}