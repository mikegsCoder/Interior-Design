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
                .OrderBy(m => m.Position)
                .ThenBy(m => m.FirstName)
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

        public async Task EditTeamMemeberAsync(OurTeamViewModel model)
        {
            var member = await _team.All()
                .Where(m => m.Id == model.MemberId)
                .FirstOrDefaultAsync();

            member.Position = model.Position;
            member.ImageUrl = model.ImageUrl;
            member.TwitterUrl = model.TwitterUrl;
            member.FacebookUrl = model.FacebookUrl;
            member.GooglePlusUrl = model.GooglePlusUrl;
            member.LinkedInUrl = model.LinkedInUrl;

            _team.Update(member);

            await _team.SaveChangesAsync();
        }
    }
}
