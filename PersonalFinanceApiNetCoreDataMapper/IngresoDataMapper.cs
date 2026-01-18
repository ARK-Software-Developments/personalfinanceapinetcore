namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase IngresoDataMapper.
    /// </summary>
    public class IngresoDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IngresoDataMapper"/> class.
        /// </summary>
        public IngresoDataMapper()
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
            var lstEntidades = new List<Ingreso>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spIncomeGetAll", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Ingreso>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Ingreso>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spIncomeGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Ingreso>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spIncomeAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spIncomeUpdate", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long CopyMonthIncome(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().ExecuteSP("spIncomeCopyMonth", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Ingreso MapperData(MySqlDataReader mySqlDataReader)
        {
            Ingreso entidad = new ()
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
                Detalle = new IngresoDetalle()
                {
                    Id = (int)mySqlDataReader["incomedetailsid"],
                    Codigo = (int)mySqlDataReader["code"],
                    Detalle = mySqlDataReader["detail"].ToString(),
                },
            };

            return entidad;
        }
    }
}