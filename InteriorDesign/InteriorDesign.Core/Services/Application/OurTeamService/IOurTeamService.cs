using InteriorDesign.Core.ViewModels.OurTeamViewModels;

namespace InteriorDesign.Core.Services.Application.OurTeamService
{
    public interface IOurTeamService
    {
        Task<IEnumerable<OurTeamViewModel>> GetTeamAsync();
    }
}
