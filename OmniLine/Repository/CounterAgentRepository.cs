using OmniLine.Data;
using OmniLine.Interfaces;
using OmniLine.Models;
using Microsoft.EntityFrameworkCore;

namespace OmniLine.Repository
{
    public class CounterAgentRepository : ICounterAgentRepository
    {
        private readonly ApplicationDbContext _context;

        public CounterAgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CounterAgent agent)
        {
            _context.Add(agent);
            return Save();
        }

        public bool Delete(CounterAgent agent)
        {
            _context.Remove(agent);
            return Save();
        }

        public async Task<IEnumerable<CounterAgent>> GetAll()
        {
            return await _context.CounterAgents.ToListAsync();
        }

        public async Task<CounterAgent> GetById(int id)
        {
            return await _context.CounterAgents.FirstOrDefaultAsync(i => i.CounterAgentId == id);
        }

        public async Task<int> GetCount()
        {
            return await _context.CounterAgents.CountAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(CounterAgent agent)
        {
            _context.Update(agent);
            return Save();
        }
    }
}
