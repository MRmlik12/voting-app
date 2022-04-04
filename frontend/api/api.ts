import axios, { AxiosResponse } from 'axios'
import { CreateVotingResponse } from './models/create/createVotingResponse'
import { VotingItems } from '../types/votingItems'
import {JoinVotingResponse} from "./models/join/joinVotingResponse";

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

export const joinVoting = async (
  code: string
): Promise<AxiosResponse<JoinVotingResponse>> =>
  await baseClient.request<JoinVotingResponse>({
    url: '/vote/JoinVoting',
    method: 'POST',
    data: {
      code
    }
  })
    .catch((err) => err)
