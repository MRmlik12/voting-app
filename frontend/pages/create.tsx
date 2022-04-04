import React from 'react'
import { NextPage } from 'next'
import Head from 'next/head'
import CreateForm from '../components/create/CreateForm'
import Header from "../components/shared/Header";

const Create: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Create Voting</title>
      </Head>
      <Header title="Create Voting" />
      <CreateForm />
    </div>
  )
}

export default Create
