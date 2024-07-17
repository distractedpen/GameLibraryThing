import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Library from "./routes/library.tsx";
import ErrorPage from "./routes/error-page.tsx";
import "./index.css";
import AddGame from "./routes/new-game.tsx";
import Root from "./routes/root.tsx";
import GameViewer from "./routes/view-game.tsx";
import { apiConfig } from "./util/api.ts";
import GameEditor from "./routes/edit-game.tsx";

apiConfig();

const router = createBrowserRouter([
    {
        path: "/",
        element: <Root/>,
        errorElement: <ErrorPage/>,
    },
    {
        path: "/library",
        element: <Library/>,
    },
    {
        path: "library/game",
        element: <AddGame/>
    },
    {
        path: "library/game/:game_id",
        element: <GameViewer/>,
    },
    {
        path: "library/game/edit/:gameId",
        element: <GameEditor/>
    }
])

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
      <RouterProvider router={router}/>
  </React.StrictMode>,
)
