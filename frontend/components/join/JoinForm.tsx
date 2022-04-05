import React, { useState } from 'react'
import { joinVoting } from '../../api/api'
import { useSetRecoilState } from 'recoil'
import { code, voterId } from '../../states'
import { useRouter } from 'next/router'
import TextInput from "../shared/TextInput";
import Button from "../shared/Button";

const JoinForm = () => {
  const [votingCode, setVotingCode] = useState('')
  const setVoterId = useSetRecoilState(voterId)
  const setGlobalCode = useSetRecoilState(code)
  const router = useRouter()

  const handleJoinButton = async () => {
    const response = await joinVoting(votingCode)

    if (response.status !== 200) return

    setVoterId(response.data.voterId)
    setGlobalCode(votingCode)

    await router.push('/voting?itemIndex=0')
  }

  return (
    <div className="flex flex-col m-20 desktop:w-1/4 mobile:w-1/2">
      <TextInput
        placeholder="code"
        onChange={(e) => setVotingCode(e.target.value)}
      />
      <Button
        name="Join"
        onClick={handleJoinButton}
      />
    </div>
  )
}

export default JoinForm
