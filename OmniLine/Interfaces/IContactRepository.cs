using OmniLine.Models;

namespace OmniLine.Interfaces
{
    public interface IContactRepository
    {
        bool Add(Contact contact);
        bool Delete(Contact contact);
        bool Update(Contact contact);
        bool Save();
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetId(long id);
        Task<Contact> GetByCounterAgent(long counterAgentId);
        Task<int> GetCount();


    }
}
