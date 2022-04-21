import React, { ChangeEventHandler } from "react";

interface TextInputProps {
  placeholder: string
  onChange: ChangeEventHandler<HTMLInputElement>
}

const TextInput: React.FC<TextInputProps> = ({ placeholder, onChange }) => {
  return <input
    style={{ borderColor: "#1C1C1C"}}
    className="desktop:text-2xl mobile:text-lg border-4 p-2 w-full rounded-2xl bg-white"
    placeholder={placeholder}
    onChange={onChange}
  />
}

export default TextInput;
