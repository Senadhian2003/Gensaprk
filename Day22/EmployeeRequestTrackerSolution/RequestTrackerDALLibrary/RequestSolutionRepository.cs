using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary.Interface;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }


        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<RequestSolution> DeleteByKey(int key)
        {
            RequestSolution emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }

        public async Task<RequestSolution> GetByKey(int key)
        {
            RequestSolution emp = await _context.RequestSolutions.Include(e => e.Feedbacks).FirstOrDefaultAsync(e => e.SolutionId == key); ;
            return emp;

        }

        public async Task<List<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            RequestSolution emp = await GetByKey(entity.SolutionId);
            if (emp != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }

    }
}
