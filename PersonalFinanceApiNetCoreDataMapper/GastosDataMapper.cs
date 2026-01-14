namespace PersonalFinanceApiNetCoreDataMapper
{
#nullable disable
#pragma warning disable CA1822

    using MySql.Data.MySqlClient;
    using PersonalFinanceApiNetCoreModel;
    using PersonalFinanceApiNetCoreModel.Interfaces;

    /// <summary>
    /// Clase GastosDataMapper.
    /// </summary>
    public class GastosDataMapper : IDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GastosDataMapper"/> class.
        /// </summary>
        public GastosDataMapper()
        {
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(int ano)
        {
            var lstEntidades = new List<Gasto>();

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
                    Nombre = "pActive",
                    Valor = true,
                },

            ];

            var mySqlDataReader = mysql.GetDataReader("spBillsGetAll", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Gasto>));
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
        /// Metodo para obtener un registro.
        /// </summary>
        /// <typeparam name="T">Lista del tipo.</typeparam>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public List<T> GetId<T>(int id)
        {
            var lstEntidades = new List<Gasto>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pId",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spBillsGetId", parametros);

            while (mySqlDataReader.Read())
            {
                lstEntidades.Add(this.MapperData(mySqlDataReader));
            }

            mysql.Close();

            return (List<T>)Convert.ChangeType(lstEntidades, typeof(List<Gasto>));
        }

        /// <summary>
        /// Metodo para agregar un registro nuevo.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long AddEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Add("spBillsAdd", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateEntity(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spBillsUpdate", parametros);
        }

        /// <summary>
        /// Metodo para actualizar un registro.
        /// </summary>
        /// <param name="parametros">Id del registro.</param>
        /// <returns>Lista de categorias.</returns>
        public long UpdateByMonth(List<Parametro> parametros)
        {
            return new MySQLConnectionDM().Update("spBalanceUpdateProcessPostCreditCard", parametros);
        }

        /// <summary>
        /// Mapeo de registro.
        /// </summary>
        /// <param name="mySqlDataReader">MySqlDataReader.</param>
        /// <returns>Entidad respectiva.</returns>
        private Gasto MapperData(MySqlDataReader mySqlDataReader)
        {
            Gasto entidad = new ()
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
                Resumen = mySqlDataReader["summary"].ToString(),
                Observaciones = mySqlDataReader["observations"].ToString(),
                TipoGasto = new TipoGasto()
                {
                    Id = Convert.ToInt32(mySqlDataReader["typeofexpenseid"]),
                    Tipo = mySqlDataReader["type"].ToString(),
                    Categoria = new Categoria()
                    {
                        Id = Convert.ToInt32(mySqlDataReader["categoriesid"]),
                        Nombre = mySqlDataReader["category"].ToString(),
                    },
                },
                Villetera = new Entidad()
                {
                    Id = Convert.ToInt32(mySqlDataReader["wallet"]),
                    Nombre = mySqlDataReader["entity"].ToString(),
                    Tipo = mySqlDataReader["entitytype"].ToString(),
                },
                Verificado = (bool)mySqlDataReader["verified"],
                Reservado = (bool)mySqlDataReader["reserved"],
                Pagado = (bool)mySqlDataReader["paid"],
                Activo = (bool)mySqlDataReader["active"],
            };

            return entidad;
        }
    }
}