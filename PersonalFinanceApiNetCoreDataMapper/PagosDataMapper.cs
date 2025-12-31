namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CS8601 // Posible asignación de referencia nula
#pragma warning disable CA1822 // Marcar miembros como static

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase PagosDataMapper.
    /// </summary>
    public class PagosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagosDataMapper"/> class.
        /// </summary>
        public PagosDataMapper()
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
            var lstEntidades = new List<Pago>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spPaymentsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Pago>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Pago>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spPaymentsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Pago>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spPaymentsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spPaymentsUpdate", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long RegisterPayment(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spBillsUpdateByPayment", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Pago MapperData(MySqlDataReader mySqlDataReader)
        {
            Pago entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                FechaPago = mySqlDataReader["dateofpayment"] != DBNull.Value ? (DateTime)mySqlDataReader["dateofpayment"] : null,
                FechaRegistro = mySqlDataReader["registrationdate"] != DBNull.Value ? (DateTime)mySqlDataReader["registrationdate"] : null,
                CodigoRegistro = mySqlDataReader["registrationcode"].ToString(),
                MontoPagado = (decimal)mySqlDataReader["amountpaid"],
                MontoPresupuestado = (decimal)mySqlDataReader["budgetedamount"],
                RecursoDelPago = mySqlDataReader["paymentresourceid"] == DBNull.Value ? null :
                new Entidad()
                {
                    Id = (int)mySqlDataReader["paymentresourceid"],
                    Nombre = mySqlDataReader["entity"].ToString(),
                    Tipo = mySqlDataReader["entitytype"].ToString(),
                },
                TipoDePago = mySqlDataReader["paymenttype"].ToString(),
                TipoDeGasto = mySqlDataReader["reasonforpayment"] == DBNull.Value ? null :
                new TipoGasto()
                {
                    Id = (int)mySqlDataReader["reasonforpayment"],
                    Tipo = mySqlDataReader["type"].ToString(),
                },
            };

            return entidad;
        }
    }
}