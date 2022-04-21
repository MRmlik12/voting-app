export interface VotingResult {
  code: string
  participantsCount: number
  votes: VoteModels[]
}

interface VoteModels {
  firstVote: VoteDetail
  secondVote: VoteDetail
}

interface VoteDetail {
  name: string
  count: number
}
