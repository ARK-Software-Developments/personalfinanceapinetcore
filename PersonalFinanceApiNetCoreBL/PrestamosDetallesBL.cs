namespace PersonalFinanceApiNetCoreBL
{
    using System.Collections.Generic;
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PrestamosDetallesBL.
    /// </summary>
    public class PrestamosDetallesBL
    {
        private PrestamosDetallesDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamosDetallesBL"/> class.
        /// </summary>
        public PrestamosDetallesBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<PrestamoDetalle> GetAll()
        {
            return this.mapper.GetAll<PrestamoDetalle>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<PrestamoDetalle> GetId(int id)
        {
            return this.mapper.GetId<PrestamoDetalle>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            List<object> response = [];
            object id = 0;

            switch (operacion)
            {
                case "create":
                    id = this.mapper.AddEntity(parametros);
                    break;

                case "update":
                    id = this.mapper.UpdateEntity(parametros);
                    break;
            }

            response.Add(id);

            return response;
        }
    }
}