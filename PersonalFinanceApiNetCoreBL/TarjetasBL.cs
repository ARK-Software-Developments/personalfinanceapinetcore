namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TarjetasBL.
    /// </summary>
    public class TarjetasBL
    {
        private TarjetasDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetasBL"/> class.
        /// </summary>
        public TarjetasBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Tarjeta> GetAll()
        {
            return this.mapper.GetAll<Tarjeta>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Tarjeta> GetId(int id)
        {
            return this.mapper.GetId<Tarjeta>(id);
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