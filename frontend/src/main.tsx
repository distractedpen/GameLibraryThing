
import React from 'react'
import ReactDOM from 'react-dom/client'
import axios from "axios";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Library from "./routes/library.tsx";
import ErrorPage from "./routes/error-page.tsx";
import "./index.css";

axios.defaults.baseURL = `http://${import.meta.env.VITE_API_HOST}:${import.meta.env.VITE_API_PORT}`;
console.log(axios.defaults.baseURL)


const router = createBrowserRouter([
    {
        path: "/",
        element: <Library/>,
        errorElement: <ErrorPage/>,
    }
])

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
      <RouterProvider router={router}/>
  </React.StrictMode>,
)
