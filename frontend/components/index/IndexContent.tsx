import React from 'react'
import { useRouter } from 'next/router'

const IndexContent = () => {
  const router = useRouter()

  return (
    <div className="flex flex-col items-center justify-center">
      <button
        className="border-4 border-blue-700 bg-blue-700 p-5 m-10 rounded-2xl text-4xl w-full"
        onClick={() => router.push('/create')}
      >
        Create Voting
      </button>
      <button
        className="border-4 border-blue-700 bg-blue-700 p-5 m-10 rounded-2xl text-4xl w-full"
        onClick={() => router.push('/join')}
      >
        Join Voting
      </button>
    </div>
  )
}

export default IndexContent
