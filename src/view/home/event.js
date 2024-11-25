import { Link } from "react-router-dom";
function Event (props) {
    return(
        <div>
            <div>
                <div>
                    <div>
                        <img src={props.src} alt="..."/>
                    </div>
                </div>
                <div>
                    <div>
                        <div>
                            <div>
                                <div>
                                    <h3>{props.title}</h3>
                                </div>
                            </div>
                            <div>
                                <div>
                                    {props.decription}
                                </div>
                            </div>
                            <div>
                                <div>
                                    <Link to={props.link} ></Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Event;