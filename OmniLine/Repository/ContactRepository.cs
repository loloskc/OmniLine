using OmniLine.Models;
using OmniLine.Interfaces;
using OmniLine.Data;
using Microsoft.EntityFrameworkCore;

namespace OmniLine.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Contact contact)
        {
            _context.Add(contact);
            return Save();
        }

        public bool Delete(Contact contact)
        {
            _context.Remove(contact);
            return Save();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.Include(c=>c.CounterAgent).ToListAsync();
        }

        public async Task<Contact> GetByCounterAgent(long counterAgentId)
        {
            return await _context.Contacts.Include(c => c.CounterAgent).FirstOrDefaultAsync(i => i.CounterAgentId == counterAgentId);
        }

        public async Task<int> GetCount()
        {
            return await _context.Contacts.CountAsync();
        }

        public async Task<Contact> GetById(long id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;

        }

        public bool Update(Contact contact)
        {
            _context.Update(contact);
            return Save();
        }
    }
}
