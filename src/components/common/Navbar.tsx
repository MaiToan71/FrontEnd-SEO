import React from "react";
import CustomLink from "./CustomLink";
import CustomImage from "./CustomImage";

//images
import hotl from "../../assets/icons/contact_phone.jpg"
import addr from "../../assets/icons/addr.png";

const Navbar = () => {
  return (
    <>
      <nav className=" border-gray-200 dark:bg-gray-900 backgro bg-[#007242]">
        <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
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
              <li className="bg-[#007242]">
                <CustomLink
                  as="/"
                  href="/"
                  name="Trang chủ"
                  key={1}
                  className="block py-2 px-3  text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/gioi-thieu"
                  href="/gioi-thieu"
                  name="Giới thiệu"
                  key={2}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/thi-bang-lai-xe-may-a1"
                  href="/thi-bang-lai-xe-may-a1"
                  name="THI BẰNG LÁI XE A1"
                  key={3}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/thi-bang-lai-xe-may-a2-xe-phan-khoi-lon"
                  href="/thi-bang-lai-xe-may-a2-xe-phan-khoi-lon"
                  name="THI BẰNG LÁI XE MÁY A2 - XE PHÂN KHỐI LỚN "
                  key={4}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/tin-tuc"
                  href="/tin-tuc"
                  name="Tin tức"
                  key={5}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/tra-cuu-ho-so"
                  href="/tra-cuu-ho-so"
                  name="Tra cứu hồ sơ"
                  key={6}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
              <li className="bg-[#007242]">
                <CustomLink
                  as="/lien-he"
                  href="/lien-he"
                  name="Liên hệ"
                  key={7}
                  className="block py-2 px-3 text-white rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-black md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
                />
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4 ">
        <h1 className="w-60 flex-auto text-[35px] text-center font-bold text-[#007242] uppercase">
          Trung tâm đào tạo <br /> lái xe Hà Nội
        </h1>
        <div className="flex flex-auto">
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
        <div className="flex flex-auto">
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
            <div className="m-3">
             1234
            </div>
          </div>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
