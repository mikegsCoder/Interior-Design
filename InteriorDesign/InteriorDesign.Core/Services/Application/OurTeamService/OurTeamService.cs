using InteriorDesign.Core.ViewModels.OurTeamViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.OurTeamService
{
    public class OurTeamService : IOurTeamService
    {
        private readonly IDeletableEntityRepository<TeamMember> _team;

        public OurTeamService(IDeletableEntityRepository<TeamMember> team)
        {
            _team = team;
        }
 
        public async Task<IEnumerable<OurTeamViewModel>> GetTeamAsync()
        {
            return await _team.AllAsNoTracking()
                .Select(m => new OurTeamViewModel()
                {
                    MemberId = m.Id,
                    Name = m.FirstName + " " + m.LastName,
                    Position = m.Position,
                    ImageUrl = m.ImageUrl,
                    TwitterUrl = m.TwitterUrl,
                    FacebookUrl = m.FacebookUrl,
                    GooglePlusUrl = m.GooglePlusUrl,
                    LinkedInUrl = m.LinkedInUrl
                })
                .ToListAsync();
        }

        public async Task<OurTeamViewModel> GetMemberByIdAsync(string memberId)
        {
            return await _team.AllAsNoTracking()
                .Where(m => m.Id == memberId)
                .Select(m => new OurTeamViewModel()
                {
                    MemberId = m.Id,
                    Name = m.FirstName + " " + m.LastName,
                    Position = m.Position,
                    ImageUrl = m.ImageUrl,
                    TwitterUrl = m.TwitterUrl,
                    FacebookUrl = m.FacebookUrl,
                    GooglePlusUrl = m.GooglePlusUrl,
                    LinkedInUrl = m.LinkedInUrl
                })
                .FirstOrDefaultAsync();
        }
    }
}
