import { Link, NavLink } from "react-router-dom";

function HeaderClient() {
    return (
        <div className=" flex mr-auto ml-auto pt-2">
            <div className="w-2/12">
                <div className="flex w-full ms-7 flex-wrap content-start ">
                    <span className="w-auto max-w-full mt-5 font-medium text-sm">SEARCH</span>
                </div>
            </div>
            <div className="w-2/3">
                <div className=" text-center w-full">
                    <div className=" flex justify-center ">
                        <Link to={"/client/home"} className=" text-center">
                            <img
                                width="103"
                                height="59"
                                src="https://fiore.vamtam.com/wp-content/uploads/2021/12/logo-black.svg"
                                class=" max-w-full h-auto w-24 in"
                                alt=""
                            />
                        </Link>
                    </div>
                </div>
                <div className="flex justify-center m-auto">
                    <NavLink
                        to="/client/home"
                        className={" font-medium leading-5 text-sm me-4 py-6"}
                    >
                        HOME
                    </NavLink>
                    <NavLink
                        to="/client/flowers"
                        className={"font-medium leading-5 text-sm ms-4 me-4 py-6"}
                    >
                        FLOWERS
                    </NavLink>
                    <NavLink
                        to="/client/home"
                        className={"font-medium leading-5 text-sm ms-4 me-4 py-6"}
                    >
                        SERVICES
                    </NavLink>
                    <NavLink
                        to="/client/home"
                        className={"font-medium leading-5 text-sm ms-4 py-6"}
                    >
                        FLORAL CLASSES
                    </NavLink>
                </div>
            </div>
            <div className="w-2/12">
                <div className="flex w-full ms-7 flex-wrap content-start">
                    <span className="w-auto max-w-full mt-5 font-medium text-sm">
                        Account
                    </span>
                </div>
            </div>
        </div>
    );
}
export default HeaderClient;
