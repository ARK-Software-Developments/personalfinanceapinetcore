namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase InversionesBL.
    /// </summary>
    public class InversionesBL
    {
        private InversionesDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InversionesBL"/> class.
        /// </summary>
        public InversionesBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Inversion> GetAll()
        {
            return this.mapper.GetAll<Inversion>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Inversion> GetId(int id)
        {
            return this.mapper.GetId<Inversion>(id);
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