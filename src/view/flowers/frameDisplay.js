import { Link } from "react-router-dom"
function FrameDisplay (props) {
    return(
        <div className="flex flex-col h-full overflow-hidden text-left border pb-1 rounded-md">
            <div className="block overflow-hidden ">
                <Link className="w-full" to={props.link} > 
                    <img className="w-full h-auto block  max-w-full box-border" width={420} height={420} src={props.src} alt=".."/>
                  
                </Link>
            </div>
            <div className="flex-1 order-3 z-10 bg-[#F1EFEB00] pt-5">
                <Link className=" h-auto overflow-auto block" to={props.link} >
                    {props.name}
                </Link>
                <span className="">
                    <span className="">
                        $
                    </span>
                    {props.price}
                </span>
            </div>
            <div>
                
            </div>
        </div>
    )
}
export default FrameDisplay