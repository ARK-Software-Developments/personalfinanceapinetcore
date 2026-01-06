namespace PersonalFinanceApiNetCoreBL
{
    using Google.Protobuf;
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;
    using System.Globalization;

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

            return [ result ];
        }

        private void RecordPayment(List<Parametro> parametros)
        {
            int currentYear = DateTime.Now.Year;
            int monthPaytment = DateTime.ParseExact(parametros.Find(p => p.Nombre == "pDateOfPayment").Valor.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture).Month;
            int typeOfExpenseId = int.Parse(parametros.Find(p => p.Nombre == "pReasonForPayment").Valor.ToString());
            decimal amount = decimal.Parse(parametros.Find(p => p.Nombre == "pAmountPaid").Valor.ToString(), CultureInfo.InvariantCulture);

            parametros =
            [
                new ()
                {
                    Nombre = "pTypeOfExpenseId",
                    Valor = typeOfExpenseId,
                },
                new ()
                {
                    Nombre = "pAmount",
                    Valor = amount,
                },
                new ()
                {
                    Nombre = "pMonth",
                    Valor = monthPaytment,
                },
                new ()
                {
                    Nombre = "pYear",
                    Valor = currentYear,
                },
            ];

            this.mapper.RegisterPayment(parametros);
        }
    }
}