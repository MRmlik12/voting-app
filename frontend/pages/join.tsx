import React from "react";
import { NextPage } from "next";
import Head from "next/head";
import Header from "../components/shared/Header";
import JoinForm from "../components/join/JoinForm";

const Join: NextPage = () => {
  const title = "Join Voting";

  return (
    <div>
      <Head>
        <title>Join Voting</title>
      </Head>
      <Header title={title} />
      <JoinForm />
    </div>
  )
}

export default Join;
