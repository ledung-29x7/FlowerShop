import { useEffect, useState } from "react";
import * as apis from "../../apis"

function HomeAdmin() {
    const [flower, setFlower] = useState({});

    useEffect(()=>{
        const FetchApi = async() => {
            try {
                await apis.getAllFlowers()
                .then(res=>{
                    if(res.status === 200){
                        setFlower(res.data)
                    }
                })
                .catch(error =>{
                    console.log(error)
                })
            } catch (error) {
                console.log(error)
            }
        }
        FetchApi()
    },[])

    return (
        <div>
            <div className="">
                <table className="">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Name</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <tb>
                                <img src={flower} alt=""/>
                            </tb>
                            <tb>
                                {flower?.name}
                            </tb>
                            <tb>
                                {flower?.price}
                            </tb>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
}
export default HomeAdmin;
