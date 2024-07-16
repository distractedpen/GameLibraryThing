import {ReactNode} from "react";

export default function CardContainer({ children }: { children: ReactNode }) {
    return(
       <div className="container justify-center bg-amber-400 w-5/6 h-5/6 flex flex-row flex-wrap overflow-auto m-2">
           {children}
       </div>
    )
}