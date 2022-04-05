import React from 'react'

interface HeaderProps {
  title: string
}

const Header: React.FC<HeaderProps> = ({ title }) => {
  return (
    <div className="flex flex-row items-center justify-center m-20">
      <header className="desktop:text-6xl mobile:text-4xl font-bold font-fira-sans">{title}</header>
    </div>
  )
}

export default Header
