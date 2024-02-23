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
      <nav className="bg-white border-gray-200 dark:bg-gray-900 dark:border-gray-700">
        <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
          <a
            href="#"
            className="flex items-center space-x-3 rtl:space-x-reverse"
          >
            <h1 className=" flex-auto text-[15px] text-center font-bold text-[#007242] uppercase lg:hidden">
            TRUNG TÂM THI BẰNG LÁI XE <br /> TẠI HÀ NỘI
            </h1>
          </a>
          <button
            data-collapse-toggle="navbar-dropdown"
            type="button"
            className="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
            aria-controls="navbar-dropdown"
            aria-expanded="false"
          >
            <span className="sr-only">Mở danh sách chức năng</span>
            <svg
              className="w-5 h-5"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 17 14"
            >
              <path
                stroke="currentColor"
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M1 1h15M1 7h15M1 13h15"
              />
            </svg>
          </button>
          <div
            className="hidden w-full md:block md:w-auto"
            id="navbar-dropdown"
          >
            <ul className="flex flex-col font-medium p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:space-x-8 rtl:space-x-reverse md:flex-row md:mt-0 md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
              <li className="" key={0}>
                <CustomLink
                  as={`${FRONTEND_URL}`}
                  href={`${FRONTEND_URL}}`}
                  html={"Trang chủ"}
                  key={0}
                  className="block py-2 px-3 text-gray-900 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />{" "}
              </li>
              {data &&
                data.map((i: Category, index: number) => {
                  return (
                    <li key={i.id}>
                      <CustomLink
                        as={`${FRONTEND_URL}/danh-muc/${i.id}`}
                        href={`${FRONTEND_URL}/danh-muc/${i.id}`}
                        html={i.name}
                        key={index}
                        className="block py-2 px-3 text-gray-900 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                      />
                    </li>
                  );
                })}
            </ul>
          </div>
        </div>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4 flex-col lg:flex-row ">
        <div className=" flex justify-start  w-full lg:w-[50%] ">
          <div className=" w-full lg:w-auto">
            <h1 className=" flex-auto text-center font-bold text-[#007242] uppercase   text-[18px]  lg:text-[29px] hidden lg:block">
              TRUNG TÂM THI BẰNG LÁI XE <br /> TẠI HÀ NỘI
            </h1>
          </div>
        </div>
        <div className="flex flex-auto justify-end   flex-wrap  w-full lg:w-[50%] ">
          <div className="  flex  justify-start lg:justify-end w-full lg:w-[70%] ">
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
              <div className="m-3 ">
                Trung Tâm Đào Tạo Lái Xe Mỹ Đình 63 Đ. Lê Đức Thọ, Mỹ Đình, Từ
                Liêm, Hà Nội
              </div>
            </div>
          </div>
          <div className="flex justify-start lg:justify-end w-full lg:w-[30%] ">
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
              <div className="m-3">033241888</div>
              <div className="m-3" style={{ marginTop: "-10px" }}>
                037902555
              </div>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
