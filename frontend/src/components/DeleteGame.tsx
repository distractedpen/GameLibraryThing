import {SyntheticEvent} from 'react'
import {LibraryGet} from "../Models/Library.ts";
import trashIcon from "../assets/trash_icon.png";

interface Props {
    game: LibraryGet;
    onGameDelete: (e: SyntheticEvent) => void;
}

const DeleteGame = ({game, onGameDelete}: Props) => {
    return (
        <form onSubmit={onGameDelete} className={"float-right mt-2 mr-2 rounded-2xl bg-vermilion text-white h-fit"}>
            <input hidden value={game.name} readOnly={true}/>
            <button type={"submit"}><img src={trashIcon} width={24} height={24} alt={"Delete"}/></button>
        </form>
    )
}
export default DeleteGame
