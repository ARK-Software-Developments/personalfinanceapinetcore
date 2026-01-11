namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase PagosBL.
    /// </summary>
    public class PagosBL
    {
        private PagosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagosBL"/> class.
        /// </summary>
        public PagosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Pago> GetAll()
        {
            return this.mapper.GetAll<Pago>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Pago> GetId(int id)
        {
            return this.mapper.GetId<Pago>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public List<object> AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            object result = 0;

            switch (operacion)
            {
                case "create":
                    result = this.mapper.AddEntity(parametros);
                    break;

                case "update":
                    result = this.mapper.UpdateEntity(parametros);
                    break;
            }

            this.RecordPayment(parametros);

            return [ result ];
        }

        /// <summary>
        /// Método automatico de calcular el egreso en balance.
        /// </summary>
        /// <param name="parametros">List de Parametro.</param>
        private void RecordPayment(List<Parametro> parametros)
        {
            if (parametros == null || parametros.Count == 0)
            {
                return;
            }

            var pDateOfPayment = parametros.Find(p => p.Nombre == "pDateOfPayment").Valor.ToString();

            if (!string.IsNullOrEmpty(pDateOfPayment))
            {
                int yearPaytment = DateTime.Parse(pDateOfPayment).Year;
                int monthPaytment = DateTime.Parse(pDateOfPayment).Month;

                parametros =
                [
                    new ()
                {
                    Nombre = "pYear",
                    Valor = yearPaytment,
                },
                new ()
                {
                    Nombre = "pMonth",
                    Valor = monthPaytment,
                },
            ];

                this.mapper.RegisterPaymentInBalance(parametros);
            }
        }
    }
}