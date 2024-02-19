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
          listImages.map((i:any, index:number) => {
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
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          TRUNG TÂM ĐÀO TẠO BẰNG LÁI XE HÀ NỘI
        </h2>
        <p className="pt-8">
          Trung tâm đào tạo bằng lái xe Hà Nội được thành lập tháng 10/2011.
          Hàng tháng trung tâm tiếp nhận hồ sơ cho từ 800 – 1000 bạn. Với nhiều
          năm kinh nghiệm trong nghành, chúng tôi tự tin giúp các bạn có được
          chiếc bằng lái xe dễ dàng và phù hợp với mình nhất: …
        </p>
        <p className="pt-2">
          Trung tâm không tiếp nhận bất cứ trường hợp mua, bán bằng nào, vì nếu
          không đi thi đều là bằng giả, như thế là vi phạm pháp luật.
        </p>
        <p className="pt-2">
          Thi đỗ được nhận bằng và hồ sơ gốc trả cho bạn lưu trữ, nên các bạn
          yên tâm về chiếc bằng lái xe của mình.
        </p>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          CÁC KHÓA HỌC LÁI XE (TỔ CHỨC LIÊN TỤC TRONG THÁNG)
        </h2>
        <div className="mx-auto max-w-2xl px-4 sm:px-6  lg:max-w-7xl lg:px-8 w-full">
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
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          CÁC CON SỐ VỀ THI BẰNG LÁI XE MÁY
        </h2>
        <p className="pt-8">
          Trung tâm đào tạo bằng lái xe Hà Nội được thành lập tháng 10/2011.
          Hàng tháng trung tâm tiếp nhận hồ sơ cho từ 800 – 1000 bạn. Với nhiều
          năm kinh nghiệm trong nghành, chúng tôi tự tin giúp các bạn có được
          chiếc bằng lái xe dễ dàng và phù hợp với mình nhất: …
        </p>
        <p className="pt-2">
          Trung tâm không tiếp nhận bất cứ trường hợp mua, bán bằng nào, vì nếu
          không đi thi đều là bằng giả, như thế là vi phạm pháp luật.
        </p>
        <p className="pt-2">
          Thi đỗ được nhận bằng và hồ sơ gốc trả cho bạn lưu trữ, nên các bạn
          yên tâm về chiếc bằng lái xe của mình.
        </p>
      </nav>
      <nav className=" max-w-screen-xl flex flex-wrap items-center justify-between mx-auto mt-4">
        <h2 className="uppercase text-[20px] text-page-green font-semibold">
          TẠI SAO NÊN CHỌN CHÚNG TÔI
        </h2>
        <p className="pt-8">
          Trung tâm đào tạo bằng lái xe Hà Nội được thành lập tháng 10/2011.
          Hàng tháng trung tâm tiếp nhận hồ sơ cho từ 800 – 1000 bạn. Với nhiều
          năm kinh nghiệm trong nghành, chúng tôi tự tin giúp các bạn có được
          chiếc bằng lái xe dễ dàng và phù hợp với mình nhất: …
        </p>
        <p className="pt-2">
          Trung tâm không tiếp nhận bất cứ trường hợp mua, bán bằng nào, vì nếu
          không đi thi đều là bằng giả, như thế là vi phạm pháp luật.
        </p>
        <p className="pt-2">
          Thi đỗ được nhận bằng và hồ sơ gốc trả cho bạn lưu trữ, nên các bạn
          yên tâm về chiếc bằng lái xe của mình.
        </p>
      </nav>
    </>
  );
}
