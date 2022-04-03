import React from 'react'
import { NextPage } from 'next'
import Head from 'next/head'
import CreateHeader from '../components/create/CreateHeader'
import CreateForm from '../components/create/CreateForm'

const Create: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Create Voting</title>
      </Head>
      <CreateHeader />
      <CreateForm />
    </div>
  )
}

export default Create
