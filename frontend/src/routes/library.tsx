import {Game} from "../util/types.ts";
import GameCard from "../components/GameCard.tsx";
import CardContainer from "../components/CardContainer.tsx";
import React, {useState} from "react";
import {useLocation} from "react-router-dom";
import { getGames } from "../util/api.ts";
import Button from "../components/Button.tsx";

export default function Library() {

    const [gameList, setGameList] = useState<Game[]>([]);
    const rLocation = useLocation();
    const [user, _setUser] = useState("User");

    function handleLogout() {
        console.log("Logout");
        location.pathname = "/";
    }


    React.useEffect(() => {
        if ((rLocation.state && rLocation.state.reload === true) || (!rLocation.state)) {
            getGames().then((gameList) => setGameList(gameList));
        }
    }, []);

    return (
        <div className="flex flex-col h-screen w-screen items-center justify-center bg-[#DFDFDF]">
            <div className="flex justify-evenly items-center w-5/6">
                <h1 className="text-4xl flex-init w-2/3">{user}'s Library</h1>
                <Button isLink={true} linkTo={"game"}>Add Game</Button>
                <Button isLink={false} handleClick={handleLogout}>Logout</Button>
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
