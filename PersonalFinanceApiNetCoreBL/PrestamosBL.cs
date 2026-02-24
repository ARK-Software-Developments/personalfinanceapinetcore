namespace PersonalFinanceApiNetCoreBL
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Clase PrestamosBL.
    /// </summary>
    public class PrestamosBL
    {
        private PrestamosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamosBL"/> class.
        /// </summary>
        public PrestamosBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Prestamo> GetAll()
        {
            return this.mapper.GetAll<Prestamo>();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Prestamo> GetId(int id)
        {
            return this.mapper.GetId<Prestamo>(id);
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

            decimal montoCuota = decimal.Parse(parametros.Find(p => p.Nombre == "inFirstInstallmentAmount").Valor.ToString().Replace(".", ","));
            DateTime fechaDeposito = DateTime.ParseExact(parametros.Find(p => p.Nombre == "inDepositDate").Valor.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string? s = parametros.Find(p => p.Nombre == "inNumberOfInstallments").Valor.ToString();
            int cuotas = string.IsNullOrEmpty(s) ? 1 : int.Parse(s);

            switch (operacion)
            {
                case "create":
                    id = this.mapper.AddEntity(parametros);
                    break;

                case "update":
                    this.mapper.UpdateEntity(parametros);
                    id = parametros?.Find(p => p.Nombre == "inId").Valor.ToString();
                    break;
            }

            response.Add(id);

            int inLoansAssignedId = int.Parse(id.ToString());

            var prestamoDetalleMapper = new PrestamosDetallesDataMapper();
            var tieneDetalle = prestamoDetalleMapper.GetId<PrestamoDetalle>(inLoansAssignedId);

            var tareas = new List<Task>();

            if (tieneDetalle != null && tieneDetalle.Count == 0)
            {
                List<Parametro> parametrosDetalle = [];
                var inExpirationDate = fechaDeposito.AddMonths(1);

                for (int i = 1; i <= cuotas; i++)
                {
                    if (i > 1)
                    {
                        inExpirationDate = inExpirationDate.AddMonths(1);
                    }

                    parametrosDetalle =
                    [
                        new ()
                            {
                                Nombre = "inLoansAssignedId",
                                Valor = inLoansAssignedId,
                            },
                            new ()
                            {
                                Nombre = "inNumberInstallment",
                                Valor = i,
                            },
                            new ()
                            {
                                Nombre = "inFeeAmount",
                                Valor = montoCuota,
                            },
                            new ()
                            {
                                Nombre = "inPaymentDate",
                                Valor = DateTime.Now,
                            },
                            new ()
                            {
                                Nombre = "inExpirationDate",
                                Valor = inExpirationDate.ToString("yyyy-MM-dd"),
                            },
                            new ()
                            {
                                Nombre = "inProofOfPayment",
                                Valor = string.Empty,
                            },
                            new ()
                            {
                                Nombre = "inPaymentMethod",
                                Valor = string.Empty,
                            },
                            new ()
                            {
                                Nombre = "inStatus",
                                Valor = "PENDIENTE",
                            },
                            new ()
                            {
                                Nombre = "inObservations",
                                Valor = $"DETALLE AUTOMATICO PARA CUOTA {i.ToString()}",
                            },
                        ];

                    tareas.Add(prestamoDetalleMapper.AddEntityAsync(parametrosDetalle));
                }
            }

            return response;
        }
    }
}