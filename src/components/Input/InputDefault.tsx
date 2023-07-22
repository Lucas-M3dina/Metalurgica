import { InputHTMLAttributes } from 'react'
import './InputDefault.css'

interface InputDefaultProps extends InputHTMLAttributes<HTMLInputElement> {
    labelInput: string,
    moreClassName?: string,
    placeholder: string,
}

export function InputDefault({moreClassName, labelInput, ...props} : InputDefaultProps) {
  return (
    <div className={'container-input-default ' + moreClassName}>
      <label className='label-input-default' htmlFor={labelInput}>{labelInput}:</label>
      <input className='input-default' id={labelInput} {...props}/>
    </div>
  )
}
