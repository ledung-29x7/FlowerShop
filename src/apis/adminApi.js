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