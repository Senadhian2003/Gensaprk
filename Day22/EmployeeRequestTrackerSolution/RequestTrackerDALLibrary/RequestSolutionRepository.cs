using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }


        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<Request> DeleteByKey(int key)
        {
            Request emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }

        public async Task<Request> GetByKey(int key)
        {
            Request emp = await _context.Requests.FirstOrDefaultAsync(e => e.RequestNumber == key);
            return emp;

        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            Request emp = await GetByKey(entity.RequestNumber);
            if (emp != null)
            {
                _context.Update(entity);
                _context.SaveChanges();

            }

            return emp;

        }

    }
}
