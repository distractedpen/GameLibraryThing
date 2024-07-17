import { useParams } from "react-router-dom";
import GameEntryForm from "../components/GameEntryForm.tsx";


export default function GameEditor() {
    const { gameId } = useParams();

    return (
        <div className={"h-screen w-screen bg-amber-400 flex flex-col justify-center items-center"}>
            <h1>Edit Game</h1>
            <GameEntryForm editMode={true} gameId={gameId}/>
        </div>
    )
}