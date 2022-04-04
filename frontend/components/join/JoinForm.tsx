import React, { useState } from "react";
import { joinVoting } from "../../api/api";
import {useSetRecoilState} from "recoil";
import {voterId} from "../../states";
import {useRouter} from "next/router";

const JoinForm = () => {
  const [code, setCode] = useState("");
  const setVoterId = useSetRecoilState(voterId);
  const router = useRouter();

  const handleJoinButton = async () => {
    const response = await joinVoting(code);

    if (response.status !== 200) return;

    setVoterId(response.data.voterId);

    await router.push("/voting");
  }

  return (
    <div className="flex flex-col m-20">
      <input className="bg-blue-400 text-4xl w-full" placeholder="code" onChange={(e) => setCode(e.target.value)} />
      <button className="bg-amber-400 text-4xl w-full" onClick={handleJoinButton}>Join</button>
    </div>
  )
}

export default JoinForm;
