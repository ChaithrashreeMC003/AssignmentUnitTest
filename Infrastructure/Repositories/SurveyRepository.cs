using Domain.Entities;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _context;

        public SurveyRepository(SurveyDbContext context)
        {
            _context = context;
        }

        public async Task<Survey?> GetByIdAsync(Guid id)
        {
            return await _context.Surveys
                .Include(s => s.Questions)
                .FirstOrDefaultAsync(s => s.SurveyId == id);
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task AddAsync(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Survey survey)
        {
            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var survey = await _context.Surveys
                .Include(s => s.Questions) // load related questions
                .FirstOrDefaultAsync(s => s.SurveyId == id);

            if (survey != null)
            {
                // Remove related questions first
                _context.Questions.RemoveRange(survey.Questions);

                // Remove survey
                _context.Surveys.Remove(survey);

                await _context.SaveChangesAsync();
            }
        }
    }
}