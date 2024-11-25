import actionType from "../actions/actionType"

const initState = {
    plamtSale: [],
    plamtName: "",
    checklogin: false
}

const appReducer = (state = initState,action) =>{
    switch (action.type) {
        case actionType.GETHOME:
            return {
                ...state,
                plamtSale: action.homeData
            }
        
        default:
            return state
    }
}

export default appReducer;