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
import defaulImage from "../../assets/default.jpg";
// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";

// Import Swiper styles
import "swiper/css";
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
  console.log(category);
  if (category != undefined || category != null) {
  }

  return (
    <div>
      <Swiper
        spaceBetween={50}
        slidesPerView={3}
        onSlideChange={() => console.log("slide change")}
        onSwiper={(swiper) => console.log(swiper)}
      >
        {category &&
          category.banners.map((i, index) => {
            return (
              <CustomImage
                alt={i.caption}
                src={SERVER_BASE_URL + i.imagePath}
                height={500}
                width={500}
                className="w-full"
                key={index}
              />
            );
          })}
      </Swiper>
      <Breadcrumb
        pageLink={`danh-muc/${category && category.id}`}
        pageName={category && category.name}
        key={1}
      />

      <div dangerouslySetInnerHTML={{ __html: _html }}></div>
    </div>
  );
};

export default CategoryDetail;
