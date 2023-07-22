
import { Link } from 'react-router-dom'
import './ButtonRedirect.css'

interface ButtonRedirectProps {
    path: string,
    content: string
}

export function ButtonRedirect({path, content} : ButtonRedirectProps) {
  return (
    <Link className='btn-redirect' to={path}>{content}</Link>
  )
}
