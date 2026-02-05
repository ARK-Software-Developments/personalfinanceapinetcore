namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase InversionesElementosDataMapper.
    /// </summary>
    public class InversionesElementosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InversionesElementosDataMapper"/> class.
        /// </summary>
        public InversionesElementosDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int investmentId)
        {
            var lstEntidades = new List<InversionElemento>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "inInvestmentId",
                    Valor = investmentId,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spInvestmentsElementsGetAllByInvestmentsId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<InversionElemento>));
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<InversionElemento>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spInvestmentsElementsGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<InversionElemento>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<InversionElemento>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "inId",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spInvestmentsElementsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<InversionElemento>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spInvestmentsElementsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spInvestmentsElementsUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private InversionElemento MapperData(MySqlDataReader mySqlDataReader)
        {
            InversionElemento entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Cantidad = Convert.ToInt32(mySqlDataReader["quantity"]),
                FechaOperacion = mySqlDataReader["operationdate"] != DBNull.Value ? (DateTime)mySqlDataReader["operationdate"] : null,
                MontoInvertido = (decimal)mySqlDataReader["investmentamount"],
                Estado = mySqlDataReader["state"].ToString(),
                MontoImpuestos = (decimal)mySqlDataReader["taxamount"],
                MontoResultado = (decimal)mySqlDataReader["resultingamount"],
                MontoUnitario = (decimal)mySqlDataReader["unitamount"],
                NumeroOperacion = mySqlDataReader["operationnumber"].ToString(),
                Instrumento = new InversionInstrumento()
                {
                    Id = Convert.ToInt32(mySqlDataReader["investmenttypeid"]),
                    Codigo = mySqlDataReader["code"].ToString(),
                    Detalle = mySqlDataReader["detail"].ToString(),
                    Tipo = new InversionTipo()
                    {
                        Id = Convert.ToInt32(mySqlDataReader["investmenttypeid"]),
                        Nombre = mySqlDataReader["denomination"].ToString(),
                        Tipo = mySqlDataReader["type"].ToString(),
                    },
                },
                Inversion = new Inversion()
                {
                    Id = Convert.ToInt32(mySqlDataReader["id"]),
                },
            };

            return entidad;
        }
    }
}