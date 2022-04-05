import React from 'react'
import { useRouter } from 'next/router'
import Button from "../shared/Button";

const IndexContent = () => {
  const router = useRouter()

  return (
    <div className="flex flex-col items-center justify-center">
      <Button
        name="Create Voting"
        onClick={() => router.push('/create')}
      />
      <Button
        name="Join Voting"
        onClick={() => router.push('/join')}
      />
    </div>
  )
}

export default IndexContent
