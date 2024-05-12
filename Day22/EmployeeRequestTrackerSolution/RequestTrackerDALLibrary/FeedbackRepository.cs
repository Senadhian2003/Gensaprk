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
    public class FeedbackRepository : IRepository<int, SolutionFeedback>
    {
        private readonly RequestTrackerContext _context;

        public FeedbackRepository(RequestTrackerContext context)
        {
            _context = context;

        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<SolutionFeedback> DeleteByKey(int key)
        {
            SolutionFeedback emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }

        public async Task<SolutionFeedback> GetByKey(int key)
        {
            SolutionFeedback emp = await _context.Feedbacks.FirstOrDefaultAsync(e => e.SolutionId == key);
            return emp;

        }

        public async Task<List<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            SolutionFeedback emp = await GetByKey(entity.FeedbackId);
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
