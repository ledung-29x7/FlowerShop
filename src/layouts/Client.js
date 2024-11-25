import { Navigate, Route, Routes } from "react-router-dom";
import HeaderClient from "../components/Headers/HearderClient";
import router from "../router";
import FooterClient from "../components/Footers/FooterClient";

function Client () {

    const getRoutes = (routes) => {
        return routes.map((prop, key) => {
            if (prop.layout === "/client") {
                return (
                    <Route path={prop.path} element={prop.component} key={key} exact />
                );
            } else {
                return null;
            }
        });
    };

    return(
        <>
            <div className="">
                <HeaderClient/>
                <Routes>
                    {getRoutes(router)}
                    <Route path="*" element={<Navigate to="/client/home" replace/>} />
                </Routes>
                <FooterClient/>
            </div>

        </>
    )
}
export default Client