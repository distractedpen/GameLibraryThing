import GameEntryForm from "../components/GameEntryForm.tsx";


export default function AddGame() {

    return (
        <div className={"flex flex-col w-screen h-screen bg-amber-400 justify-center items-center"}>
            <h1>Add Game</h1>
            <GameEntryForm editMode={false} />
        </div>
    )
}