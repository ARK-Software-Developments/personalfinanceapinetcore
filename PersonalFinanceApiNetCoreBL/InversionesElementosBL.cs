namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase InversionesElementosBL.
    /// </summary>
    public class InversionesElementosBL
    {
        private InversionesElementosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InversionesElementosBL"/> class.
        /// </summary>
        public InversionesElementosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<InversionElemento> GetAll()
        {
            return this.mapper.GetAll<InversionElemento>();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="investmentId">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<InversionElemento> GetAllByInvestmentId(int investmentId)
        {
            return this.mapper.GetAll<InversionElemento>(investmentId);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<InversionElemento> GetId(int id)
        {
            return this.mapper.GetId<InversionElemento>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            if (operacion == "create")
            {
                return [
                    this.mapper.AddEntity(parametros),
                    ];
            }
            else
            {
                return [
                    this.mapper.UpdateEntity(parametros),
                    ];
            }
        }
    }
}