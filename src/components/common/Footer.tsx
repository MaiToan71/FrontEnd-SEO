import React from "react";

const Footer = () => (
  <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto ">
    <div className="container grid grid-cols-2 gap-2">
      <div className="footer-left text-[#fff]">
        <h3 className="uppercase font-bold text-lg">
          Trung tâm đào tạo lái xe hà nội
        </h3>
        <p>Địa chỉ: 49 Ngõ 335 Nguyễn Trãi, Q. Thanh Xuân, TP Hà Nội</p>
        <p>Email: banglaixehanoi.com.vn@gmail.com</p>
        <p>SĐT: 0968.832.699</p>
        <p className="uppercase mt-10 text-xl">NHANH CHÓNG - UY TÍN - GIÁ RẺ</p>
      </div>
      <div>
        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3725.2250070009836!2d105.8193477750302!3d20.983615780654496!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135acf399205a27%3A0x38a14bf5d7410373!2zMTIwIMSQ4buLbmggQ8O0bmcgVGjGsOG7o25nLCDEkOG7i25oIEPDtG5nLCBUaGFuaCBYdcOibiwgSMOgIE7hu5lpLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1708094587233!5m2!1svi!2s"
          width="600"
          height="450"
          style={{ border: 0 }}
        ></iframe>
      </div>
    </div>
  </div>
);

export default Footer;
