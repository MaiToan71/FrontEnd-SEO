import CustomLink from "../components/common/CustomLink";
export default function Page() {
  return (
    <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
      <h2 className="uppercase text-[20px] text-page-green font-semibold">TRUNG TÂM ĐÀO TẠO BẰNG LÁI XE HÀ NỘI</h2>
      <div>
        <p>
          Trung tâm đào tạo {" "}
          <CustomLink
            href="/thi-bang-lai-xe-may-a1"
            className="font-bold"
            name="bằng lái xe"
            key={1}
            as="/thi-bang-lai-xe-may-a1"
          /> {" "}
           Hà Nội được thành lập tháng 10/2011. Hàng tháng trung tâm tiếp nhận hồ
          sơ cho từ 800 – 1000 bạn. Với nhiều năm kinh nghiệm trong nghành,
          chúng tôi tự tin giúp các bạn có được chiếc bằng lái xe dễ dàng và phù
          hợp với mình nhất: …{" "}
        </p>
        <p>
          Trung tâm không tiếp nhận bất cứ trường hợp mua, bán bằng nào, vì nếu
          không đi thi đều là bằng giả, như thế là vi phạm pháp luật.
        </p>
        <p>
          {" "}
          Thi đỗ được nhận bằng và hồ sơ gốc trả cho bạn lưu trữ, nên các bạn
          yên tâm về chiếc{" "}
          <CustomLink
            href="/thi-bang-lai-xe-may-a1"
            className="font-bold"
            name="bằng lái xe"
            key={1}
            as="/thi-bang-lai-xe-may-a1"
          />{" "}
          của mình.
        </p>
      </div>
    </nav>
  );
}
