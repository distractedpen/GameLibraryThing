import axios from "axios";
import {LibraryGet, LibraryPost} from "../Models/Library.ts";

const api = "http://localhost:8004/api/library/";

export async function libraryGetApi()  {
    try {
        return await axios.get<LibraryGet[]>(api);
    } catch (error) {
        console.log(error);
    }
}

export async function libraryPostApi(gameName: string) {
    try {
        return await axios.post<LibraryPost>(api + `?gameName=${gameName}`);
    } catch (error) {
        console.log(error);
    }
}

export async function libraryDelete(gameName: string) {
    try {
        return await axios.delete<LibraryPost>(api + `?gameName=${gameName}`);
    } catch (error) {
        console.log(error);
    }
}