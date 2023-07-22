import { ButtonHTMLAttributes } from "react";
import './ButtonDefault.css'

interface ButtonDefaultProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    content: string,
}

export function ButtonDefault({content, ...props} : ButtonDefaultProps) {
  return (
    <button className="btn-default" {...props} >{content}</button>
  )
}
