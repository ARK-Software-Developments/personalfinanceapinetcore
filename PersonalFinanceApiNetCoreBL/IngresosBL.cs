namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreBL.Procesos;
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase IngresosBL.
    /// </summary>
    public class IngresosBL
    {
        private IngresoDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngresosBL"/> class.
        /// </summary>
        public IngresosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Ingreso> GetAll()
        {
            return this.mapper.GetAll<Ingreso>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Ingreso> GetId(int id)
        {
            return this.mapper.GetId<Ingreso>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
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

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> CopyMonthIncome(List<Parametro> parametros)
        {
            return [
                   this.mapper.CopyMonthIncome(parametros),
                    ];
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> UpdateBalanceMensual(List<Parametro> parametros)
        {
            int ano = int.Parse(parametros.Find(x => x.Nombre == "pYear").Valor.ToString());
            int mes = 0;

            for (int i = 1; i <= 12; i++)
            {
                mes = i;

                parametros =
                [
                    new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
                new ()
                {
                    Nombre = "pMonth",
                    Valor = mes,
                },
            ];

                new ProcesoBalanceBL().IniciarProcesoUpdateBalanceIngreso(parametros);
            }

            return [ true ];
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="ano">Año.</param>
        /// <returns>Lista de categorias.</returns>
        public List<Ingreso> GetAllByYear(int ano)
        {
            return this.mapper.GetAll<Ingreso>(ano);
        }
    }
}