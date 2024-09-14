import React, {useState} from "react";
import {Game} from "../../library.d.ts";
import {getGameById} from "../api.tsx";
import { postGame, updateGame } from "../api.tsx";
import Button from "./Button.tsx";

export default function GameEntryForm({editMode, gameId}: { editMode: boolean, gameId?: number}) {

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
            updateGame(gameId, uGame).then(() => {
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
        <div className={"flex flex-row flex-wrap bg-magnolia rounded-2xl w-2/5 h-3/5 justify-around"}>
            <h1 className={"text-6xl text-center items-start flex-initial w-full"}>{editMode ? "Edit Game" : "Add Game"}</h1>
            <div className={"flex justify-start w-full"}>
                <label className={"text-xl ml-4 mr-10"}>Name:</label>
                <input
                    name={"name"}
                    type={"text"}
                    className={"border-solid border-black border flex-initial w-3/4 h-min"}
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required/>
            </div>
            <div className={"flex justify-start w-full"}>
                <label className={"text-xl ml-4 mr-10"}>Developer:</label>
                <input
                    name={"developer"}
                    type={"text"}
                    className={"border-solid border-black border flex-initial w-3/4 h-min"}
                    value={developer}
                    onChange={(e) => setDeveloper(e.target.value)}
                    required/>
            </div>
            <div className={"flex justify-start w-full"}>
                <label className={"text-xl ml-4 mr-10"}>Status:</label>
                <select
                    name={"status"}
                    value={status}
                    className={"border-solid border-black border flex-initial w-3/4 h-min"}
                    onChange={(e) => setStatus(e.target.value)}
                >
                    <option value={"completed"}>Completed</option>
                    <option value={"inprogress"}>In Progress</option>
                    <option value={"own"}>Own</option>
                    <option value={"want"}>Want</option>
                    <option value={"dropped"}>Dropped</option>
                </select>
            </div>
            <Button isLink={false} handleClick={handleSubmit}>{editMode ? "Update" : "Add"}</Button>
            <Button isLink={false} handleClick={handleCancel}>Cancel</Button>
        </div>
    )
}