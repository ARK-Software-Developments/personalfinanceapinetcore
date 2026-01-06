namespace PersonalFinanceApiNetCoreDataMapper.Procesos
{
    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase ProcesosPagosDataMapper.
    /// </summary>
    public class ProcesosPagosDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcesosPagosDataMapper"/> class.
        /// </summary>
        public ProcesosPagosDataMapper()
        {
        }

        public List<ProcesoPagos> ObtenerProcesosPagos(int ano)
        {
            var lstProcesos = new List<ProcesoPagos>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spPaymentsGetAllResume", parametros);

            while (mySqlDataReader.Read())
            {
                lstProcesos.Add(MapperData(mySqlDataReader));
            }

            mysql.Close();

            return lstProcesos;
        }

        public void RegistrarPago(ProcesoPagos procesoPagos, int ano)
        {
            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "ptipoGasto",
                    Valor = procesoPagos.TipoGasto,
                },
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
                new ()
                {
                    Nombre = "pMonth",
                    Valor = procesoPagos.NombreMes,
                },
                new ()
                {
                    Nombre = "pTotal",
                    Valor = procesoPagos.Total,
                },
            ];

            var result = new MySQLConnectionDM().Update("spBalanceUpdateProcess", parametros);
        }

        private ProcesoPagos MapperData(MySqlDataReader mySqlDataReader)
        {
            ProcesoPagos entidad = new ()
            {
                TipoGasto = Convert.ToInt32(mySqlDataReader["tipogasto"]),
                Mes = Convert.ToInt32(mySqlDataReader["mes"]),
                NombreMes = mySqlDataReader["mesnombre"].ToString(),
                Total = (decimal)mySqlDataReader["total"],
            };

            return entidad;
        }
    }
}