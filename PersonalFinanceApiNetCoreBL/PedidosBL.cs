namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PedidosBL.
    /// </summary>
    public class PedidosBL
    {
        private PedidosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PedidosBL"/> class.
        /// </summary>
        public PedidosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Pedido> GetAll()
        {
            return this.mapper.GetAll<Pedido>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Pedido> GetId(int id)
        {
            return this.mapper.GetId<Pedido>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            return operacion switch
            {
                "create" => [
                    this.mapper.AddEntity(parametros),
                    ],
                "update" => [
                    this.mapper.UpdateEntity(parametros),
                    ],
                _ => [],
            };
        }
    }
}