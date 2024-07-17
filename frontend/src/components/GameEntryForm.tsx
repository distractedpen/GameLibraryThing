import React, {useState} from "react";
import {Game} from "../util/types.ts";
import {getGameById} from "../util/api.ts";
import { postGame, updateGame } from "../util/api.ts";

export default function GameEntryForm({editMode, gameId}: { editMode: boolean, gameId?: string }) {

    const [name, setName] = useState("");
    const [developer, setDeveloper] = useState("");
    const [status, setStatus] = useState("want");

    React.useEffect(() => {
        if (editMode && gameId) {
            getGameById(gameId).then((game: Game) => {
                setName(game.name);
                setDeveloper(game.developer);
                setStatus(game.status);
            });
        }
    }, []);

    const handleSubmit = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        let uGame = {
            name,
            developer,
            status
        };

        if (editMode && gameId) {
            updateGame(parseInt(gameId), uGame).then(() => {
                location.pathname = "/library";
            });
        } else {
            postGame(uGame).then(() => {
                location.pathname = "/library";
            });
        }
    }

    const handleCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        location.pathname = "/library";
    }

    return (
        <form className={"grid grid-cols-2 gap-3 w-1/3 rounded border-solid border-gray-500 border-2 p-2"}>
            <label className={"ml-2 mr-20"}>Name:</label>
            <input
                name={"name"}
                type={"text"}
                className={"inline-block"}
                value={name}
                onChange={(e) => setName(e.target.value)}
                required/>
            <label className={"ml-2 mr-20"}>Developer:</label>
            <input
                name={"developer"}
                type={"text"}
                className={"inline-block"}
                value={developer}
                onChange={(e) => setDeveloper(e.target.value)}
                required/>
            <label className={"ml-2 mr-20"}>Status:</label>
            <select
                name={"status"}
                value={status}
                className={"text-center text-gray-500 bg-white"}
                onChange={(e) => setStatus(e.target.value)}
            >
                <option value={"completed"}>Completed</option>
                <option value={"inprogress"}>In Progress</option>
                <option value={"own"}>Own</option>
                <option value={"want"}>Want</option>
                <option value={"dropped"}>Dropped</option>
            </select>
            <button className={"w-full bg-blue-400 rounded "} onClick={(e) => handleSubmit(e)}>{editMode ? "Update" : "Add" }</button>
            <button className={"w-full bg-red-500 rounded"} onClick={(e) => handleCancel(e)}>Cancel</button>
        </form>
    )
}