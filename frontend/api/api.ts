import axios, { AxiosResponse } from 'axios'
import { CreateVotingResponse } from './models/create/createVotingResponse'
import { VotingItems } from '../types/votingItems'

const baseClient = axios.create({
  baseURL:
    process.env.NODE_ENV !== 'production'
      ? 'http://localhost:5036'
      : process.env.API_URL,
})

export const createVoting = async (
  title: string,
  votingItems: VotingItems[]
): Promise<AxiosResponse<CreateVotingResponse>> =>
  await baseClient
    .request<CreateVotingResponse>({
      url: '/vote/CreateVoting',
      method: 'POST',
      data: {
        title,
        votingItems,
      },
    })
    .catch((err) => err)
