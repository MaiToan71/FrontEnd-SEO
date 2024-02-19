import React from "react";

const Footer = () => (
  <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto ">
    <div className="container grid grid-cols-2 gap-2">
      <div className="footer-left text-[#fff]">
        <h3 className="uppercase font-bold text-lg">
          Trung tâm thi bằng lái xe tại hà nội
        </h3>
        <p>Địa chỉ: 49 Ngõ 335 Nguyễn Trãi, Q. Thanh Xuân, TP Hà Nội</p>
        <p>Email: banglaixehanoi.com.vn@gmail.com</p>
        <p>SĐT: 0968.832.699</p>
        <p className="uppercase mt-10 text-xl">NHANH CHÓNG - UY TÍN - GIÁ RẺ</p>
      </div>
      <div>
      <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14896.294758524169!2d105.7696157!3d21.0297373!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3134553e766a9b09%3A0xf32510cf8792335f!2zVHJ1bmcgVMOibSDEkMOgbyBU4bqhbyBMw6FpIFhlIE3hu7kgxJDDrG5o!5e0!3m2!1svi!2s!4v1708347866980!5m2!1svi!2s" width="600" height="450" style={{border:0}} ></iframe>
      </div>
    </div>
  </div>
);

export default Footer;
