import AddFlower from "./view/admin/AddFlowers";
import EditFlower from "./view/admin/EditFlowers";
import HomeAdmin from "./view/admin/HomeAdmin";
import DetailFlower from "./view/detail/DetailFlower";
import FlowerPage from "./view/flowers/FlowerPage";
import HomePage from "./view/home/HomePage";
import Cart from "./view/paymen/cart";

var router = [
    {
        path: "/home",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <HomePage/>,
        layout: "/client",
    },
    {
        path: "/flowers",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <FlowerPage/>,
        layout: "/client",
    },
    {
        path: "/flowers/:id",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <DetailFlower/>,
        layout: "/client",
    },
    {
        path: "/cart",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <Cart/>,
        layout: "/client",
    },
    {
        path: "/home",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <HomeAdmin/>,
        layout: "/admin",
    },
    {
        path: "/home/add",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <AddFlower/>,
        layout: "/admin",
    },
    {
        path: "/home/edit/:id",
        name: "Home",
        icon: "ni ni-tv-2 text-primary",
        component: <EditFlower/>,
        layout: "/admin",
    },


];

export default router;
