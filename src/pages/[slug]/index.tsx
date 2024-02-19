import { useRouter } from "next/router";
import useSWRImmutable from "swr/immutable";
import Head from 'next/head'
import React from "react";
import useSWR from "swr";
import { SERVER_BASE_URL, FRONTEND_URL } from "../../lib/utils/constant";
import fetcher from "../../lib/utils/fetcher";
import DOMPurify from "isomorphic-dompurify";
import Breadcrumb from "../../components/common/Breadcrumb";
import styles from "../../lib/styles/tiny.module.css";
const ArticlePage = (initialArticle: any) => {

  const router = useRouter();
  const {
    query: { slug },
  } = router;
  const { data } = useSWRImmutable(
    `${SERVER_BASE_URL}/api/publish/product/detail/${slug && slug}`,
    fetcher
  );
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
    <nav className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto">

      <div className="mt-5">
        <Breadcrumb
          pageLink={`${data && data.id}`}
          pageName={data && data.title}
          key={1}
        />
      </div>

      <div className="grid grid-flow-row-dense grid-cols-4">
        <div className="col-span-3 pr-5 pt-5">
          <div>
            <h2 className=" flex-auto text-[20px] text-center font-bold  uppercase ">
              {data && data.title}
            </h2>
            <p>{data && data.description}</p>
          </div>
          <div className="article"
            dangerouslySetInnerHTML={{
              __html: DOMPurify.sanitize(data && data.body),
            }}
          ></div>
        </div>
        <div className="col-span-1">
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
    </nav></>
  );
};

export default ArticlePage;
