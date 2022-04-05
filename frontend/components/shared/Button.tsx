import React from "react";

interface ButtonProps {
  name: string
  backgroundColor?: string
  onClick: React.MouseEventHandler<HTMLButtonElement>
}

const Button: React.FC<ButtonProps> = ({ name, backgroundColor = "#1C1C1C", onClick }) => {
  return <button
    style={{ backgroundColor: backgroundColor }}
    className="border-4 border-none mt-10 p-5 rounded-2xl text-white desktop:text-2xl mobile:text-lg w-full"
    onClick={onClick}
  >
    {name}
  </button>
}

export default Button
