import React from "react";

interface HeaderProps {
  title: string;
}

const Header: React.FC<HeaderProps> = ({ title }) => {
  return (
    <div className="flex flex-row items-center justify-center m-20">
      <header className="text-7xl font-bold">{title}</header>
    </div>
  )
}

export default Header;
