using AutoMapper;
using YourOSBB.Entities;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Web.Models.Entities;
using YourOSBB.Web.Models.Entities.VotingViewModels;

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
        this.CreateMap<Poll, PollViewModel>();
        this.CreateMap<PollViewModel, Poll>();
        this.CreateMap<PollCandidate, PollCandidateViewModel>();
        this.CreateMap<PollCandidateViewModel, PollCandidate>();
        this.CreateMap<UserVote, UserVoteViewModel>();
        this.CreateMap<UserVoteViewModel, UserVote>();
        this.CreateMap<CompletedPoll, CompletedPollViewModel>();
        this.CreateMap<CompletedPollViewModel, CompletedPoll>();
    }
}