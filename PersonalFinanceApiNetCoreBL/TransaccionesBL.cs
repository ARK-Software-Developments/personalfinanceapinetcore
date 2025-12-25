namespace PersonalFinanceApiNetCoreBL
{
#pragma warning disable IDE0079 // Quitar supresión innecesaria
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly

    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TransaccionesBL.
    /// </summary>
    public class TransaccionesBL
    {
        private TransaccionesDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransaccionesBL"/> class.
        /// </summary>
        public TransaccionesBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Transaccion> GetAll()
        {
            return this.mapper.GetAll<Transaccion>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Transaccion> GetId(int id)
        {
            return this.mapper.GetId<Transaccion>(id);
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
                "updatecreditcardspending" => [
                    this.mapper.UpdateEntityCreditCardsPending(parametros),
                    ],
                _ => [],
            };
        }
    }
}