namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase EntidadesBL.
    /// </summary>
    public class EntidadesBL
    {
        /// <summary>
        /// Método para obtener todos los registros de la entidad.
        /// </summary>
        /// <returns>Lista de Entidad.</returns>
        public List<Entidad> GetAll()
        {
            return EntidadesDataMapper.GetAll();
        }

        /// <summary>
        /// Método para obtener un solo registro de entidades.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de Entidad.</returns>
        public List<Entidad> GetId(int id)
        {
            return EntidadesDataMapper.GetId(id);
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
                return EntidadesDataMapper.AddEntity(parametros);
            }
            else
            {
                return EntidadesDataMapper.UpdateEntity(parametros);
            }
        }
    }
}