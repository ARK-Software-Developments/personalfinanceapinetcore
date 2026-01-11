namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase NotificacionesBL.
    /// </summary>
    public class NotificacionesBL
    {
        private NotificacionesDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificacionesBL"/> class.
        /// </summary>
        public NotificacionesBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Notificacion> GetAll()
        {
            return this.mapper.GetAll<Notificacion>();
        }
    }
}