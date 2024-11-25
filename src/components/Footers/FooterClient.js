import { Link } from "react-router-dom";

function FooterClient () {
    return(
        <div>
            <div>
                <div>
                    <div>
                        <div>
                            <Link to={"/client/home"} >Fióre</Link>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div>
                    <div>
                        <div></div>
                        <div></div>
                    </div>
                    <div>
                        <div></div>
                        <div></div>
                        <div></div>
                        <div></div>
                    </div>
                    <div>
                        
                    </div>
                </div>
            </div>
            <div>
            <div>
                <div>
                    © 2024</div>
                    <div>
                        VamTam. All rights reserved.
                    </div>
                </div>
                <div>
                    <div>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </div>
                </div>
            </div>
        </div>
    )
}

export default FooterClient;