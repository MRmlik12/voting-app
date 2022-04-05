import React, { useState } from 'react'
import { VotingItems } from '../../types/votingItems'
import { createVoting } from '../../api/api'
import { VOTING_CREDENTIALS_KEY } from '../../misc/constrants'
import { useRouter } from 'next/router'

const CreateForm = () => {
  const [title, setTitle] = useState('')
  const [voteItems, setVoteItems] = useState<VotingItems[]>([])
  const router = useRouter()

  const handleCreateButton = async () => {
    const response = await createVoting(title, voteItems)

    if (response.status !== 200) return

    localStorage.setItem(VOTING_CREDENTIALS_KEY, JSON.stringify(response.data))
    await router.push('/result')
  }

  const handleAddButton = () => {
    const voteItem = {
      firstItem: '',
      secondItem: '',
    }

    setVoteItems([...voteItems, voteItem])
  }

  return (
    <div className="flex flex-col m-20">
      <input
        className="bg-blue-400"
        placeholder="Title"
        onChange={(e) => setTitle(e.target.value)}
      />
      <div>
        {voteItems.map((item, index) => {
          return (
            <div key={index} className="flex flex-row m-5">
              <input
                className="bg-amber-300 mr-5"
                onChange={(e) => (item.firstItem = e.target.value)}
              />
              <input
                className="bg-amber-300"
                onChange={(e) => (item.secondItem = e.target.value)}
              />
            </div>
          )
        })}
      </div>
      <button className="bg-green-400" onClick={handleAddButton}>
        Add
      </button>
      <button className="bg-gray-500 mt-5" onClick={handleCreateButton}>
        Create
      </button>
    </div>
  )
}

export default CreateForm
