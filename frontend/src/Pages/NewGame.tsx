import GameEntryForm from "../components/GameEntryForm.tsx";


export default function AddGame() {

    return (
        <div className={"flex flex-col w-screen h-screen bg-[#DFDFDF] justify-center items-center"}>
            <GameEntryForm editMode={false} />
        </div>
    )
}