import {Game} from "../util/types.ts";

export default function GameCard({ game } : {game: Game}) {
    return (
        <div className="h-64 w-64 bg-blue-500 border-black border-solid border-2 p-2 m-2">
            <h3>{game.name}</h3>
            <p>{game.developer}</p>
            <p>{game.status}</p>
        </div>
    );
};