import axios from "axios";
import {Game} from "../library";

const apiUrl = "http://localhost:8004/api";

// Game Get Functions
async function getGames(): Promise<Game[]> {
    const response = await axios.get(apiUrl + '/games');
    const gameList: Game[] = [];
    response.data.forEach((game: Game) => gameList.push(game));
    return gameList;
}

async function getGameById(game_id: number): Promise<Game> {
    const response = await axios.get(apiUrl + `/games/${game_id}`);
    return await response.data;
}

async function postGame(game: Game) {
    const response = await axios.post(apiUrl + "/games", game);
    if (response.status != 201) {
        // Handle Error!
        throw new Error("Error Saving Game!");
    }
    console.log(response.statusText);
}

async function updateGame(game_id: number, game: Game) {
    const response = await axios.put(apiUrl + `/games/${game_id}`, game);
    if (response.status != 200) {
        throw new Error("Error Updating Game!");
    }
    console.log(response.statusText);
}

async function deleteGame(game_id: number) {
    const response = await axios.delete(apiUrl + `/games/${game_id}`);
    if (response.status != 204) {  // HTTP 204 NO CONTENT
        // Handle Error!
        throw new Error("Error Deleting game!");
    }
    console.log(response.statusText);
}

export {
    getGames,
    getGameById,
    postGame,
    updateGame,
    deleteGame,
};