import { useEffect, useState } from "react";
import * as apis from "../../apis"
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";
import { useStore } from "react-redux";


function HomeAdmin() {
    const [flower, setFlower] = useState([]);
    const [addflower,setAddFlower] =useState({

    })
    const FetchApi = async() => {
        try {
            await apis.getAllFlowers()
            .then(res=>{
                if(res.status === 200){
                    console.log(res)
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
    useEffect(()=>{
        FetchApi()
    },[])
    
    const handleDelete = async(id)=>{
        try {
            const res=await apis.Delete(id);
            if (res.status ===200){
                FetchApi();
                console.log("delete success")
            }
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" class="px-6 py-3">Image</th>
                            <th scope="col" class="px-6 py-3">Name</th>
                            <th scope="col" class="px-6 py-3">description</th>
                            <th scope="col" class="px-6 py-3">Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {flower.map((res)=>
                            <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                           <td>
                                <img src={res} alt=""/>
                            </td>
                            <td>
                                {res?.name}
                            </td>
                            <td >
                            {res?.description}
                            </td>
                            <td>
                                {res?.price}
                            </td>
                            <td class="px-6 py-4 text-right">
                    <Link to="/admin/home/add" class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Add</Link>
                </td>
                <td class="px-6 py-4 text-right">
                    <Link to={`/admin/home/edit/${res?.lower_id}`} class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Edit</Link>
                </td>
                {/* <td class="px-6 py-4 text-right">
                    <Link to={`/admin/home/delete/${res.lower_id}`} class="font-medium text-blue-600 dark:text-blue-500 hover:underline">delete</Link>
                </td> */}
                <td class="px-6 py-4 text-right">
                    <button onClick={()=>handleDelete(res?.flower_id)} class="font-medium text-blue-600 dark:text-blue-500 hover:underline">delete</button>
                </td>


                        </tr>
                        )}
                    </tbody>
                </table>
            </div>
    );
}
export default HomeAdmin;
