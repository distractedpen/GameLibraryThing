import {Game} from "../util/types.ts";
import GameCard from "../components/GameCard.tsx";
import CardContainer from "../components/CardContainer.tsx";
import React, {useState} from "react";
import axios from "axios";


export default function Library() {

    const [gameList, setGameList] = useState<Game[]>([]);

    React.useEffect(() => {
        axios.get('/games/').then((response) => {
            let gameList: Game[] = [];
            console.log(response.data);
            response.data.forEach((game: Game) => gameList.push(game));
            setGameList(gameList);
        });
    }, []);

    return (
        <div className="flex flex-col h-screen w-screen items-center justify-center">
            {/* Game Display */}
            <div className="w-2/3 flex flex-row justify-between">
                <h1 className="text-2xl">Game Library</h1>
                <button className="rounded bg-blue-300 text-2xl p-2">Add Game</button>
            </div>
            <CardContainer>
                {gameList.map((game, index) => {
                    return (
                        <GameCard game={game} key={index} />
                    );
                })}
            </CardContainer>
        </div>
    )
}