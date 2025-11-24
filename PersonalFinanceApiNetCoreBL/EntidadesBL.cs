namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase EntidadesBL.
    /// </summary>
    public class EntidadesBL
    {
        private EntidadesDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntidadesBL"/> class.
        /// </summary>
        public EntidadesBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la entidad.
        /// </summary>
        /// <returns>Lista de Entidad.</returns>
        public List<Entidad> GetAll()
        {
            return this.mapper.GetAll<Entidad>();
        }

        /// <summary>
        /// Método para obtener un solo registro de entidades.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de Entidad.</returns>
        public List<Entidad> GetId(int id)
        {
            return this.mapper.GetId<Entidad>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro de entidades.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de Entidad.</returns>
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