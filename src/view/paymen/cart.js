import { Link } from "react-router-dom"

function Cart () {
    return(
        <div className="">
            <div className="">
                <div className="">
                    <h4 className=" text-2xl ">Your Cart</h4>
                    <form className="">
                        <div></div>
                        <div>
                            <table className="">
                                <thead></thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <Link to={""}>
                                                <img className="block w-20" width={420} height={420} src="https://fiore.vamtam.com/wp-content/uploads/2022/02/9-630x630.jpg" alt="..."/>
                                            </Link>
                                        </td>
                                        <td>
                                            <div>
                                                <span>{"Bisous"}</span>
                                            </div>
                                            <div>
                                                <span>$ {"120"}</span>
                                            </div>
                                            <dl className=" text-sm">
                                                <dt className=" float-left mr-1 inline-block">
                                                    Select size
                                                </dt>
                                                <dd className="">
                                                    {"Medium"}
                                                </dd>
                                                <dt className="">
                                                    In-Store Pickup:
                                                </dt>
                                                <dd className="">
                                                    {"Chicago"}
                                                </dd>
                                            </dl>
                                            
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </form>
                </div>
                <div></div>
            </div>
        </div>
    )
}
export default Cart