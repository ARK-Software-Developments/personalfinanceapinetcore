namespace PersonalFinanceApiNetCoreDataMapper
{
#pragma warning disable CS8601 // Posible asignación de referencia nula
#pragma warning disable CA1822 // Marcar miembros como static

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase PrestamosDataMapper.
    /// </summary>
    public class PrestamosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamosDataMapper"/> class.
        /// </summary>
        public PrestamosDataMapper()
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
            var lstEntidades = new List<Prestamo>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spLoansAssignedGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Prestamo>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Prestamo>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spLoansAssignedGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades.FindAll(x => x.Id == id), typeof(List<Prestamo>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spLoansAssignedAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spLoansAssignedUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Prestamo MapperData(MySqlDataReader mySqlDataReader)
        {
            Prestamo entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Numero = mySqlDataReader["number"] != DBNull.Value ? mySqlDataReader["number"].ToString() : string.Empty,
                Beneficiario = mySqlDataReader["beneficiary"].ToString(),
                Cuotas = (int)mySqlDataReader["numberofinstallments"],
                FechaDeposito = mySqlDataReader["depositdate"] != DBNull.Value ? (DateTime)mySqlDataReader["depositdate"] : null,
                Razon = mySqlDataReader["reason"].ToString(),
                Resumen = mySqlDataReader["summary"].ToString(),
                TotalCapital = (decimal)mySqlDataReader["capitalamount"],
                TotalDeuda = (decimal)mySqlDataReader["totalamount"],
                MontoCuota = mySqlDataReader["firstinstallmentamount"] != DBNull.Value ? (decimal)mySqlDataReader["firstinstallmentamount"] : 0,
                CodigoTransaccion = mySqlDataReader["transactioncode"] != DBNull.Value ? mySqlDataReader["transactioncode"].ToString() : string.Empty,
                Estado = mySqlDataReader["state"].ToString(),
                Entidad = mySqlDataReader["entityid"] != DBNull.Value ?
                    new Entidad()
                    {
                        Id = Convert.ToInt32(mySqlDataReader["entityid"]),
                        Nombre = mySqlDataReader["entity"].ToString(),
                        Tipo = mySqlDataReader["entitytype"].ToString(),
                    }
                    : null,
                CantidadCuotas = int.Parse(mySqlDataReader["quantityinstallments"].ToString()),
            };

            return entidad;
        }
    }
}