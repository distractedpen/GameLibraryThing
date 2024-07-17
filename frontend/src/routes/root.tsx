import {Link} from "react-router-dom";

export default function Root() {
    return (
        <div className="flex items-center justify-center">
            <Link to={"library"} className="rounded-xl bg-amber-500 self-center">Go to Library</Link>
        </div>
    );
}