import apis from "../axios";

export const getHome = () => new Promise( async(resolve,reject)=>{
    try {
        const response = await apis({
            url: "/Flower",
            method:"get"
            
        })
        resolve(response)
    } catch (error) {
        reject(error)
    }
})

export const getFlowerById = (id) => new Promise (async(resolve,reject)=>{
    try {
        const response = await apis({
            url: `/Flower/${id}`,
            method: "get"
        })
        resolve(response)
    } catch (error) {
        reject(error)
    }
})

    
