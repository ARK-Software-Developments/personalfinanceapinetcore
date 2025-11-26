
namespace PersonalFinanceApiNetCoreModel.Interfaces
{
    /// <summary>
    /// Interfcae IDataMapper.
    /// </summary>
    public interface IDataMapper
    {
        public List<T> GetAll<T>();

        public List<T> GetAll<T>(int ano);

        public List<T> GetId<T>(int id);

        public long AddEntity(List<Parametro> parametros);

        public long UpdateEntity(List<Parametro> parametros);
    }
}