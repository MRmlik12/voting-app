import React, { useState } from 'react'
import { VotingItems } from '../../types/votingItems'
import { createVoting } from '../../api/api'
import { VOTING_CREDENTIALS_KEY } from '../../misc/constrants'
import { useRouter } from 'next/router'
import TextInput from "../shared/TextInput";
import Button from "../shared/Button";

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
      <TextInput
        placeholder="Title"
        onChange={(e) => setTitle(e.target.value)}
      />
      <div>
        {voteItems.map((item, index) => {
          return (
            <div key={index} className="flex flex-row m-5">
              <TextInput
                placeholder="First item"
                onChange={(e) => (item.firstItem = e.target.value)}
              />
              <div className="m-1"></div>
              <TextInput
                placeholder="Second item"
                onChange={(e) => (item.secondItem = e.target.value)}
              />
            </div>
          )
        })}
      </div>
      <Button name="Add" backgroundColor="#74994b" onClick={handleAddButton} />
      <Button name="Create" onClick={handleCreateButton} />
    </div>
  )
}

export default CreateForm
