import axios from "axios";
import {Game} from "./types.ts";

let api_config_set = false;

function apiConfig() {
    if (!api_config_set) {
        axios.defaults.baseURL = `http://${import.meta.env.VITE_API_HOST}:${import.meta.env.VITE_API_PORT}/api`;
        console.log(axios.defaults.baseURL)
    }
}

// Game Get Functions
async function getGames(): Promise<Game[]> {
    let response = await axios.get('/games');
    let gameList: Game[] = [];
    response.data.forEach((game: Game) => gameList.push(game));
    return gameList;
}

async function getGameById(game_id: string): Promise<Game> {
    const response = await axios.get(`/games/${game_id}`);
    return await response.data;
}

async function postGame(game: Game) {
    const response = await axios.post("/games", game);
    if (response.status != 201) {
        // Handle Error!
        throw new Error("Error Saving Game!");
    }
    console.log(response.statusText);
}

async function updateGame(game_id: number, game: Game) {
    const response = await axios.put(`/games/${game_id}`, game);
    if (response.status != 200) {
        throw new Error("Error Updating Game!");
    }
    console.log(response.statusText);
}

async function deleteGame(game_id: string) {
    const response = await axios.delete(`/games/${game_id}`);
    if (response.status != 200) {
        // Handle Error!
        throw new Error("Error Deleting game!");
    }
    console.log(response.statusText);
}

export {
    apiConfig,
    getGames,
    getGameById,
    postGame,
    updateGame,
    deleteGame,
};