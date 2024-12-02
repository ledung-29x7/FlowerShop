import axios from "../axios";

export const getAllFlowers = () => new Promise(async(resolve, reject)=>{
    try {
        const response = await axios({
            url:"/Flower",
            method: "get"
        })
        resolve(response)
    } catch (error) {
        reject(error)
    }
})
export const addFlower= (name) => new Promise(async(resolve,reject)=>{
    try{
        const response = await axios({
            url:"/Flower",
            method:"post",
            data:name,
            headers: {
                Authorization:`Bearer ${window.sessionStorage.getItem("token")}`
            },
        })
        resolve(response)
    }
    catch(error){
        reject(error)
    }
})
export const editFlower=(name)=> new Promise(async(resolve,reject)=>{
    try{
        const response=axios({
            url:"/Flower/{id}",
            method:"put",
            data:name,
            headers: {
                Authorization:`Bearer ${window.sessionStorage.getItem("token")}`
            },
        })
        reject(response)
    }
    catch(error){
        reject(error)
    }
})
export const getInfoEdit =(id)=>{
    new Promise(async (resolve, reject) => {
        try {
            const response = await axios({
                url:`admin/${id}`,
                method: "GET",
                headers: {
                    Authorization:`Bearer ${window.sessionStorage.getItem("token")}`
                },
            })
            resolve(response.data);
        } catch (error) {
            reject(error);
        }
    })
}