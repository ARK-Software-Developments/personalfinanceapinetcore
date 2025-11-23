using PersonalFinanceApiNetCoreModel;
using System.Reflection.PortableExecutable;

namespace PersonalFinanceApiNetCoreDataMapper
{
    /// <summary>
    /// Clase EntidadesDataMapper.
    /// </summary>
    public class EntidadesDataMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntidadesDataMapper"/> class.
        /// </summary>
        public EntidadesDataMapper()
        {
        }

        /// <summary>
        /// Metodo para obtener todos los registros de entidades.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public static List<Entidad> GetAll()
        {
            var lstEntidades = new List<Entidad>();

            var mysql = new MySQLConnectionDM();

            var mySqlDataReader = mysql.GetDataReader("spEntitiesGetAll");

            Entidad entidad = new Entidad();
            while (mySqlDataReader.Read())
            {
                entidad.Id = Convert.ToInt32(mySqlDataReader["id"]);
                entidad.Nombre = mySqlDataReader["entity"].ToString();
                entidad.Tipo = mySqlDataReader["entitytype"].ToString();
                lstEntidades.Add(entidad);
                entidad = new Entidad();
            }

            return lstEntidades;
        }

        /// <summary>
        /// Metodo para obtener un registro de entidades.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entidades.</returns>
        public static List<Entidad> GetId(int id)
        {
            var lstEntidades = new List<Entidad>();

            var mysql = new MySQLConnectionDM();

            List<Parametro> parametros =
            [
                new ()
                {
                    Nombre = "pid",
                    Valor = id,
                },
            ];

            var mySqlDataReader = mysql.GetDataReader("spEntitiesGetId", parametros);

            Entidad entidad = new Entidad();
            while (mySqlDataReader.Read())
            {
                entidad.Id = Convert.ToInt32(mySqlDataReader["id"]);
                entidad.Nombre = mySqlDataReader["entity"].ToString();
                entidad.Tipo = mySqlDataReader["entitytype"].ToString();
                lstEntidades.Add(entidad);
                entidad = new Entidad();
            }

            return lstEntidades;
        }
    }
}