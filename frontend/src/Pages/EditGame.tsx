import { useParams } from "react-router-dom";
import GameEntryForm from "../components/GameEntryForm.tsx";


export default function GameEditor() {
    const { gameId } = useParams();

    const parsedGameId = gameId === undefined ? NaN : parseInt(gameId);

    return (
        <div className={"h-screen w-screen bg-[#DFDFDF] flex justify-center items-center"}>
            <GameEntryForm editMode={true} gameId={parsedGameId}/>
        </div>
    )
}