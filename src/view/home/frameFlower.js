import { Link } from "react-router-dom";

function FrameFlower (props){
    return(
        <div className="flex flex-col overflow-hidden h-full">
            <Link to={""}>
                <img decoding="async" width="420" height="420" 
                src="https://fiore.vamtam.com/wp-content/uploads/2021/12/1-420x420.jpg" 
                class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail entered lazyloaded" 
                alt="" 
                data-lazy-srcset="https://fiore.vamtam.com/wp-content/uploads/2021/12/1-420x420.jpg 420w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-315x315.jpg 315w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-630x630.jpg 630w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-64x64.jpg 64w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-300x300.jpg 300w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-150x150.jpg 150w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1.jpg 760w" 
                data-lazy-sizes="(max-width: 420px) 100vw, 420px" 
                data-lazy-src="https://fiore.vamtam.com/wp-content/uploads/2021/12/1-420x420.jpg" 
                data-ll-status="loaded" 
                sizes="(max-width: 420px) 100vw, 420px" 
                srcset="https://fiore.vamtam.com/wp-content/uploads/2021/12/1-420x420.jpg 420w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-315x315.jpg 315w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-630x630.jpg 630w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-64x64.jpg 64w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-300x300.jpg 300w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1-150x150.jpg 150w, https://fiore.vamtam.com/wp-content/uploads/2021/12/1.jpg 760w"/>
            </Link>
            <div className="">
                <Link className=" pt-9 flex-1 order-3 z-10" to={""}>
                    <h2>
                        {props.name}
                    </h2>
                </Link>
                <span className=" ">
                    <span className="">
                        $
                    </span>
                    {props.price}
                </span>
            </div>
        </div>
    )
}
export default FrameFlower;