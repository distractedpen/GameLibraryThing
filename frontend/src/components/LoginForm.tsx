import Button from "./Button.tsx";
import { useState } from "react";


export default function LoginForm() {

    const [isNewUser, setIsNewUser] = useState(false);

    function handleSignUp() {
        setIsNewUser(true);
    }

    function handleSubmit(e: React.MouseEvent<HTMLFormElement>) {
        e.preventDefault();
        location.pathname = "/library";
    }

    function handleCancel(e: React.MouseEvent<HTMLButtonElement>) {
        e.preventDefault();
        if (isNewUser) {
            location.reload();
        } else {
            location.pathname = "/";
        }
    }

    return (
        <div className={"flex flex-row flex-wrap bg-magnolia rounded-2xl w-2/5 h-3/5 justify-around"}>
            <h1 className={"text-6xl text-center items-start flex-initial w-full"}>{isNewUser ? "Sign Up" : "Login"}</h1>
            <div className={"flex justify-start w-full"}>
                <label className={"text-xl ml-4 mr-10"}>Username: </label>
                <input
                    name={"username"}
                    type={"text"}
                    className={"border-solid border-black border flex-initial w-3/4 h-min"}
                    required />
            </div>
            <div className={"flex justify-start w-full"}>
                <label className={"text-xl ml-4 mr-10"}>Password</label>
                <input
                    name={""}
                    type={"text"}
                    className={"border-solid border-black border flex-initial w-3/4 h-min"}
                    required />
            </div>
            {!isNewUser ? (
                <>
                    <Button handleClick={handleSignUp}>Sign Up</Button>
                    <Button handleClick={handleSubmit}>Login</Button>
                </>
            ) : (
                <>
                    <Button handleClick={handleSubmit}>Login</Button>
                    <Button handleClick={handleCancel}>Cancel</Button>
                </>
            )
            }
        </div>
    )
}
