using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IIMIRCumulativeService
    {
        IMIRCumulative? Get(int id);
        IEnumerable<IMIRCumulative> GetAll();
        void Create(IMIRCumulative entity);
        void Update(IMIRCumulative entity);
        void Delete(int id);
    }
}
