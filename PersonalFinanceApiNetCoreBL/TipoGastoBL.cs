namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TipoGastoBL.
    /// </summary>
    public class TipoGastoBL
    {
        private TipoGastoDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoGastoBL"/> class.
        /// </summary>
        public TipoGastoBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<TipoGasto> GetAll()
        {
            return this.mapper.GetAll<TipoGasto>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<TipoGasto> GetId(int id)
        {
            return this.mapper.GetId<TipoGasto>(id);
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