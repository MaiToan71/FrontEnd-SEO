import React, { useEffect, useState } from "react";
import useSWR, { SWRConfig } from "swr";
import useSWRImmutable from "swr/immutable";
import CustomLink from "./CustomLink";
import CustomImage from "./CustomImage";

import { SERVER_BASE_URL } from "../../lib/utils/constant";
import fetcher from "../../lib/utils/fetcher";
import { Category } from "../../lib/types/categoryType";

//images
import hotl from "../../assets/icons/contact_phone.jpg";
import addr from "../../assets/icons/addr.png";
import CategoryAPI from "../../lib/api/category";
import { FRONTEND_URL } from "../../lib/utils/constant";
const Navbar = () => {
  const { data } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/categories`,
    fetcher
  );
  return (
    <>
      <nav className=" border-gray-200 dark:bg-gray-900 backgro bg-[#007242]">
        <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-2">
          <button
            data-collapse-toggle="#navbar-default"
            type="button"
            className=" inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
            aria-controls="navbar-default"
            aria-expanded="false"
          >
            <span className="sr-only">Open main menu</span>
            <svg
              className="w-5 h-5"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 17 14"
            >
              <path
                stroke="currentColor"
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M1 1h15M1 7h15M1 13h15"
              />
            </svg>
          </button>
          <div
            className="hidden w-full md:block md:w-auto "
            id="navbar-default"
          >
            <ul className="  font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0  dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
              <li className="bg-[#007242]" key={0}>
                <CustomLink
                  as={`${FRONTEND_URL}`}
                  href={`${FRONTEND_URL}}`}
                  name={"Trang chủ"}
                  key={0}
                  className="block py-2 px-3  text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              {data &&
                data.map((i: Category, index: number) => {
                  return (
                    <li className="bg-[#007242]" key={i.id}>
                      <CustomLink
                        as={`${FRONTEND_URL}/danh-muc/${i.id}`}
                        href={`${FRONTEND_URL}/danh-muc/${i.id}`}
                        name={i.name}
                        key={index}
                        className="block py-2 px-3  text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                      />
                    </li>
                  );
                })}
            </ul>
          </div>
        </div>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4 ">
        <div className="w-[50%]  flex justify-start ">
       <div>
       <h1 className=" flex-auto text-[29px] text-center font-bold text-[#007242] uppercase ">
          Trung tâm đào tạo <br /> lái xe Hà Nội
        </h1>
       </div>
        </div>
        <div className="flex flex-auto justify-end w-[50%]">
          <div className="  flex flex-auto justify-end">
            <div>
              <CustomImage
                alt="Địa chỉ"
                src={addr.src}
                height={25}
                width={25}
                key={1}
              />
            </div>
            <div>
              <div className="uppercase font-bold ml-3">Địa chỉ</div>
              <div className="m-3">
                Số 49 Ngõ 335 Nguyễn Trãi - Q. Thanh Xuân - Hà Nội
              </div>
            </div>
          </div>
          <div className="flex flex-auto justify-end ">
            <div>
              <CustomImage
                alt="HOTLINE"
                src={hotl.src}
                height={25}
                width={25}
                key={1}
              />
            </div>
            <div>
              <div className="uppercase font-bold ml-3">HOTLINE</div>
              <div className="m-3">0985248802</div>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
