import React, {Suspense, useState} from 'react';
import {Game} from "../../library.d.ts";
import {Link, useParams} from "react-router-dom";
import GameCard from "../components/GameCard.tsx";
import { getGameById } from "../api.tsx";
import Button from "../components/Button.tsx";


export default function GameViewer() {
    const { game_id } = useParams();
    const [game, setGame] = useState<Game>();

    React.useEffect(() => {
        if (game_id !== undefined) {
            let num_game_id = parseInt(game_id);
            getGameById(num_game_id).then((game) => setGame(game));
        } else {
            console.log("Error: game_id is not defined");
        }
    }, []);

    return (
        <div className={"flex flex-col h-screen w-screen bg-[#DFDFDF] justify-center items-center"}>
            <div className={"m-2 max-w-2xl"}>
                <Link className="flex justify-center items-center text-2xl rounded-2xl  bg-lavender_(web) shadow-black drop-shadow w-40 h-20" to={"/library"}>Library</Link>
            </div>
            <div className={"flex w-5/6 h-5/6 justify-center items-center bg-magnolia"}>
                <div className={"flex items-center justify-evenly"}>
                    // TODO: Fix this
                        {/*<GameCard game={game} size={"large"}/>*/}
                </div>
            </div>
        </div>
    )
}