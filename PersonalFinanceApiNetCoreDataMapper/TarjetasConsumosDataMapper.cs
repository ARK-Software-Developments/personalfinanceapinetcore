namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CA1822
#pragma warning disable CS8601
#pragma warning disable CS8618
#pragma warning disable SA1623

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase TarjetasConsumosDataMapper.
    /// </summary>
    public class TarjetasConsumosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetasConsumosDataMapper"/> class.
        /// </summary>
        public TarjetasConsumosDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="ano">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>(int ano)
        {
            var lstEntidades = new List<TarjetaConsumo>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spCreditCardSpendingtGetAll", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<TarjetaConsumo>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<TarjetaConsumo>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spCreditCardSpendingtGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<TarjetaConsumo>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spCreditCardSpendingtAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCreditCardSpendingtUpdate", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateTransId(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spCreditCardSpendingtUpdateTransId", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private TarjetaConsumo MapperData(MySqlDataReader mySqlDataReader)
        {
            TarjetaConsumo entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
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
                Ano = (int)mySqlDataReader["year"],
                Detalle = mySqlDataReader["details"].ToString(),
                Cuotas = mySqlDataReader["numberinstallments"] == DBNull.Value ? 0 : (int)mySqlDataReader["numberinstallments"],
                Verificado = (bool)mySqlDataReader["verified"],
                Pagado = (bool)mySqlDataReader["paid"],
                Tarjeta = mySqlDataReader["cardsid"] == DBNull.Value ? null :
                new Tarjeta()
                {
                    Id = (int)mySqlDataReader["cardsid"],
                    Nombre = mySqlDataReader["cardname"].ToString(),
                },
                EntidadCompra = mySqlDataReader["purchasingentity"].ToString(),
                TransaccionesAsociadas = Convert.ToInt32(mySqlDataReader["transaccionesasociada"]),
            };

            return entidad;
        }
    }
}