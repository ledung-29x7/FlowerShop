import { Link } from "react-router-dom"
import FrameFlower from "./frameFlower"
import Event from "./event"

function HomePage () {
    return (
        <div>
            <div className="-mt-32 pt-24 px-7 h-svh bg-[#F1EFEB]">
                <div className=" h-full max-w-7xl flex m-auto">
                    <div className=" w-5/12 flex content-center items-center justify-start px-14 flex-wrap">
                        <div className=" ml-5 mb-5 w-full">
                            <h3 className="flex flex-col mt-2 mb-1">
                                <span className=" text-5xl">
                                    We tell stories
                                </span>
                                <span className="text-5xl mt-4">
                                    With Flower
                                </span>
                            </h3>
                        </div>
                        <div className=" ml-5 mb-5 w-full ">
                            <div className=" mt-3">
                                <Link className=" border-2 border-black px-9 py-4 border-solid rounded-full hover:bg-[#6A6E49] hover:text-white hover:border-[#6A6E49]" >SHOP NOW</Link>
                            </div>
                        </div>
                    </div>
                    <div className=" w-7/12 flex content-center items-center justify-start px-14 flex-wrap">
                        <div className=" text-right mb-5 w-full ">
                            <div>
                            <img fetchpriority="high" decoding="async" width="730" height="816" 
                                src="https://fiore.vamtam.com/wp-content/uploads/2021/12/hero-img.png" 
                                class="h-auto max-w-full inline-block w-[31vw]" alt="" 
                                srcset="https://fiore.vamtam.com/wp-content/uploads/2021/12/hero-img.png 730w, https://fiore.vamtam.com/wp-content/uploads/2021/12/hero-img-630x704.png 630w, https://fiore.vamtam.com/wp-content/uploads/2021/12/hero-img-64x72.png 64w, https://fiore.vamtam.com/wp-content/uploads/2021/12/hero-img-268x300.png 268w" 
                                sizes="(max-width: 730px) 100vw, 730px"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className=" mt-44 mb-8  px-8">
                <div className=" max-w-7xl m-auto">
                    <div className="flex content-center items-center justify-center">
                        <h2 style={{fontFamily: "Italiana,sans-serif"}} className=" text-5xl">
                            Seasons Finest
                        </h2>
                    </div>
                </div>
            </div>

            <div className="mt-8">
                <div className="flex m-auto max-w-7xl">
                    <div className="block box-border p-8 ">
                    <div className=" grid grid-flow-col grid-cols-3 gap-x-14 gap-y-10 w-full">
                        <FrameFlower/>
                        <FrameFlower/>
                        <FrameFlower/>
                    </div>
                    </div>
                </div>
            </div>

            <div>
                <Event src="https://fiore.vamtam.com/wp-content/uploads/2022/03/iStock-1256676691.jpg"/>
            </div>
        </div>
    )
}
export default HomePage