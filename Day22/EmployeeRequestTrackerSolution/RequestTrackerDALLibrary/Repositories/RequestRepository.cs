using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Repositories
{

    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }


        public async Task<Request> Add(Request entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<Request> DeleteByKey(int key)
        {
            Request item = await GetByKey(key);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();

            }
            return item;
        }

        public async Task<Request> GetByKey(int key)
        {
            Request item = await _context.Requests.FirstOrDefaultAsync(e => e.RequestNumber == key);
            return item;

        }

        public async Task<List<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            Request item = await GetByKey(entity.RequestNumber);
            if (item != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }

    }
}
