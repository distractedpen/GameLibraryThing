import {Game} from "../util/types.ts";
import GameCard from "../components/GameCard.tsx";
import CardContainer from "../components/CardContainer.tsx";
import React, {useState} from "react";
import {Link, useLocation} from "react-router-dom";
import { getGames } from "../util/api.ts";

export default function Library() {

    const [gameList, setGameList] = useState<Game[]>([]);
    const location = useLocation();


    React.useEffect(() => {
        if ((location.state && location.state.reload === true) || (!location.state)) {
            getGames().then((gameList) => setGameList(gameList));
        }
    }, []);

    return (
        <div className="flex flex-col h-screen w-screen items-center justify-center">
            <div className="w-2/3 flex flex-row justify-between">
                <h1 className="text-2xl">Game Library</h1>
                <Link to={"game"} className="rounded bg-blue-300 text-2xl p-2">Add Game</Link>
            </div>
            <CardContainer>
                {gameList.map((game)  => {
                    return (
                       <GameCard key={game.id} game={game} size={"small"}  />
                    );
                })}
            </CardContainer>
        </div>
    )
}