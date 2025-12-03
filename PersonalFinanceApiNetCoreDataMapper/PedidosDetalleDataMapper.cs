namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase PedidosDetalleDataMapper.
    /// </summary>
    public class PedidosDetalleDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PedidosDetalleDataMapper"/> class.
        /// </summary>
        public PedidosDetalleDataMapper()
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
            var lstEntidades = new List<PedidoDetalle>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spOrderDetailsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<PedidoDetalle>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<PedidoDetalle>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spOrderDetailsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<PedidoDetalle>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetOrderId<T>(int id)
        {
            var lstEntidades = new List<PedidoDetalle>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pOrderId",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spOrderDetailsGetOrderId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<PedidoDetalle>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spOrderDetailsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spOrderDetailsUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private PedidoDetalle MapperData(MySqlDataReader mySqlDataReader)
        {
            PedidoDetalle entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                NumeroOrden = (int)mySqlDataReader["ordersid"],
                Marca = mySqlDataReader["brand"].ToString(),
                ProductoDetalle = mySqlDataReader["productdetails"].ToString(),
                Descripcion = mySqlDataReader["description"].ToString(),
                CodigoProducto = mySqlDataReader["productcode"].ToString(),
                Cantidad = (int)mySqlDataReader["quantity"],
                MontoUnitario = (decimal)mySqlDataReader["unitprice"],
                SubTotal = (decimal)mySqlDataReader["subtotal"],
                Para = mySqlDataReader["to"].ToString(),
                Estado = mySqlDataReader["status"].ToString(),
            };

            return entidad;
        }
    }
}