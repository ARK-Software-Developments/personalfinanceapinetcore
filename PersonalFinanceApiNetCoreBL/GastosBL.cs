namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreBL.Procesos;
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;
    using System;

    /// <summary>
    /// Clase GastosBL.
    /// </summary>
    public class GastosBL
    {
        private GastosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GastosBL"/> class.
        /// </summary>
        public GastosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Gasto> GetAll()
        {
            return this.mapper.GetAll<Gasto>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Gasto> GetId(int id)
        {
            return this.mapper.GetId<Gasto>(id);
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
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <param name="ano">Año.</param>
        /// <returns>Lista de categorias.</returns>
        public List<Gasto> GetAllByYear(int ano)
        {
            return this.mapper.GetAll<Gasto>(ano);
        }

        /// <summary>
        /// Proceso de copiar prespuesto mensual.
        /// </summary>
        /// <param name="parametros">Lista de Parametro.</param>
        /// <returns>Lista de Objetos.</returns>
        public List<object> BillsCopyMonth(List<Parametro> parametros)
        {
            this.mapper.BillsCopyMonth(parametros);

            int ano = int.Parse(parametros.Find(x => x.Nombre == "pYearTo").Valor.ToString());

            int mes = int.Parse(parametros.Find(x => x.Nombre == "pMonthTo").Valor.ToString());

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

            new ProcesoBalanceBL().IniciarProcesoUpdateBalance(parametros);

            return [
                  true,
                    ];
        }
    }
}