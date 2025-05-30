import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { createBrowserRouter, RouterProvider } from "react-router-dom"

import SalaPage from './components/salaPage.jsx'
import QrPrintPage from './components/qrPrintPage.jsx'
import PietroPage from './components/pietroPage.jsx'
import NotFoundPage from './components/notFound.jsx'
import MainPage from './components/mainPage.jsx'
import AdminLogin from './components/adminLogin.jsx'
import LekcjaPutPage from './components/addPages/lekcjaPut.jsx'

const router = createBrowserRouter([
  {
    element: <MainPage/>,
    path: "/",
  },
  {
    element: <PietroPage/>,
    path: "/pietro/:pietro"
  },
  {
    element: <SalaPage/>,
    path: "/sala/:pietro/:sala"
  },
  {
    element: <NotFoundPage/>,
    path: "*"
  },
  {
    element: <QrPrintPage/>,
    path: "/qrprint"
  },
  {
    element: <AdminLogin/>,
    path: "/admin"
  }

]);

createRoot(document.getElementById('root')).render(

    <RouterProvider router={router}/>
  
)
