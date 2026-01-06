namespace PersonalFinanceApiNetCoreBL.Procesos
{
    using PersonalFinanceApiNetCoreDataMapper.Procesos;
    using PersonalFinanceApiNetCoreModel;

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
    }
}