using VotingApp.Core.Models;

namespace VotingApp.Core.ProjectAggregate.Vote.Dtos;

public class VotingItemDto : VotingItem
{
    public int? ItemsCount { get; set; }
}
