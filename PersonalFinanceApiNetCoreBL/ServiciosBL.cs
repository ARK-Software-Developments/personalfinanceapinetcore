namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase ServiciosBL.
    /// </summary>
    public class ServiciosBL
    {
        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Servicio> GetAll()
        {
            return ServiciosDataMapper.GetAll();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Servicio> GetId(int id)
        {
            return ServiciosDataMapper.GetId(id);
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
                return ServiciosDataMapper.AddEntity(parametros);
            }
            else
            {
                return ServiciosDataMapper.UpdateEntity(parametros);
            }
        }
    }
}