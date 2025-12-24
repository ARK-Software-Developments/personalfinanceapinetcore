namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase BalanceDataMapper.
    /// </summary>
    public class BalanceDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceDataMapper"/> class.
        /// </summary>
        public BalanceDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>()
        {
            var lstEntidades = new List<Balance>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spBalanceGetAll");

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Balance>));
        }

        /// <summary>
        /// Metodo para obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="ano">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetAll<T>(int ano)
        {
            var lstEntidades = new List<Balance>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pYear",
                    Valor = ano,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spBalanceGetAll", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Balance>));
        }

        /// <summary>
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Balance>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spBalanceGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Balance>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spBalanceAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spBalanceUpdate", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Balance MapperData(MySqlDataReader mySqlDataReader)
        {
            Balance entidad = new ()
            {
                Id = Convert.ToInt32(mySqlDataReader["id"]),
                Concepto = mySqlDataReader["concept"].ToString(),
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
            };

            return entidad;
        }
    }
}