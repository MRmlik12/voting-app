import React from "react";

interface VotingCounterProps {
  counter: number;
  max: number;
}

const VotingCounter: React.FC<VotingCounterProps> = ({ counter, max }) => {
  return (
    <div className="absolute left-1/2 right-1/2">
      <header className="text-3xl">{counter + 1}/{max}</header>
    </div>
  )
}

export default VotingCounter;
