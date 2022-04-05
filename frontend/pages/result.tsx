import React from "react";
import { NextPage } from "next";
import Head from "next/head";
import ResultContent from "../components/result/ResultContent";

const Result: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Voting Results</title>
      </Head>
      <ResultContent />
    </div>
  );
}

export default Result;
