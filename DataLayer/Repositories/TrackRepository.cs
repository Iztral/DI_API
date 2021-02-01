using DataLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AppDBContext _dbContext;

        public TrackRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Track>> GetAll()
        {
            return await _dbContext.Tracks.ToListAsync();
        }

        public async Task<Track> GetByID(int ID)
        {
            return await _dbContext.Tracks.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<bool> Add(Track newRecord)
        {
            await _dbContext.Tracks.AddAsync(newRecord);
            var created = await _dbContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> Update(Track record)
        {
            _dbContext.Tracks.Update(record);
            var updated =  await _dbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> Delete(int ID)
        {
            var trackToRemove = await _dbContext.Tracks.FirstOrDefaultAsync(x => x.ID == ID);
            _dbContext.Tracks.Remove(trackToRemove);
            var deleted = await _dbContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
