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
    }
}