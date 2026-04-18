using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IIMRCumulativeRepository
    {
        IMRCumulative? GetById(int id);
        IEnumerable<IMRCumulative> GetAll();
        void Add(IMRCumulative entity);
        void Update(IMRCumulative entity);
        void Delete(int id);
    }
}
