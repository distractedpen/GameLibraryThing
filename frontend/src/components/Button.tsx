import React from "react";
import { Link } from "react-router-dom";

export default function Button({ isLink, linkTo, handleClick, children }: 
{ 
    isLink: boolean,
    linkTo?: string,
    handleClick?: ((e: any) => void), 
    children: React.ReactNode 
}) {

    const className = "flex justify-center items-center text-2xl rounded-2xl  bg-lavender_(web) shadow-black drop-shadow w-40 h-20";

    return (
        <>
        { isLink ? 
            (
                <Link className={className} to={linkTo === undefined ? "" : linkTo}>
                    {children}
                </Link>
            ) : 
            (
                <button className={className} onClick={handleClick}>
                    {children}
                </button>
            )
        }
        </>
    );

}
