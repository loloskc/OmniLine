using OmniLine.Models;

namespace OmniLine.Interfaces
{
    public interface ICounterAgentRepository
    {
        bool Add(CounterAgent agent);
        bool Delete(CounterAgent agent);
        bool Update(CounterAgent agent);
        bool Save();
        Task<IEnumerable<CounterAgent>> GetAll();
        Task<CounterAgent> GetById(int id);
        Task<int> GetCount();
        
    }
}
