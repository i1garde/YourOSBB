using AutoMapper;
using YourOSBB.Entities;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Models.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<ApplicationUser, ApplicationUserViewModel>();
        this.CreateMap<ApplicationUserViewModel, ApplicationUser>();
        this.CreateMap<Osbb, OsbbViewModel>();
        this.CreateMap<OsbbViewModel, Osbb>();
        this.CreateMap<Announcement, AnnouncementViewModel>();
        this.CreateMap<AnnouncementViewModel, Announcement>();
        this.CreateMap<Proposal, ProposalViewModel>();
        this.CreateMap<ProposalViewModel, Proposal>();
        this.CreateMap<Complaint, ComplaintViewModel>();
        this.CreateMap<ComplaintViewModel, Complaint>();
        this.CreateMap<Tariff, TariffViewModel>();
        this.CreateMap<TariffViewModel, Tariff>();
    }
}