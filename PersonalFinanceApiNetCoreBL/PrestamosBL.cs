namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PrestamosBL.
    /// </summary>
    public class PrestamosBL
    {
        private PrestamosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamosBL"/> class.
        /// </summary>
        public PrestamosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Prestamo> GetAll()
        {
            return this.mapper.GetAll<Prestamo>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Prestamo> GetId(int id)
        {
            return this.mapper.GetId<Prestamo>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            object result = 0;

            switch (operacion)
            {
                case "create":
                    result = this.mapper.AddEntity(parametros);
                    break;

                case "update":
                    result = this.mapper.UpdateEntity(parametros);
                    break;
            }

            return [ result ];
        }
    }
}