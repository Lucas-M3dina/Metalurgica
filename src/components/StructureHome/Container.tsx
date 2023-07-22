import { ReactNode } from "react"
import './Container.css'

interface ContainerProps {
    children: ReactNode
}

export function Container({children} : ContainerProps) {
  return (
    <div className="container"> {children}</div>
  )
}
