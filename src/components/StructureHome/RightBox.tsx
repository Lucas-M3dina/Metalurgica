import './RightBox.css'
import Logo from '../../assets/Logo.svg'
import { ReactNode } from 'react'

interface RightBoxProps {
    children: ReactNode,
    api?: (e: React.FormEvent<HTMLFormElement>) => void
}

export function RightBox({children, api} : RightBoxProps) {
  return (
    <div className="right-box-login">
        <img className='logo-login' src={Logo} alt="Logo"/>
        <form onSubmit={(e) => {api && api(e)}} className='form-login'>
            {children}
        </form>
    </div>
  )
}
