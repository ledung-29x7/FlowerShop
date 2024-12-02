import { useStore } from "../../store/contexts";
import { actions } from "../../store/action";
import * as apis from "../../apis";
import { useParams } from "react-router-dom";

function Delete () {
    const {id} = useParams();

    const [,dispatch] = useStore()

    const handleDelete = async () => {
    try {
        const res = await apis.Delete(id);
        console.log(res)
        if (res.status === 204) {
        dispatch(actions.ModalSuccsessfull(true));
        dispatch(actions.ModalDelete(false));
        }
    } catch (error) {
        console.error(error);
    }
};
    return(
        <div className="auth-form  flex">
            <div className=" m-auto px-10 flex flex-col gap-11">
                <h4 className=" font-semibold text-lg">Bạn chắc chắn muốn xóa thông tin này? </h4>
                <div className=" flex justify-end gap-6">
                    <button onClick={handleDelete}
                        className=" px-5 py-2 bg-red-500 text-white rounded-lg"
                    >
                         Xóa
                    </button>
                
                </div>
            </div>
        </div>
    )
}
export default Delete;