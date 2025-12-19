namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase TransaccionesDataMapper.
    /// </summary>
    public class TransaccionesDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransaccionesDataMapper"/> class.
        /// </summary>
        public TransaccionesDataMapper()
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
            var lstEntidades = new List<Transaccion>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spTransactionsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Transaccion>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Transaccion>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pId",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spTransactionsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Transaccion>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spTransactionsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spTransactionsUpdate", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntityCreditCardsPending(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spTransactionsUpdateCreditCardsPendingId", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Transaccion MapperData(MySqlDataReader mySqlDataReader)
        {
            Transaccion entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                CodigoTransaccion = mySqlDataReader["transactioncode"].ToString(),
                OrdenCompra = mySqlDataReader["purchaseorder"].ToString(),
                EntidadAsociada = mySqlDataReader["associatedentity"].ToString(),
                FechaTransaccion = (DateTime)mySqlDataReader["transactiondate"],
                Resumen = mySqlDataReader["summary"].ToString(),
                Observaciones = mySqlDataReader["observations"].ToString(),
                TarjetaConsumoId = mySqlDataReader["creditcardspendingid"] != DBNull.Value ? Convert.ToInt32(mySqlDataReader["creditcardspendingid"]) : 0,
                Tarjeta = new Tarjeta
                {
                    Id = Convert.ToInt32(mySqlDataReader["cardsid"]),
                    Nombre = mySqlDataReader["cardname"].ToString(),
                    FechaCierre = (DateTime)mySqlDataReader["closingdate"],
                    FechaVencimiento = (DateTime)mySqlDataReader["expirationdate"],
                    Entidad = new ()
                    {
                        Id = Convert.ToInt32(mySqlDataReader["entityid"]),
                        Nombre = mySqlDataReader["entity"].ToString(),
                        Tipo = mySqlDataReader["entitytype"].ToString(),
                    },
                    Activo = (bool)mySqlDataReader["active"],
                },
            };

            return entidad;
        }
    }
}