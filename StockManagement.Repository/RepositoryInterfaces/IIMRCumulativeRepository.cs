using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IIMIRCumulativeRepository
    {
        IMIRCumulative? GetById(int id);
        IEnumerable<IMIRCumulative> GetAll();
        void Add(IMIRCumulative entity);
        void Update(IMIRCumulative entity);
        void Delete(int id);
    }
}
