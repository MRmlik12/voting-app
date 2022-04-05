import React, { useEffect, useState } from "react";
import { HttpTransportType, HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { VotingResult } from "../../types/votingResult";
import { VOTING_CREDENTIALS_KEY } from "../../misc/constrants";

const WEBSOCKET_URL = process.env.NODE_ENV !== "production" ? "wss://localhost:7206/hub/votingResults" : process.env.WEBSOCKET_URL

const ResultContent = () => {
  const [connection, setConnection] = useState<HubConnection | null>(null)
  const [votingData, setVotingData] = useState<VotingResult | null>(null);

  const refreshVotingData = async () => {
    const content = JSON.parse(localStorage.getItem(VOTING_CREDENTIALS_KEY)!)
    await connection?.invoke("sendMessage", content)
  }

  const handleServer = async () => {
    await connection?.start();
    connection?.on('receiveMessage', (msg) => {
      setVotingData(msg);
    })

    setInterval(refreshVotingData, 10000)
  }

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl(WEBSOCKET_URL!, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build()

    setConnection(connection);
  }, [])

  useEffect(() => {
    if (!connection) return;
    (async () => await handleServer())()
  }, [connection])

  return (
    <div className="flex flex-col items-center m-10">
      <header className="text-6xl font-bold">{votingData?.code}</header>
      <header className="text-4xl font-bold m-5">{votingData?.participantsCount}</header>
      {votingData ? votingData?.votes.map((item, index) => {
        const firstItemWidth = (100 * item.firstVote.count) / (item.firstVote.count + item.secondVote.count);
        const secondItemWidth = (100 * item.secondVote.count) / (item.firstVote.count + item.secondVote.count);
        console.log(firstItemWidth, secondItemWidth)

        return (
          <div key={index} className="flex flex-col items-start w-1/2 p-2">
            <div className="flex flex-row w-full justify-between">
              <label>{Math.round(firstItemWidth)}% - {item.firstVote.name}</label>
              <label>{Math.round(secondItemWidth)}% - {item.secondVote.name}</label>
            </div>
            <progress max={100} value={firstItemWidth} className="w-full" />
          </div>
        )
      }) : null}
    </div>
  )
}

export default ResultContent;
