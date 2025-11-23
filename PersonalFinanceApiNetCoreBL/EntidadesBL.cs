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
    }
}