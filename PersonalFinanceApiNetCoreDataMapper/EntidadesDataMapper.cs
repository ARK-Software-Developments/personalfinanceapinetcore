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

        public static void GetAll()
        {
            var mysql = new MySQLConnectionDM();

            var dr = mysql.GetDataReader("spEntitiesGetAll");
        }
    }
}