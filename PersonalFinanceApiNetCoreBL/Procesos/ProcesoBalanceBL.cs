namespace PersonalFinanceApiNetCoreBL.Procesos
{
    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreDataMapper.Procesos;
    using PersonalFinanceApiNetCoreModel;
    using System.Diagnostics;

    /// <summary>
    /// Clase ProcesoBalanceBL.
    /// </summary>
    public class ProcesoBalanceBL
    {
        private ProcesosPagosDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcesoBalanceBL"/> class.
        /// </summary>
        public ProcesoBalanceBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="ano">Año.</param>
        public void IniciarProcesoPagos(int ano)
        {
            var lstProcesosPagos = this.mapper.ObtenerProcesosPagos(ano);

            if (lstProcesosPagos.Count > 0)
            {
                foreach (var p in lstProcesosPagos)
                {
                    this.mapper.RegistrarPago(p, ano);
                }
            }
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="parametros">Parametros.</param>
        public void IniciarProcesoGM(List<Parametro>? parametros)
        {
            EventLog.WriteEntry("Application", "Inicio de IniciarProcesoGM", EventLogEntryType.Information);

            try
            {
                int ano = int.Parse(parametros.Find(p => p.Nombre == "pYear").Valor.ToString());
                int pMonth = int.Parse(parametros.Find(p => p.Nombre == "pMonth").Valor.ToString());

                EventLog.WriteEntry("Application", $"Año: {ano}, Mes: {pMonth}.", EventLogEntryType.Information);

                var lstProcesos = this.mapper.ObtenerResumenConsumosTarjetas(ano);

                EventLog.WriteEntry("Application", $"ObtenerResumenConsumosTarjetas: {lstProcesos.Count}.", EventLogEntryType.Information);

                if (lstProcesos.Count > 0)
                {
                    foreach (var p in lstProcesos)
                    {
                        var presupuesto = this.mapper.ObtenerPresupuesto(ano, p.Id);
                        decimal pAmount = 0;

                        switch (pMonth)
                        {
                            case 1: pAmount = presupuesto[0].Enero; break;
                            case 2: pAmount = presupuesto[0].Febrero; break;
                            case 3: pAmount = presupuesto[0].Marzo; break;
                            case 4: pAmount = presupuesto[0].Abril; break;
                            case 5: pAmount = presupuesto[0].Mayo; break;
                            case 6: pAmount = presupuesto[0].Junio; break;
                            case 7: pAmount = presupuesto[0].Julio; break;
                            case 8: pAmount = presupuesto[0].Agosto; break;
                            case 9: pAmount = presupuesto[0].Septiembre; break;
                            case 10: pAmount = presupuesto[0].Octubre; break;
                            case 11: pAmount = presupuesto[0].Noviembre; break;
                            case 12: pAmount = presupuesto[0].Diciembre; break;
                        }

                        List<Parametro> parameter =
                        [
                            new ()
                        {
                            Nombre = "pId",
                            Valor = presupuesto[0].Id,
                        },
                        new ()
                        {
                            Nombre = "pMonth",
                            Valor = pMonth,
                        },
                        new ()
                        {
                            Nombre = "pAmount",
                            Valor = pAmount,
                        },
                    ];

                        var result = new GastosDataMapper().UpdateByMonth(parameter);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
        }

        public void IniciarProcesoUpdateBalance(List<Parametro>? parametros)
        {
            try
            {
                var result = new GastosDataMapper().BalanceUpdateProcessBills(parametros);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
        }

        public void IniciarProcesoUpdateBalanceIngreso(List<Parametro>? parametros)
        {
            try
            {
                var result = new IngresoDataMapper().BalanceUpdateProcessIncome(parametros);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }
        }

        public void IniciarProcesoVRP(List<Parametro> parametros)
        {
            try
            {
                var result = new GastosDataMapper().ProcesoVRP(parametros);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("PersonalFinance", ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}