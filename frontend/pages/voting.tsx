import React, {useEffect, useState} from 'react'
import { NextPage } from 'next'
import Head from 'next/head'
import VotingContent from "../components/voting/VotingContent";
import {VoteItem} from "../api/models/voting/voteItem";
import {getVoteItem} from "../api/api";
import {useRecoilValue} from "recoil";
import {code, voteIndex} from '../states';
import VotingCounter from "../components/voting/VotingCounter";
import { useRouter } from "next/router";

const Voting: NextPage = () => {
  const [voteItem, setVoteItem] = useState<VoteItem | null>(null);
  const key = useRecoilValue(code)
  const itemIndex = useRecoilValue(voteIndex);
  const router = useRouter();

  const onStartup = async () => {
    if (itemIndex === voteItem?.itemsCount)
      await router.push("/complete")
    const response = await getVoteItem(key, itemIndex)

    if (response.status !== 200) return;

    setVoteItem(response.data);
  }

  useEffect(() => {
    if (itemIndex === voteItem?.itemsCount)
      router.push("/complete")
    (async () => await onStartup())()
  }, [itemIndex]);

  return (
    <div>
      <Head>
        <title>Voting</title>
      </Head>
      {voteItem ? (
        <>
          <VotingCounter counter={itemIndex} max={voteItem.itemsCount} />
          <VotingContent firstItem={voteItem.firstItem} secondItem={voteItem.secondItem} />
        </>
      ) : null}
    </div>
  )
}

export default Voting
