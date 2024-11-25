import { Route,Routes,Navigate } from "react-router-dom";
import FooterAdmin from "../components/Footers/FooterAdmin";
import router from "../router";
import HeaderAdmin from "../components/Headers/HeaderAdmin";
import SideBar from "../components/Sidebar/Sidebar";
function AdminLayout() {

    const getRoutes = (routes) => {
        return routes.map((prop, key) => {
            if (prop.layout === "/admin") {
                return (
                    <Route path={prop.path} element={prop.component} key={key} exact />
                );
            } else {
                return null;
            }
        });
    };

    return (
        <div>
            <SideBar/>
            <div className="main-content">
                <HeaderAdmin/>
                <div className="p-4 sm:ml-64">
                    <Routes>
                        {getRoutes(router)}
                            <Route path="*" element={<Navigate to="/admin/home" replace />} />
                    </Routes>
                </div>
                <div>
                    <FooterAdmin/>
                </div>
            </div>

        </div>
    );
}

export default AdminLayout;
