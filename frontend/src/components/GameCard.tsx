import {Link} from "react-router-dom";
import editIcon from "../assets/edit_icon.png";
import {LibraryGet} from "../Models/Library.ts";
import DeleteGame from "./DeleteGame.tsx";
import {SyntheticEvent} from "react";

interface Props {
    game: LibraryGet,
    size: "small" | "large",
    onGameDelete: (e: SyntheticEvent) => void
}

export default function GameCard({game, size, onGameDelete} : Props) {


    const sizeClassName = size === "small" ? "h-64 w-64" : "h-96 w-64";

    return (
        <div className={sizeClassName + " bg-lavender_(web) border-black border-solid border-2 flex flex-col m-4"}>
            <Link to={`/game/${game.id}`} className={"flex flex-col pl-4 h-full w-full bg-vermilion-700 "}>
                <div className={"h-2/3 flex flex-row justify-between "}>
                    <DeleteGame game={game} onGameDelete={onGameDelete}/>
                </div>
                <p className={"text-m"}>{game.name}</p> {/* TODO: Make text ... if too long */}
                <p className={"text-xs"}>{game.developer}</p>
            </Link>
        </div>
    );
};