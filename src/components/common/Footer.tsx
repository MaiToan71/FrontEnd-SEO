import React from "react";

const Footer = () => (
  <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto pl-4 pr-4  sm:pl-0 sm:pr-0">
    <div className="container grid lg:grid-cols-2 lg:gap-2 md:grid-cols-1 md:gap-1">
      <div className="footer-left text-[#fff] md:flex md:justify-center">
        <h3 className="uppercase font-bold text-lg">
          Trung tâm thi bằng lái xe tại hà nội
        </h3>
        <p>Địa chỉ: Trung Tâm Đào Tạo Lái Xe Mỹ Đình 63 Đ. Lê Đức Thọ, Mỹ Đình, Từ
                Liêm, Hà Nội</p>
        <p>SĐT 1:  037902555</p>
        <p>SĐT 2: 033241888</p>
        <p className="uppercase mt-10 text-xl">NHANH CHÓNG - UY TÍN - GIÁ RẺ</p>
      </div>
      <div className="w-full ">
      <iframe className="w-full padi" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14896.294758524169!2d105.7696157!3d21.0297373!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3134553e766a9b09%3A0xf32510cf8792335f!2zVHJ1bmcgVMOibSDEkMOgbyBU4bqhbyBMw6FpIFhlIE3hu7kgxJDDrG5o!5e0!3m2!1svi!2s!4v1708347866980!5m2!1svi!2s"  style={{border:0}} ></iframe>
      </div>
    </div>
  </div>
);

export default Footer;
