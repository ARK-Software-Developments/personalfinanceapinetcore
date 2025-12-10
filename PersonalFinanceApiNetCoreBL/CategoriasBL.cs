namespace PersonalFinanceApiNetCoreBL
{
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly

    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase CategoriasBL.
    /// </summary>
    public class CategoriasBL
    {
        private CategoriasDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriasBL"/> class.
        /// </summary>
        public CategoriasBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Categoria> GetAll()
        {
            return this.mapper.GetAll<Categoria>();
        }

        /// <summary>
        /// Método para obtener un solo registro de categorias.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<Categoria> GetId(int id)
        {
            return this.mapper.GetId<Categoria>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro de categorias.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de categorias.</returns>
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