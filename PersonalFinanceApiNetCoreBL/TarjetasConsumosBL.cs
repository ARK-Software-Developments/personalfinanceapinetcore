namespace PersonalFinanceApiNetCoreBL
{
#pragma warning disable IDE0079 // Quitar supresión innecesaria
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly

    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase TarjetasConsumosBL.
    /// </summary>
    public class TarjetasConsumosBL
    {
        private TarjetasConsumosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetasConsumosBL"/> class.
        /// </summary>
        public TarjetasConsumosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<TarjetaConsumo> GetAll()
        {
            return this.mapper.GetAll<TarjetaConsumo>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<TarjetaConsumo> GetId(int id)
        {
            return this.mapper.GetId<TarjetaConsumo>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            return operacion switch
            {
                "create" => [
                    this.mapper.AddEntity(parametros),
                    ],
                "update" => [
                    this.mapper.UpdateEntity(parametros),
                    ],
                "updatetransid" => [
                    this.mapper.UpdateTransId(parametros),
                    ],
                _ => [],
            };
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="ano">Año.</param>
        /// <returns>Lista de categorias.</returns>
        public List<TarjetaConsumo> GetAllByYear(int ano)
        {
            return this.mapper.GetAll<TarjetaConsumo>(ano);
        }
    }
}