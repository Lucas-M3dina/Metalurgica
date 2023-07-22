import { ReactNode } from "react"


interface TextProps {
    children: ReactNode
}

export function Text({children} : TextProps) {
  return (
    <p className="text-login">{children}</p>
  )
}
