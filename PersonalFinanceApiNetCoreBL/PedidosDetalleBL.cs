namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PedidosDetalleBL.
    /// </summary>
    public class PedidosDetalleBL
    {
        private PedidosDetalleDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PedidosDetalleBL"/> class.
        /// </summary>
        public PedidosDetalleBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<PedidoDetalle> GetAll()
        {
            return this.mapper.GetAll<PedidoDetalle>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<PedidoDetalle> GetId(int id)
        {
            return this.mapper.GetId<PedidoDetalle>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<PedidoDetalle> GetOrderId(int id)
        {
            return this.mapper.GetId<PedidoDetalle>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public long AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            if (operacion == "create")
            {
                return this.mapper.AddEntity(parametros);
            }
            else
            {
                return this.mapper.UpdateEntity(parametros);
            }
        }
    }
}