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
                Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzA0MjI0MCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.6jfvI385GS2_3YutIzKsNw__kEWbTkD-HZiZyRjh5qY"
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
                Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzA0MjI0MCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.6jfvI385GS2_3YutIzKsNw__kEWbTkD-HZiZyRjh5qY"
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
                    Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzA0MjI0MCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.6jfvI385GS2_3YutIzKsNw__kEWbTkD-HZiZyRjh5qY"
                },
            })
            resolve(response.data);
        } catch (error) {
            reject(error);
        }
    })
}