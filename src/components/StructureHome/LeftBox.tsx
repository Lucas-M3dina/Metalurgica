import { Button } from '../Button/Button'
import LogoRedonda from '../../assets/Logo-Redondo.svg'
import './LeftBox.css'
import { ReactNode } from 'react'

interface LeftBoxProps {
    path: string,
    content: string,
    children: ReactNode
}

export function LeftBox({path, content, children} : LeftBoxProps) {
  return (
    <div className="left-box-login">
        <img className='logo-redondo-login' src={LogoRedonda} alt="Logo Redonda"/>

        <div className="box-text-login">
            {children}
        </div>

        <Button.ButtonRedirect path={path} content={content}/>
    </div>
  )
}
