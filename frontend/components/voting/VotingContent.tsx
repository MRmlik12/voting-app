import React from "react";

interface VotingContentProps {
  firstItem: string;
  secondItem: string;
}

const VotingContent: React.FC<VotingContentProps> = ({ firstItem, secondItem }) => {
  return (
    <div className="flex flex-row w-full">
      <button className="w-1/2 bg-amber-400 h-screen">{firstItem}</button>
      <button className="w-1/2 bg-green-400 h-screen">{secondItem}</button>
    </div>
  );
}

export default VotingContent;
