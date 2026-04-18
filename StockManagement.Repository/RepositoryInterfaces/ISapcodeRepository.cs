using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface ISapcodeRepository
    {
        Sapcode? GetById(int id);
        IEnumerable<Sapcode> GetAll();
        void Add(Sapcode entity);
        void Update(Sapcode entity);
        void Delete(int id);
    }
}
