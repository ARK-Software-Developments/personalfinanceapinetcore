namespace PersonalFinanceApiNetCoreDataMapper
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase PedidosDataMapper.
    /// </summary>
    public class PedidosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PedidosDataMapper"/> class.
        /// </summary>
        public PedidosDataMapper()
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
            var lstEntidades = new List<Pedido>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spOrdersGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Pedido>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
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
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Pedido>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spOrdersAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spOrdersUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Pedido MapperData(MySqlDataReader mySqlDataReader)
        {
            Pedido entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Numero = (int)mySqlDataReader["number"],
                MontoTotal = (decimal)mySqlDataReader["totalamount"],
                FechaPedido = (DateTime)mySqlDataReader["orderdate"],
                FechaPagado = mySqlDataReader["paymentdate"] != DBNull.Value ? (DateTime)mySqlDataReader["paymentdate"] : null,
                FechaRecibido = mySqlDataReader["datereceived"] != DBNull.Value ? (DateTime)mySqlDataReader["datereceived"] : null,
                TipoRecurso = mySqlDataReader["resourcetype"].ToString(),
                Estado = new PedidoEstado()
                {
                    Id = (int)mySqlDataReader["statusid"],
                    Nombre = mySqlDataReader["name"].ToString(),
                    Orden = (int)mySqlDataReader["order"],
                    Tabla = mySqlDataReader["entityname"].ToString(),
                },
            };

            return entidad;
        }
    }
}