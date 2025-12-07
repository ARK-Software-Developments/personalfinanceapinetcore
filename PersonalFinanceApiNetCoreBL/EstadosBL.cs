namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase EstadosBL.
    /// </summary>
    public class EstadosBL
    {
        private PedidosDetalleDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadosBL"/> class.
        /// </summary>
        public EstadosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<PedidoEstado> GetAll()
        {
            return this.mapper.GetAll<PedidoEstado>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<PedidoDetalle> GetId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public long AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            throw new NotImplementedException();
        }
    }
}