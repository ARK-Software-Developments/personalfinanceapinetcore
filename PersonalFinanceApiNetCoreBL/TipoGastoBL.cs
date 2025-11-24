namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TipoGastoBL.
    /// </summary>
    public class TipoGastoBL
    {
        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<TipoGasto> GetAll()
        {
            return TipoGastoDataMapper.GetAll();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<TipoGasto> GetId(int id)
        {
            return TipoGastoDataMapper.GetId(id);
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
                return TipoGastoDataMapper.AddEntity(parametros);
            }
            else
            {
                return TipoGastoDataMapper.UpdateEntity(parametros);
            }
        }
    }
}