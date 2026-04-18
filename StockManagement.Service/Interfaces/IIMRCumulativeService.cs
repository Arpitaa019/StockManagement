using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IIMRCumulativeService
    {
        IMRCumulative? Get(int id);
        IEnumerable<IMRCumulative> GetAll();
        void Create(IMRCumulative entity);
        void Update(IMRCumulative entity);
        void Delete(int id);
    }
}
