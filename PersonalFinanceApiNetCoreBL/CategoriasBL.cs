namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase CategoriasBL.
    /// </summary>
    public class CategoriasBL
    {
        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Categoria> GetAll()
        {
            return CategoriasDataMapper.GetAll();
        }

        /// <summary>
        /// Método para obtener un solo registro de categorias.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<Categoria> GetId(int id)
        {
            return CategoriasDataMapper.GetId(id);
        }

        /// <summary>
        /// Método para obtener un solo registro de categorias.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddUpdateEntity(string operacion, List<Parametro> parametros)
        {

            if (operacion == "create")
            {
                return CategoriasDataMapper.AddEntity(parametros);
            }
            else
            {
                return CategoriasDataMapper.UpdateEntity(parametros);
            }
        }
    }
}