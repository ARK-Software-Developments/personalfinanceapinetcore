namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase ServiciosBL.
    /// </summary>
    public class ServiciosBL
    {
        private ServiciosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiciosBL"/> class.
        /// </summary>
        public ServiciosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Servicio> GetAll()
        {
            return this.mapper.GetAll<Servicio>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Servicio> GetId(int id)
        {
            return this.mapper.GetId<Servicio>(id);
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