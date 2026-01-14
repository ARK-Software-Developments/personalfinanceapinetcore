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

        public List<TarjetaConsumoResumen> ObtenerResumenConsumosTarjetas(int ano)
        {
            var lstProcesos = new List<TarjetaConsumoResumen>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spCreditCardSpendingtGetResumen", parametros);

            while (mySqlDataReader.Read())
            {
                lstProcesos.Add(this.MapperDataConsumoTC(mySqlDataReader));
            }

            mysql.Close();

            return lstProcesos;
        }

        public List<Gasto> ObtenerPresupuesto(int ano, int cardid)
        {
            var lstProcesos = new List<Gasto>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
                new ()
                {
                    Nombre = "pCardId",
                    Valor = cardid,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spBillsGetProcess", parametros);

            while (mySqlDataReader.Read())
            {
                lstProcesos.Add(this.MapperDataPresupuesto(mySqlDataReader));
            }

            mysql.Close();

            return lstProcesos;
        }

        private TarjetaConsumoResumen MapperDataConsumoTC(MySqlDataReader mySqlDataReader)
        {
            TarjetaConsumoResumen tarjetaConsumoResumen = new ()
            {
                Id = (int)mySqlDataReader["id"],
                Enero = (decimal)mySqlDataReader["january"],
                Febrero = (decimal)mySqlDataReader["february"],
                Marzo = (decimal)mySqlDataReader["march"],
                Abril = (decimal)mySqlDataReader["april"],
                Mayo = (decimal)mySqlDataReader["may"],
                Junio = (decimal)mySqlDataReader["june"],
                Julio = (decimal)mySqlDataReader["july"],
                Agosto = (decimal)mySqlDataReader["august"],
                Septiembre = (decimal)mySqlDataReader["september"],
                Octubre = (decimal)mySqlDataReader["october"],
                Noviembre = (decimal)mySqlDataReader["november"],
                Diciembre = (decimal)mySqlDataReader["december"],
            };

            return tarjetaConsumoResumen;
        }

        private Gasto MapperDataPresupuesto(MySqlDataReader mySqlDataReader)
        {
            Gasto gasto = new ()
            {
                Id = (int)mySqlDataReader["id"],
                Enero = (decimal)mySqlDataReader["january"],
                Febrero = (decimal)mySqlDataReader["february"],
                Marzo = (decimal)mySqlDataReader["march"],
                Abril = (decimal)mySqlDataReader["april"],
                Mayo = (decimal)mySqlDataReader["may"],
                Junio = (decimal)mySqlDataReader["june"],
                Julio = (decimal)mySqlDataReader["july"],
                Agosto = (decimal)mySqlDataReader["august"],
                Septiembre = (decimal)mySqlDataReader["september"],
                Octubre = (decimal)mySqlDataReader["october"],
                Noviembre = (decimal)mySqlDataReader["november"],
                Diciembre = (decimal)mySqlDataReader["december"],
            };

            return gasto;
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