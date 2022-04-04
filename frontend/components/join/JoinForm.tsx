import React, { useState } from 'react'
import { joinVoting } from '../../api/api'
import { useSetRecoilState } from 'recoil'
import {code, voterId} from '../../states'
import { useRouter } from 'next/router'

const JoinForm = () => {
  const [votingCode, setVotingCode] = useState('')
  const setVoterId = useSetRecoilState(voterId)
  const setGlobalCode = useSetRecoilState(code);
  const router = useRouter()

  const handleJoinButton = async () => {
    const response = await joinVoting(votingCode)

    if (response.status !== 200) return

    setVoterId(response.data.voterId)
    setGlobalCode(votingCode);

    await router.push('/voting?itemIndex=0')
  }

  return (
    <div className="flex flex-col m-20">
      <input
        className="bg-blue-400 text-4xl w-full"
        placeholder="code"
        onChange={(e) => setVotingCode(e.target.value)}
      />
      <button
        className="bg-amber-400 text-4xl w-full"
        onClick={handleJoinButton}
      >
        Join
      </button>
    </div>
  )
}

export default JoinForm
