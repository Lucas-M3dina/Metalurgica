import React from 'react'
import LogoRedondo from '../../assets/Logo-verde.svg'
import './Sidebar.css'
import { Link } from 'react-router-dom'

export function Sidebar() {
  return (
    <aside className='sidebar'>
      <div className="header-sidebar">
        <img className='logo-sidebar' src={LogoRedondo} alt="Logo" />
        <div className="textos-sidebar">
          <p className="nome-sidebar">Lucas Santos Medina </p>
          <p className="cargo-sidebar">Colaborador</p>
        </div>
      </div>

      <nav className="container-link-sidebar">
        <Link className='link-sidebar' to="/dashboard">
          <div className="container-link-icon">
            <svg className="icone-sidebar" xmlns="http://www.w3.org/2000/svg" width="22" height="22" viewBox="0 0 22 22">
              <path d="M20.5574 0C21.3541 0 22 0.645884 22 1.44262V7.93443C22 8.73116 21.3541 9.37705 20.5574 9.37705H14.0656C13.2688 9.37705 12.623 8.73116 12.623 7.93443V1.44262C12.623 0.645885 13.2688 0 14.0656 0H20.5574ZM20.5574 12.623C21.3541 12.623 22 13.2688 22 14.0656V20.5574C22 21.3541 21.3541 22 20.5574 22H14.0656C13.2688 22 12.623 21.3541 12.623 20.5574V14.0656C12.623 13.2688 13.2688 12.623 14.0656 12.623H20.5574ZM9.37705 7.93443C9.37705 8.73116 8.73116 9.37705 7.93443 9.37705H1.44262C0.645885 9.37705 0 8.73116 0 7.93443V1.44262C0 0.645885 0.645884 0 1.44262 0H7.93443C8.73116 0 9.37705 0.645884 9.37705 1.44262V7.93443ZM0 14.0656C0 13.2688 0.645884 12.623 1.44262 12.623H7.93443C8.73116 12.623 9.37705 13.2688 9.37705 14.0656V20.5574C9.37705 21.3541 8.73116 22 7.93443 22H1.44262C0.645885 22 0 21.3541 0 20.5574V14.0656Z"/>
            </svg>
            <span className="texto-link-sidebar">Dashboard</span>
          </div>
        </Link>

        <Link className='link-sidebar' to="/dashboard">
          <div className="container-link-icon">
            <svg className="icone-sidebar" xmlns="http://www.w3.org/2000/svg" width="30" height="27" viewBox="0 0 30 27">
              <path d="M12.7014 0H10.6528C9.29557 0 8.19444 1.10113 8.19444 2.45833V8.19444C8.19444 10.0023 9.66432 11.4722 11.4722 11.4722H18.0278C19.8357 11.4722 21.3056 10.0023 21.3056 8.19444V2.45833C21.3056 1.10113 20.2044 0 18.8472 0H16.7986V4.09722C16.7986 4.54792 16.4299 4.91667 15.9792 4.91667H13.5208C13.0701 4.91667 12.7014 4.54792 12.7014 4.09722V0ZM3.27778 13.1111C1.46988 13.1111 0 14.581 0 16.3889V22.9444C0 24.7523 1.46988 26.2222 3.27778 26.2222H11.4722C13.2801 26.2222 14.75 24.7523 14.75 22.9444V16.3889C14.75 14.581 13.2801 13.1111 11.4722 13.1111H9.42361V17.2083C9.42361 17.659 9.05486 18.0278 8.60417 18.0278H6.14583C5.69514 18.0278 5.32639 17.659 5.32639 17.2083V13.1111H3.27778ZM18.0278 26.2222H26.2222C28.0301 26.2222 29.5 24.7523 29.5 22.9444V16.3889C29.5 14.581 28.0301 13.1111 26.2222 13.1111H24.1736V17.2083C24.1736 17.659 23.8049 18.0278 23.3542 18.0278H20.8958C20.4451 18.0278 20.0764 17.659 20.0764 17.2083V13.1111H18.0278C17.2595 13.1111 16.5528 13.3723 15.9945 13.8179C16.2455 14.3505 16.3889 14.9446 16.3889 15.5694V23.7639C16.3889 24.3887 16.2455 24.9828 15.9945 25.5155C16.5528 25.961 17.2595 26.2222 18.0278 26.2222Z"/>
            </svg>
            <span className="texto-link-sidebar">Listagem de lote</span>
          </div>
        </Link>

        <Link className='link-sidebar' to="/dashboard">
          <div className="container-link-icon">
            <svg className="icone-sidebar" xmlns="http://www.w3.org/2000/svg" width="33" height="26" viewBox="0 0 33 26" fill="none">
              <path d="M13 2.4375C13 1.0918 14.0918 0 15.4375 0H30.0625C31.4082 0 32.5 1.0918 32.5 2.4375V23.5625C32.5 24.9082 31.4082 26 30.0625 26H19.3629C19.4543 25.7461 19.5 25.4719 19.5 25.1875V12.8629C20.4445 12.5277 21.125 11.6238 21.125 10.5625V8.9375C21.125 7.5918 20.0332 6.5 18.6875 6.5H13V2.4375ZM29.0113 17.6363C29.3262 17.3215 29.3262 16.8035 29.0113 16.4887L25.7613 13.2387C25.4465 12.9238 24.9285 12.9238 24.6137 13.2387L21.3637 16.4887C21.0488 16.8035 21.0488 17.3215 21.3637 17.6363C21.6785 17.9512 22.1965 17.9512 22.5113 17.6363L24.375 15.7727V21.9375C24.375 22.3844 24.7406 22.75 25.1875 22.75C25.6344 22.75 26 22.3844 26 21.9375V15.7727L27.8637 17.6363C28.1785 17.9512 28.6965 17.9512 29.0113 17.6363ZM0 8.9375C0 8.49063 0.365625 8.125 0.8125 8.125H18.6875C19.1344 8.125 19.5 8.49063 19.5 8.9375V10.5625C19.5 11.0094 19.1344 11.375 18.6875 11.375H0.8125C0.365625 11.375 0 11.0094 0 10.5625V8.9375ZM17.875 13V24.375C17.875 25.2738 17.1488 26 16.25 26H3.25C2.35117 26 1.625 25.2738 1.625 24.375V13H17.875ZM7.3125 16.25C6.86562 16.25 6.5 16.6156 6.5 17.0625C6.5 17.5094 6.86562 17.875 7.3125 17.875H12.1875C12.6344 17.875 13 17.5094 13 17.0625C13 16.6156 12.6344 16.25 12.1875 16.25H7.3125Z"/>
            </svg>
            <span className="texto-link-sidebar">Cadastro de lote</span>
          </div>
        </Link>

        <Link className='link-sidebar' to="/dashboard">
          <div className="container-link-icon">
            <svg className="icone-sidebar" xmlns="http://www.w3.org/2000/svg" width="25" height="26" viewBox="0 0 25 26" fill="none">
              <path d="M24.4379 8.46016C24.6004 8.90195 24.4632 9.39453 24.1129 9.70937L21.914 11.7102C21.9699 12.1316 22.0004 12.5633 22.0004 13C22.0004 13.4367 21.9699 13.8684 21.914 14.2898L24.1129 16.2906C24.4632 16.6055 24.6004 17.098 24.4379 17.5398C24.2144 18.1441 23.9453 18.723 23.6355 19.2816L23.3968 19.693C23.0617 20.2516 22.6859 20.7797 22.2746 21.2773C21.975 21.643 21.4773 21.7648 21.0304 21.6227L18.2019 20.7238C17.5215 21.2469 16.7699 21.6836 15.9675 22.0137L15.3328 24.9133C15.2312 25.3754 14.8757 25.741 14.4086 25.8172C13.7078 25.934 12.9867 25.9949 12.2504 25.9949C11.514 25.9949 10.7929 25.934 10.0922 25.8172C9.62496 25.741 9.2695 25.3754 9.16793 24.9133L8.53317 22.0137C7.73082 21.6836 6.97926 21.2469 6.29879 20.7238L3.47535 21.6277C3.02848 21.7699 2.53082 21.643 2.23121 21.2824C1.81989 20.7848 1.4441 20.2566 1.10895 19.698L0.870277 19.2867C0.560511 18.7281 0.29137 18.1492 0.067933 17.5449C-0.094567 17.1031 0.0425423 16.6105 0.392933 16.2957L2.59176 14.2949C2.5359 13.8684 2.50543 13.4367 2.50543 13C2.50543 12.5633 2.5359 12.1316 2.59176 11.7102L0.392933 9.70937C0.0425423 9.39453 -0.094567 8.90195 0.067933 8.46016C0.29137 7.85586 0.560511 7.27695 0.870277 6.71836L1.10895 6.30703C1.4441 5.74844 1.81989 5.22031 2.23121 4.72266C2.53082 4.35703 3.02848 4.23516 3.47535 4.37734L6.30387 5.27617C6.98434 4.75313 7.7359 4.31641 8.53825 3.98633L9.17301 1.08672C9.27457 0.624609 9.63004 0.258984 10.0972 0.182812C10.798 0.0609375 11.5191 0 12.2554 0C12.9918 0 13.7129 0.0609375 14.4136 0.177734C14.8808 0.253906 15.2363 0.619531 15.3379 1.08164L15.9726 3.98125C16.775 4.31133 17.5265 4.74805 18.207 5.27109L21.0355 4.37227C21.4824 4.23008 21.98 4.35703 22.2797 4.71758C22.691 5.21523 23.0668 5.74336 23.4019 6.30195L23.6406 6.71328C23.9504 7.27187 24.2195 7.85078 24.4429 8.45508L24.4379 8.46016ZM12.2554 17.0625C13.3329 17.0625 14.3662 16.6345 15.1281 15.8726C15.8899 15.1108 16.3179 14.0774 16.3179 13C16.3179 11.9226 15.8899 10.8892 15.1281 10.1274C14.3662 9.36551 13.3329 8.9375 12.2554 8.9375C11.178 8.9375 10.1447 9.36551 9.38281 10.1274C8.62094 10.8892 8.19293 11.9226 8.19293 13C8.19293 14.0774 8.62094 15.1108 9.38281 15.8726C10.1447 16.6345 11.178 17.0625 12.2554 17.0625Z"/>
            </svg>
            <span className="texto-link-sidebar">Configurações</span>
          </div>
        </Link>
        

        

      </nav>


    </aside>
  )
}
