import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { createBrowserRouter, RouterProvider } from "react-router-dom";


// Pages

import { Login } from './pages/Login/Login.tsx';
import { Cadastro } from './pages/Cadastro/Cadastro.tsx';
import { Error } from './pages/Error/Error.tsx';
import { Dashboard } from './pages/Dashboard/Dashboard.tsx';


const router = createBrowserRouter([
  {
    path: '/',
    element: <App/>,
    errorElement: <Error/>,
    children: [
      {
        path: "/",
        element: <Login/>
      },
      {
        path: "cadastro",
        element: <Cadastro/>
      },
      {
        path: "dashboard",
        element: <Dashboard/>
      },
    ]

  }
])


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>,
)
