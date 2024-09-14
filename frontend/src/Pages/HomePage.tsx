import Button from "../components/Button";

export default function HomePage() {
    return (
        <div className="flex flex-col items-center w-screen h-screen justify-evenly bg-[#DFDFDF]">
            <h1 className={"text-4xl"}>Game Library Thing</h1>
            <Button isLink={true} linkTo={"login"}>Login</Button>
        </div>
    );
}
