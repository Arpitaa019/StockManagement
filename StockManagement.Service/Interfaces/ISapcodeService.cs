using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface ISapcodeService
    {
        Sapcode? Get(int id);
        IEnumerable<Sapcode> GetAll();
        void Create(Sapcode entity);
        void Update(Sapcode entity);
        void Delete(int id);
    }
}
