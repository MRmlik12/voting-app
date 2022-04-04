import { atom } from 'recoil'

export const voterId = atom({
  key: 'voterId',
  default: '',
})

export const code = atom({
  key: 'code',
  default: '',
})

export const voteIndex = atom({
  key: 'voteIndex',
  default: 0,
})
