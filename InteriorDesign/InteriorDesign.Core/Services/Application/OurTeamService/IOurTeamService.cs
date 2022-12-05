using InteriorDesign.Core.ViewModels.OurTeamViewModels;

namespace InteriorDesign.Core.Services.Application.OurTeamService
{
    public interface IOurTeamService
    {
        Task<IEnumerable<OurTeamViewModel>> GetTeamAsync();

        Task<OurTeamViewModel> GetMemberByIdAsync(string memberId);

        Task EditTeamMemeberAsync(OurTeamViewModel model);
    }
}
