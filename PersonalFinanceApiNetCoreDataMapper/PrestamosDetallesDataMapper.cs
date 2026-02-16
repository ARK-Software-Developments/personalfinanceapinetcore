namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CS8601 // Posible asignación de referencia nula
#pragma warning disable CA1822 // Marcar miembros como static

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase PrestamosDetallesDataMapper.
    /// </summary>
    public class PrestamosDetallesDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamosDetallesDataMapper"/> class.
        /// </summary>
        public PrestamosDetallesDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int ano)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<PrestamoDetalle>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spLoansAssignedDetailsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<PrestamoDetalle>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<PrestamoDetalle>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pLoansAssignedId",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spLoansAssignedDetailsGetByLoanId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<PrestamoDetalle>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spLoansAssignedDetailsAdd", parametros);
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo async.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Tasks.</returns>
        public Task<long> AddEntityAsync(List<Parametro> parametros)
        {
            return Task.Run(() =>
            {
                return new MySQLConnectionDM().Add("spLoansAssignedDetailsAdd", parametros);
            });
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spLoansAssignedDetailsUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private PrestamoDetalle MapperData(MySqlDataReader mySqlDataReader)
        {
            PrestamoDetalle entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Cuota = (int)mySqlDataReader["numberinstallment"],
                MontoCuota = mySqlDataReader["feeamount"] != DBNull.Value ? (decimal)mySqlDataReader["feeamount"] : 0,
                FechaPagado = mySqlDataReader["paymentdate"] != DBNull.Value ? (DateTime)mySqlDataReader["paymentdate"] : null,
                Estado = mySqlDataReader["status"].ToString(),
                PrestamoId = (int)mySqlDataReader["loansassignedid"],
                ComprobantePago = mySqlDataReader["proofofpayment"].ToString(),
                MetodoPago = mySqlDataReader["paymentmethod"].ToString(),
                Observaciones = mySqlDataReader["observations"].ToString(),
            };

            return entidad;
        }
    }
}