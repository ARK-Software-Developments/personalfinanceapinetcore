namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase CalendariosVencimientosBL.
    /// </summary>
    public class CalendariosVencimientosBL
    {
        private CalendariosVencimientosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendariosVencimientosBL"/> class.
        /// </summary>
        public CalendariosVencimientosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<CalendarioVencimiento> GetAll()
        {
            return this.mapper.GetAll<CalendarioVencimiento>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<CalendarioVencimiento> GetId(int id)
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

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="ano">Año.</param>
        /// <returns>Lista de categorias.</returns>
        public List<CalendarioVencimiento> GetAllByYear(int ano)
        {
            throw new NotImplementedException();
        }
    }
}