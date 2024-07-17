import {Game} from "../util/types.ts";
import {Link} from "react-router-dom";
import { deleteGame } from "../util/api.ts";

const handleDelete = (game_id: number | undefined) => {
    // TODO: Add confirmation dialog
    if (game_id !== undefined) {
        deleteGame(game_id).then(() => {
            location.pathname = "/library";
        });
    }
    else {
        throw new Error("Game ID is not valid!");
    }
}


export default function GameCard({ game, size } : {game: Game | undefined, size: "small" | "large"}) {

    const sizeClassName = size === "small" ? "h-64 w-64" : "h-96 w-64";

    return (
        <div className={sizeClassName + " bg-blue-500 border-black border-solid border-2 flex flex-col m-4"}>
            {game !== undefined && (
                <>
                    <div className={"h-2/3 flex flex-row justify-between "}>
                        <Link to={`game/${game.id}`} className={"h-full w-full"}/>
                            <button onClick={() => handleDelete(game.id)}
                                    className={"float-right mt-2 mr-2 rounded-2xl bg-black text-white h-10"}>Del</button>
                    </div>
                    <div className={"flex flex-row justify-between"}>
                        <div className={"h-full w-full bg-purple-400 "}>
                            <Link to={`game/${game.id}`} className={""}>
                                <p className={"text-m text-black"}>{game.name}</p> {/* TODO: Make text ... if too long */}
                                <p className={"text-xs text-white"}>{game.developer}</p>
                                <p className={"text-xs text-gray-200"}>{game.status}</p>
                            </Link>
                            <Link to={`/library/game/edit/${game.id}`} className={"float-right mr-2 mb-2 h-10 rounded-2xl bg-red-400"}>
                                Edit
                            </Link>
                        </div>
                    </div>
                </>
            )}
        </div>
);
};