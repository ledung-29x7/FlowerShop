import FrameDisplay from "./frameDisplay"
import * as apis from "../../apis"
import { useEffect, useRef, useState } from "react"

function FlowerPage () {
    const [flower, setFlower] = useState([])

    const catagoryFilter = (name) => {


        return(
            <div className="block box-border ">
                <div className=" pb-5 border-b mb-5">
                    <div className="pt-2">
                        <button className=" cursor-pointer">{name}</button>
                    </div>
                </div>
            </div>
        )
    }

    useEffect(()=>{
        const FetchApi = async() =>{
            try {
                await apis.getHome()
                .then(res=>{
                    if(res.status === 200){
                        setFlower(res.data)
                    }
                })
            } catch (error) {
                console.log(error)
            }
        }
        FetchApi()
    },[])

    return (
        <div className="">
            <div className="px-7 pt-7 pb-28">
            <div className="flex max-w-7xl mx-auto box-border">
                <div className="me-20 w-1/3">
                    <div className="">
                        <div className="">
                            <h2 className=" text-5xl">Flowers</h2>
                        </div>
                        <div className="w-full relative">
                            <div className="mt-5  pt-1">
                                {catagoryFilter("Price range")}
                                {catagoryFilter("Category")}
                                {catagoryFilter("Brand")}
                            </div>
                        </div>
                    </div>
                </div>
                
                <div className="pt-28 w-2/3">
                    <div className="border-t">
                        <div className=" grid pt-1 m-0 grid-cols-3 gap-16 clear-both">
                            <FrameDisplay src="https://fiore.vamtam.com/wp-content/uploads/2022/04/one_last_kiss__49979.1640010425-420x420.jpg" 
                                link={`/client/flowers/${flower?.id}`}
                                name="Bisous"
                                price="100.00 - $140.00"
                            />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
        </div>
    )
}

export default FlowerPage