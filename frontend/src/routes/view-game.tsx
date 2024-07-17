import React, {Suspense, useState} from 'react';
import {Game} from "../util/types.ts";
import {Link, useParams} from "react-router-dom";
import GameCard from "../components/GameCard.tsx";
import { getGameById } from "../util/api.ts";


export default function GameViewer() {
    const { game_id } = useParams();
    const [game, setGame] = useState<Game>();

    React.useEffect(() => {
        if (game_id !== undefined) {
            getGameById(game_id).then((game) => setGame(game));
        } else {
            console.log("Error: game_id is not defined");
        }
    }, []);

    return (
        <div className={"flex flex-col h-screen w-screen bg-amber-400"}>
            <Link to={"/library"} className={"float-left w-32 mt-2 ml-2 border-2 border-black h-20 flex justify-center items-center m-2"}>Back to Library</Link>
            <div className={"flex items-center justify-evenly"}>
                <Suspense fallback={<GameCard game={undefined} size={"large"}/>}>
                    <GameCard game={game} size={"large"}/>
                </Suspense>
            </div>
        </div>
    )
}