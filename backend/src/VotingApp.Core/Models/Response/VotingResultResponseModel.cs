namespace VotingApp.Core.Models.Response;

public class VotingResultResponseModel
{
    public string? Code { get; set; }
    public int? ParticipantsCount { get; set; }
    public List<VoteModels>? Votes { get; set; }
}

public class VoteModels
{
    public VoteDetail? FistVote { get; set; }
    public VoteDetail? SecondVote { get; set; }
}

public class VoteDetail
{
    public string? Name { get; set; }
    public int? Count { get; set; }
}
