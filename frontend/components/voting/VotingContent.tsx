import React from 'react'
import { castVote } from '../../api/api'
import { useRecoilState, useRecoilValue } from 'recoil'
import { code, voteIndex, voterId } from '../../states'
import { useRouter } from 'next/router'

interface VotingContentProps {
  firstItem: string
  secondItem: string
}

const VotingContent: React.FC<VotingContentProps> = ({
  firstItem,
  secondItem,
}) => {
  const votingCode = useRecoilValue(code)
  const voter = useRecoilValue(voterId)
  const [index, setVoteIndex] = useRecoilState(voteIndex)
  const router = useRouter()

  const handleVoteButton = async (selectedVote: number) => {
    const response = await castVote(votingCode, voter, index, selectedVote)

    if (response.status !== 200) return

    setVoteIndex(index + 1)
    await router.push(`/voting?voteIndex=${index}`)
  }

  return (
    <div className="flex flex-row w-full">
      <button
        className="w-1/2 bg-amber-400 h-screen"
        onClick={() => handleVoteButton(0)}
      >
        {firstItem}
      </button>
      <button
        className="w-1/2 bg-green-400 h-screen"
        onClick={() => handleVoteButton(1)}
      >
        {secondItem}
      </button>
    </div>
  )
}

export default VotingContent
