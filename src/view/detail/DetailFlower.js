import { Link, useParams } from "react-router-dom";
import * as apis from "../../apis";
import { useEffect, useState } from "react";

function DetailFlower() {
  const { id } = useParams();
  const [flower, setFlower] = useState({});
  const FetchApi = async () => {
    try {
      await apis.getFlowerById(id).then((res) => {
        if (res.status === 200) {
          setFlower(res.data);
        }
      });
    } catch (error) {
      console.log(error);
    }
  };
  useEffect(() => {
    FetchApi();
  }, []);
  return (
    <div className="">
      <div className=" overflow-hidden px-8 ">
        <div className="flex max-w-7xl mx-auto ">
          <div className="w-4/6 flex">
            <div className=" flex w-full items-start pe-16">
              <div className="w-full">
                <img
                className="w-full"
                    
                  loading="lazy"
                  src="https://fiore.vamtam.com/wp-content/uploads/2022/02/9-630x630.jpg"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div className="w-1/3 flex">
            <div className="flex w-full flex-col content-start">
              <div className="pb-8">
                <div className="max-w-sm mx-auto">
                    <div className="mb-3">
                        <h3 className=" text-4xl ">{flower?.name}</h3>
                    </div>
                    <div className="mb-3 text-2xl font-semibold">
                        <span>${flower?.price}</span>
                    </div>
                </div>
              </div>

              <div className="">
                <form class="max-w-sm mx-auto">
                  <div className="pb-7">
                    <label
                      for="countries"
                      class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                    >
                      Select your country
                    </label>
                    <select
                      id="countries"
                      class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    >
                      <option>United States</option>
                      <option>Canada</option>
                      <option>France</option>
                      <option>Germany</option> 
                    </select>
                  </div>
                  <div className="pb-7">
                    <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                      Choose a delivery date
                    </label>
                    <div class="relative max-w-sm">
                      <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                        <svg
                          class="w-4 h-4 text-gray-500 dark:text-gray-400"
                          aria-hidden="true"
                          xmlns="http://www.w3.org/2000/svg"
                          fill="currentColor"
                          viewBox="0 0 20 20"
                        >
                          <path d="M20 4a2 2 0 0 0-2-2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v2h20V4ZM0 18a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V8H0v10Zm5-8h10a1 1 0 0 1 0 2H5a1 1 0 0 1 0-2Z" />
                        </svg>
                      </div>
                      <input
                        id="datepicker-actions"
                        datepicker
                        datepicker-buttons
                        datepicker-autoselect-today
                        type="date"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="Select date"
                      />
                    </div>
                  </div>
                  <div className="pb-7">
                    <label
                      for="message"
                      class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                    >
                      Your message
                    </label>
                    <textarea
                      id="message"
                      rows="4"
                      class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                      placeholder="Leave a comment..."
                    ></textarea>
                  </div>
                  <div className="flex justify-between">
                    <div>
                      <input
                        type="number"
                        min={1}
                        defaultValue={1}
                        id="number-input"
                        aria-describedby="helper-text-explanation"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="Choose the number of flowers"
                        required
                      />
                    </div>
                    <div>
                      <button class="relative inline-flex items-center justify-center p-0.5 mb-2 me-2 overflow-hidden text-sm font-medium text-gray-900 rounded-lg group bg-gradient-to-br from-purple-600 to-blue-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white dark:text-white focus:ring-4 focus:outline-none focus:ring-blue-300 dark:focus:ring-blue-800">
                        <span class="relative px-5 py-2.5 transition-all ease-in duration-75 bg-white dark:bg-gray-900 rounded-md group-hover:bg-opacity-0">
                          Add to cart
                        </span>
                      </button>
                    </div>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div></div>
      <div></div>
    </div>
  );
}
export default DetailFlower;
