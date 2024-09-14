import {createBrowserRouter} from "react-router-dom";
import App from "../App.tsx";
import ErrorPage from "../Pages/ErrorPage.tsx";
import LoginPage from "../Pages/LoginPage.tsx";
import Library from "../Pages/Library.tsx";
import AddGame from "../Pages/NewGame.tsx";
import GameViewer from "../Pages/ViewGame.tsx";
import GameEditor from "../Pages/EditGame.tsx";
import HomePage from "../Pages/HomePage.tsx";
import RegisterPage from "../Pages/RegisterPage.tsx";
import ProtectedRoute from "./ProtectedRoute.tsx";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children: [
            { path: "", element: <HomePage/> },
            { path: "/login", element: <LoginPage/> },
            { path: "/register", element: <RegisterPage/> },
            {
                path: "/library",
                element: <ProtectedRoute><Library/></ProtectedRoute>,
                children: [
                    { path: "library/game", element: <AddGame/> },
                    { path: "library/game/:game_id", element: <GameViewer/>, },
                    { path: "library/game/edit/:gameId", element: <GameEditor/> }
                ]
            },
        ],
        errorElement: <ErrorPage/>,
    }
]);