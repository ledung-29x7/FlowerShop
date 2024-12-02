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
                Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzExMDIwOCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.az3cwuC_J_pZ4gSsRih2AeoD6PtrLrkyLpKt0GsLruU"

            },
        })
        resolve(response)
    }
    catch(error){
        reject(error)
    }
})
// export const editFlower=(id,put)=> new Promise(async(resolve,reject)=>{
//     try{
//         const response=axios({
//             url:`/Flower/${id}`,
//             method:"put",
//             data:put,
//             headers: {
//                 Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzA3ODYwOCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.jj_63Ycn2jji7tLBQBA4OYv5GSNNTC7S5qdC_BK38rs"
//             },
//         })
//         reject(response)
//     }
//     catch(error){
//         reject(error)
//     }
// })
export const editFlower = (id, put) =>
    new Promise(async (resolve, reject) => {
      try {
        const response = await axios({
          url: `/Flower/${id}`,
          method: "put",
          data: put,
          headers: {
            Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzExMDIwOCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.az3cwuC_J_pZ4gSsRih2AeoD6PtrLrkyLpKt0GsLruU"

          },
        });
        resolve(response);
      } catch (error) {
        reject(error);
      }
    });
// export const editFlower = (id, name) =>
//     new Promise(async (resolve, reject) => {
//       try {
//         // Construct FormData
//         const formData = new FormData();
//         formData.append("name", name);
  
//         const response = await axios({
//           url: `/api/Flower/${id}`, // Correct the URL
//           method: "put",
//           data: formData, // Use FormData
//           headers: {
//             "Content-Type": "multipart/form-data",
//             Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzA4Mjg1OCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.sG4MxQKZCZp1s0PhaY8G5Tqa4p19Y_KzuyeWjK-RNYU"

//           },
//         });
  
//         resolve(response);
//       } catch (error) {
//         console.error("Error in editFlower API:", error.response || error);
//         reject(error);
//       }
//     });
  
  
export const getInfoEdit =(ad,id)=>{
    new Promise(async (resolve, reject) => {
        try {
            const response = await axios({
                url:`/Flower/${id}`,
                method: "GET",
                headers: {
                    Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzExMDIwOCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.az3cwuC_J_pZ4gSsRih2AeoD6PtrLrkyLpKt0GsLruU"
                },
            })
            resolve(response.data);
        } catch (error) {
            reject(error);
        }
    })
}
export const Delete = (id) =>
    new Promise(async (resolve, reject) => {
      try {
        const response = await axios({
            url:`/Flower/${id}`,
          method: "delete",
          withCredentials: true,
          headers: {
            Authorization:"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRFVPTkdUVUFOIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZHVvbmd0dWFuaGQ5N0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczMzExMDIwOCwiaXNzIjoiTGVEdW5nIiwiYXVkIjoiVDIzMDhNIn0.az3cwuC_J_pZ4gSsRih2AeoD6PtrLrkyLpKt0GsLruU"
        },
        });
        resolve(response);
      } catch (error) {
        reject(error);
      }
    });