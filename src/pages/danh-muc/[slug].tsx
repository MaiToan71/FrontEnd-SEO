// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";
// import required modules
import { Autoplay, Pagination, Navigation } from "swiper/modules";
// Import Swiper styles
import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/autoplay";
import CustomLink from "../../components/common/CustomLink";
import DOMPurify from "isomorphic-dompurify";
import * as React from "react";
import Breadcrumb from "../../components/common/Breadcrumb";
import { useRouter } from "next/router";
import useSWRImmutable from "swr/immutable";
import CategoryAPI from "../../lib/api/category";
import { SERVER_BASE_URL, FRONTEND_URL } from "../../lib/utils/constant";
import fetcher from "../../lib/utils/fetcher";
import { Category } from "../../lib/types/categoryType";
import CustomImage from "../../components/common/CustomImage";
import defaultImage from "../../assets/defaultImage.jpg";
import moment from "moment";
import Head from "next/head";
export interface ICategoryDetailProps {}

const CategoryDetail = () => {
  const router = useRouter();
  const {
    query: { slug },
  } = router;
  const { data: fetchedCategory } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/category/${slug && slug}`,
    fetcher
  );
  const category: Category = fetchedCategory;
  const _html = DOMPurify.sanitize(category && category.note);
  if (category != undefined || category != null) {
  }

  let outstands = [];

  const { data: outstandAPis } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/categories/outstand`,
    fetcher
  );
  if (outstandAPis !== undefined) {
    outstands = outstandAPis;
  }

  return (
    <>
      <Head>
        <title>{category && category.name}</title>
        <meta name="description" content={category && category.description} />
      </Head>
      <Swiper
        centeredSlides={true}
        autoplay={{
          delay: 100000,
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
        {category &&
          category.banners.map((i, index) => {
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
      <nav className="max-w-screen-xl flex flex-wrap items-center justify-between  mx-auto pl-4 pr-4  sm:pl-0 sm:pr-0">
        <div className="mt-5">
          <Breadcrumb
            pageLink={`danh-muc/${category && category.id}`}
            pageName={category && category.name}
            key={1}
          />
        </div>
        <div className="grid grid-flow-row-dense grid-cols-4">
          <div className="col-span-4  lg:col-span-3  pt-4 pr-0 lg:pr-4">
            <div dangerouslySetInnerHTML={{ __html: _html }}></div>
            <div className="products">
              <div className="grid grid-cols-1 gap-x-6 gap-y-10">
                {category &&
                  category.products.map((i, index) => {
                    return (
                      <>
                        <a href={`${FRONTEND_URL}/${i.id}`} className="group flex flex-col lg:flex-row ">
                          <div style={{width:'50%'}} className="aspect-h-1  aspect-w-1  lg:w-auto overflow-hidden rounded-lg  bg-gray-200 xl:aspect-h-8 xl:aspect-w-7">
                            <CustomImage
                              alt=""
                              height={135}
                              width={240}
                              className="h-full w-full lg:w-auto   object-cover object-center group-hover:opacity-75"
                              src={defaultImage }
                            />
                          </div>
                          <div className="ml-0 lg:ml-5">
                            <h3 className="mt-0 text-lg font-medium text-gray-900">
                              {i.title}
                            </h3>
                            <p className="mt-1  text-sm text-gray-700 ">
                              {moment(i.dateCreated).format("DD/MM/YYYY")}
                            </p>
                            <p className="mt-1  text-sm text-gray-700 ">
                              {i.description}
                            </p>
                          </div>
                        </a>
                      </>
                    );
                  })}
              </div>
            </div>
          </div>
          <div className="col-span-4  lg:col-span-1 mt-4 lg:mt-0">
            {outstands.length >= 2 ? (
              <>
                <div className="outstand">
                  <h3>DỊCH VỤ CỦA CHÚNG TÔI</h3>
                  <ul className="list-disc outstand-category">
                    {outstands &&
                      outstands.slice(0, 2).map((p: any, pIndex: number) => {
                        return (
                          <>
                            <li key={pIndex}>
                              <a href="#" key={pIndex}>
                                {p.name}
                              </a>
                            </li>
                          </>
                        );
                      })}
                  </ul>
                </div>
              </>
            ) : (
              <></>
            )}
            {outstands.length >= 3 ? (
              <>
                <div className="outstand mt-5">
                  <h3>TIN TỨC VỀ BẰNG LÁI XE</h3>
                  <ul className="list-disc outstand-products">
                    {outstands &&
                      outstands
                        .slice(2, 3)[0]
                        .products.map((p: any, pIndex: number) => {
                          return (
                            <>
                              {" "}
                              <li key={pIndex}>
                                <a href="#" key={pIndex}>
                                  {p.title}
                                </a>{" "}
                              </li>
                            </>
                          );
                        })}
                  </ul>
                </div>
              </>
            ) : (
              <></>
            )}
            {outstands.length >= 4 ? (
              <>
                <div className="outstand mt-5">
                  <h3>HỎI ĐÁP VỀ BẰNG LÁI XE</h3>
                  <ul className="list-disc outstand-products">
                    {outstands &&
                      outstands
                        .slice(3, 4)[0]
                        .products.map((p: any, pIndex: number) => {
                          return (
                            <>
                              {" "}
                              <li key={pIndex}>
                                <a href="#" key={pIndex}>
                                  {p.title}
                                </a>{" "}
                              </li>
                            </>
                          );
                        })}
                  </ul>
                </div>
              </>
            ) : (
              <></>
            )}
          </div>
        </div>
      </nav>
    </>
  );
};

export default CategoryDetail;
