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
    <div className="flex desktop:flex-row mobile:flex-col h-screen mobile:w-screen">
      <button
        className="desktop:w-1/2 mobile:h-1/2 bg-amber-400"
        onClick={() => handleVoteButton(0)}
      >
        <label className="text-4xl font-bold">{firstItem}</label>
      </button>
      <button
        className="desktop:w-1/2 mobile:h-1/2 desktop:h-screen mobile:w-screen bg-green-400"
        onClick={() => handleVoteButton(1)}
      >
        <label className="text-4xl font-bold">{secondItem}</label>
      </button>
    </div>
  )
}

export default VotingContent
