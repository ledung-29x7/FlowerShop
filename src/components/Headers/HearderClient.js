import { Link, NavLink, useNavigate } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { useState, useEffect } from "react";
import * as apis from "../../apis";
import * as actions from "../../store/actions"

function HeaderClient() {
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const { checklogin } = useSelector(state => state.app)
    const [isChecking, setIsChecking] = useState(false);
    const username = window.sessionStorage.getItem("name")

    useEffect(() => {
        checkLoggedIn();
    }, [checklogin]);

    // hủy Cookie
    function deleteCookie(name) {
        document.cookie =
            name + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    }

    // Hàm để lấy giá trị của một cookie
    function getCookie(name) {
        const cookies = document.cookie.split("; ");
        console.log(cookies)
        for (let cookie of cookies) {
            const [key, value] = cookie.split("=");
            if (key === name) {
                return decodeURIComponent(value);
            }
        }
        return undefined;
    }

    // check xem người dùng đã đăng nhập chưa
    function checkLoggedIn() {
        var token = getCookie("token");
        if (token) {
            // Gọi các API hoặc thực hiện các hành động khác khi người dùng đã đăng nhập
            setIsChecking(true);
        } else {
            // Hiển thị form đăng nhập hoặc các nút chức năng đăng nhập
            setIsChecking(false);
        }
    }

    // handle Logout
    const handleLogout = (e) => {
        e.preventDefault()
        const FetchData = async () => {
            try {
                await apis.logout().then((res) => {
                    if (res.status === 200) {
                        deleteCookie("token");
                        checkLoggedIn();
                        dispatch(actions.checkLogin(false));
                        window.location.reload();
                        navigate("/")
                    }
                });
            } catch (error) {
                console.error(error);
            }
        };
        FetchData();
    };

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
                    {isChecking ?
                        (
                            <div className="flex gap-2 relative justify-center items-center">
                                <button id="dropdownHoverButton" data-dropdown-toggle="dropdownHover" data-dropdown-trigger="hover" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center inline-flex items-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800" type="button">
                                    <img
                                        className=" rounded-full"
                                        width={60}
                                        height={60}
                                        alt="..."
                                        src="https://cdn11.dienmaycholon.vn/filewebdmclnew/public/userupload/files/Image%20FP_2024/hinh-anh-avatar-ca-tinh-nu-2.jpg"
                                    />
                                </button>
                                <div className="ml-2 d-none d-lg-block">
                                    <span className="mb-0 text-sm font-weight-bold">
                                        {username}
                                    </span>
                                </div>
                                {/* Dropdown menu */}
                                <div id="dropdownHover" class="z-10 hidden absolute bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700">
                                    <ul class="py-2 text-sm text-gray-700 dark:text-gray-200" aria-labelledby="dropdownHoverButton">
                                        <li>
                                            <span onClick={handleLogout} class="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">Logout</span>
                                        </li>
                                        
                                    </ul>
                                </div>
                            </div>

                        )
                        :
                        (
                            <span onClick={() => navigate("/client/login")} className="w-auto max-w-full mt-5 font-medium text-sm cursor-pointer">
                                Account
                            </span>
                        )
                    }
                </div>
            </div>
        </div>
    );
}
export default HeaderClient;
