namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;
    using System;

    /// <summary>
    /// Clase BalanceBL.
    /// </summary>
    public class BalanceBL
    {
        private BalanceDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceBL"/> class.
        /// </summary>
        public BalanceBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Balance> GetAll()
        {
            return this.mapper.GetAll<Balance>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Balance> GetId(int id)
        {
            return this.mapper.GetId<Balance>(id);
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
                return this.mapper.AddEntity(parametros);
            }
            else
            {
                return this.mapper.UpdateEntity(parametros);
            }
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="ano">Año.</param>
        /// <returns>Lista de categorias.</returns>
        public List<Balance> GetAllByYear(int ano)
        {
            return this.mapper.GetAll<Balance>(ano);
        }
    }
}