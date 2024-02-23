// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";
// import required modules
import { Autoplay, Pagination, Navigation } from "swiper/modules";
// Import Swiper styles
import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/autoplay";
import CustomLink from "../components/common/CustomLink";
import CustomImage from "../components/common/CustomImage";
import useSWRImmutable from "swr/immutable";
import { SERVER_BASE_URL } from "../lib/utils/constant";
import DOMPurify from "isomorphic-dompurify";
import fetcher from "../lib/utils/fetcher";
import { FRONTEND_URL } from "../lib/utils/constant";

import book from "../assets/icons/book-1.png";
import deadline from "../assets/icons/deadline-1.png";
import speaker from "../assets/icons/speaker.png";
import student from "../assets/icons/student.png";
import motobike from "../assets/icons/motobike.jpg";
export default function Page() {
  const { data } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/home/hot`,
    fetcher
  );
  const { data: banners } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/home/banners`,
    fetcher
  );
  const listImages: any = banners;

  return (
    <>
      <nav>
        <Swiper
          centeredSlides={true}
          autoplay={{
            delay: 3000,
            disableOnInteraction: false,
          }}
          pagination={{
            clickable: true,
          }}
          navigation={true}
          modules={[Autoplay, Pagination, Navigation]}
          className="mySwiper"
          slidesPerView={"auto"}
        >
          {listImages &&
            listImages.map((i: any, index: number) => {
              return (
                <>
                  <SwiperSlide key={SERVER_BASE_URL + i.imagePath}>
                    <CustomImage
                      alt={i.caption}
                      src={SERVER_BASE_URL + i.imagePath}
                      height={500}
                      width={500}
                      key={index}
                      className="w-full"
                    />
                  </SwiperSlide>
                </>
              );
            })}
        </Swiper>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4 pl-4 pr-4  sm:pl-0 sm:pr-0  ">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          TRUNG TÂM ĐÀO TẠO BẰNG LÁI XE HÀ NỘI
        </h2>
        <p className="pt-8">
          Trung tâm thi bằng lái xe Hà Nội được thành lập 12/3/2009. Luôn đi đầu
          trong công tác đào tạo và tổ chức thi giấy phép lái xe, trung tâm đạt
          rất nhiều thành tích đáng nổi bật. Hàng tháng trung tâm tiếp nhận từ
          1800-2000 học viên với tỉ lệ đỗ trên 90%. Với nhiều năm đạt thành tích
          xuất sắc cùng với nhiều giải thưởng cao quý trong công tác giảng dạy,
          chúng tôi tự tin giúp các bạn học viên có được tấm bằng lái xe một
          cách nhanh chóng và hiệu quả nhất.
        </p>
        <p className="pt-2">
          Trung tâm từ chối tiếp nhận bất cứ trường hợp mua bán bằng trái phép,
          vì nếu không đi thi, không ôn luyện đều là bằng giả, có thể xử lý hình
          sự nếu gây hậu quả nghiêm trọng.
        </p>
        <p className="pt-2">
          Thi đỗ học viên sẽ được nhận bằng lái xe + hồ sơ gốc qua dịch vụ công
          Bưu điện liên kết với sở GTVT, bưu kiện sẽ được gửi về nhà sau 7-10
          ngày làm việc .
        </p>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4  pl-4 pr-4  sm:pl-0 sm:pr-0">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          CÁC KHÓA HỌC LÁI XE (TỔ CHỨC LIÊN TỤC TRONG THÁNG)
        </h2>
        <div className="mx-auto max-w-2xl sm:px-6  lg:max-w-7xl lg:px-8 w-full">
          <div className="mt-6 grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-3 xl:gap-x-8">
            {data &&
              data.map((i: any, index: number) => {
                let productImage = "../assets/default.jpg";
                if (i.images.length > 0) {
                  productImage = i.images[0].imagePath;
                }
                return (
                  <>
                    {" "}
                    <div className="group relative">
                      <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-md bg-gray-200 lg:aspect-none group-hover:opacity-75 lg:h-80">
                        <CustomImage
                          alt="demo"
                          height={300}
                          width={200}
                          className="h-full w-full object-cover object-center lg:h-full lg:w-full"
                          src={SERVER_BASE_URL + productImage}
                        />
                      </div>
                      <div className="mt-4 ">
                        <div>
                          <h3 className="text-center text-gray-700 font-medium">
                            <CustomLink
                              html={`<span aria-hidden="true" className="absolute inset-0">${i.title}</span>`}
                              as="http://localhost:3000/"
                              href="http://localhost:3000/"
                              className=""
                              key={index}
                            />
                          </h3>
                          <p
                            className="mt-1 text-sm text-gray-500"
                            dangerouslySetInnerHTML={{
                              __html: DOMPurify.sanitize(i.description),
                            }}
                          ></p>
                        </div>
                      </div>
                      <div className="flex justify-center mt-1">
                        <CustomLink
                          html={`Tìm hiểu thêm`}
                          as={`${FRONTEND_URL}/${i.id}`}
                          href={`${FRONTEND_URL}/${i.id}`}
                          className="text-white bg-gradient-to-r from-green-400 via-green-500 to-green-600 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-green-300 dark:focus:ring-green-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 mb-2"
                          key={index}
                        />
                      </div>
                    </div>
                  </>
                );
              })}
          </div>
        </div>
      </nav>
      <nav className=" max-w-screen-xl items-center justify-between mx-auto mt-4 pl-4 pr-4  sm:pl-0 sm:pr-0">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          CÁC CON SỐ VỀ THI BẰNG LÁI XE MÁY
        </h2>
        <div className="grid grid-cols-1 gap-1 lg:gap-4 lg:grid-cols-4 uppercase ">
          <div className="w-full  p-4  flex-col text-center">
            <div className="justify-center flex ">
              <CustomImage
                src={student}
                width={128}
                height={128}
                alt="Số lượng thi sinh 1 buổi thi"
                className=""
              />
            </div>
            <h4 className="">
              <strong>150 người</strong>
            </h4>
            <p>Số lượng thí sinh 1 buổi thi</p>
          </div>
          <div className="w-full  p-4  flex-col text-center">
            <div className="justify-center flex ">
              <CustomImage
                src={deadline}
                width={128}
                height={128}
                alt="Số lượng thi sinh 1 buổi thi"
                className=""
              />
            </div>
            <h4 className="">
              <strong>7 Ngày</strong>
            </h4>
            <p>THI XONG, 7 NGÀY SAU CÓ BẰNG</p>
          </div>
          <div className="w-full  p-4  flex-col text-center">
            <div className="justify-center flex ">
              <CustomImage
                src={book}
                width={128}
                height={128}
                alt="Số lượng thi sinh 1 buổi thi"
                className=""
              />
            </div>
            <h4 className="">
              <strong>2 GIỜ</strong>
            </h4>
            <p>THỜI GIAN KÉO DÀI BUỔI THI</p>
          </div>
          <div className="w-full  p-4  flex-col text-center">
            <div className="justify-center flex ">
              <CustomImage
                src={speaker}
                width={128}
                height={128}
                alt="Số lượng thi sinh 1 buổi thi"
                className=""
              />
            </div>
            <h4 className="">
              <strong>14 BUỔI / THÁNG</strong>
            </h4>
            <p>HÀNG THÁNG CÓ 15 NGÀY THI</p>
          </div>
        </div>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4 pl-4 pr-4  sm:pl-0 sm:pr-0">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          TẠI SAO NÊN CHỌN CHÚNG TÔI
        </h2>
        <div className="grid grid-cols-1 gap-1 lg:gap-2 lg:grid-cols-2  ">
          <div className="w-full flex  p-4 ">
            <div className="justify-center flex ">
              <CustomImage
                src={motobike}
                width={170}
                height={170}
                alt="Số lượng thi sinh 1 buổi thi"
                className="w-[20rem] h-[5rem] lg:w-auto lg:h-auto"
              />
            </div>
            <div className="pl-5">
              <h4 className="uppercase">
                <strong>BẰNG THẬT</strong>
              </h4>
              <p>
                100% bằng lái xe là bằng thật, có hồ sơ gốc trả cho bạn lưu trữ,
                nên các bạn yên tâm về chiếc bằng lái xe của mình.
              </p>
            </div>
          </div>
          <div className="w-full flex  p-4 ">
            <div className="justify-center flex ">
              <CustomImage
                src={motobike}
                width={170}
                height={170}
                alt="Đăng ký nhanh gọn"
                className="w-[20rem] h-[5rem] lg:w-auto lg:h-auto"
              />
            </div>
            <div className="pl-5">
              <h4 className="uppercase">
                <strong>ĐĂNG KÝ NHANH GỌN</strong>
              </h4>
              <p>
                Đăng kí nhanh chóng, dễ dàng, bạn có thể qua Trung tâm hoặc có
                nhân viên đến nhà bạn làm hồ sơ.
              </p>
            </div>
          </div>
          <div className="w-full flex   p-4">
            <div className="justify-center flex ">
              <CustomImage
                src={motobike}
                width={170}
                height={170}
                alt="Đội ngũ giáo viên giỏi"
                className="w-[20rem] h-[5rem] lg:w-auto lg:h-auto"
              />
            </div>
            <div className="pl-5">
              <h4 className="uppercase">
                <strong>ĐỘI NGŨ GIÁO VIÊN GIỎI</strong>
              </h4>
              <p>
                Đội ngũ giáo viên có kĩ năng giỏi, nhiệt tình. Cam kết hỗ trợ
                tối đa để bạn có được chiếc bằng lái xe.
              </p>
            </div>
          </div>
          <div className="w-full flex   p-4">
            <div className="justify-center flex ">
              <CustomImage
                src={motobike}
                width={170}
                height={170}
                alt="Khách hàng hài lòng"
                className="w-[20rem] h-[5rem] lg:w-auto lg:h-auto"
              />
            </div>
            <div className="pl-5">
              <h4 className="uppercase">
                <strong>KHÁCH HÀNG HÀI LÒNG</strong>
              </h4>
              <p>
                Với phương châm lấy sự uy tín lên hàng đầu, Trung tâm cam kết sẽ
                làm hài lòng tất cả các bạn đến Trung tâm đăng kí.
              </p>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}
