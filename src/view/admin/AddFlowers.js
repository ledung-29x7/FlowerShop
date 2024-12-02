import { useEffect, useState } from "react";
import * as apis from "../../apis";
function AddFlower() {
  const [valueAdd, setValueAdd] = useState({
    name: "",
    description: "",
    price: 0,
    occasion_id: 0,
    stock: 0
  });
  function handleChange(e) {
    setValueAdd({ ...valueAdd, [e.target.name]: e.target.value });
  }
  const handleSubmit=(e)=>{
    e.preventDefault();
    const FetchData= async()=>{
        try {
          await apis.addFlower(valueAdd)
          .then(res=>{
            if(res.status === 200){
              alert("sucess");
            }
          })
        } catch (error) {
          console.log(error)
        }
    }
    FetchData();
  };

  return (
    <div className="auth-form">
      <div className=" p-10 pb-0">
        <div className=" flex justify-between w-full h-14 font-bold text-xl border-b border-b-slate-800 ">
          <span>Add Flower</span>
        </div>
        <form onSubmit={handleSubmit} className=" my-7 flex flex-col gap-10">
          <div className=" flex flex-col gap-6">
            <div className=" border-gray-500 border text-right rounded-lg overflow-hidden text-sm h-9 ">
              <input
                className="outline-none w-11/12 h-full"
                placeholder="name"
                type="text"
                name="name"
                onChange={handleChange}
              />
            </div>
            <div className=" border-gray-500 border text-right rounded-lg overflow-hidden text-sm h-9 ">
              <input
                className="outline-none w-11/12 h-full"
                placeholder="description"
                type="text"
                name="description"
                onChange={handleChange}
              />
            </div>
            <div className=" border-gray-500 border text-right rounded-lg overflow-hidden text-sm h-9 ">
              <input
                className="outline-none w-11/12 h-full"
                placeholder="price"
                type="number"
                name="price"
                onChange={handleChange}
              />
            </div>
            <div className=" border-gray-500 border text-right rounded-lg overflow-hidden text-sm h-9 ">
              <input
                className="outline-none w-11/12 h-full"
                placeholder="occasion_id"
                type="number"
                name="occasion_id"
                onChange={handleChange}
              />
            </div>
            <div className=" border-gray-500 border text-right rounded-lg overflow-hidden text-sm h-9 ">
              <input
                className="outline-none w-11/12 h-full"
                placeholder="stock"
                type="number"
                name="stock"
                onChange={handleChange}
              />
            </div>
          </div>
          <div className="border-gray-500 border text-right rounded-lg overflow-hidden h-9">
            <button
              type="submit"
              className=" bg-blue-500 h-full w-full font-bold text-white"
            >
              Add
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
export default AddFlower;
