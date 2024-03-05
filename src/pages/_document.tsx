import Document, { Head, Main, NextScript } from "next/document";
import React from "react";
//import flush from "styled-jsx/server";
import { SERVER_BASE_URL, FRONTEND_URL } from "../lib/utils/constant";
import defaultImage from '../assets/defaultImage.jpg';
class MyDocument extends Document {
  render() {
    return (
      <html lang="en">
        <Head>
          <meta httpEquiv="Content-Type" content="text/html; charset=utf-8" />
          <meta httpEquiv="X-UA-Compatible" content="IE=edge" />
          <meta name="robots" content="index, follow" />
          <meta key="googlebot" name="googlebot" content="index,follow" />
          <meta name="google" content="notranslate" />
          <meta name="mobile-web-app-capable" content="yes" />
          <meta name="apple-mobile-web-app-capable" content="yes" />
          <meta
            name="keywords"
            content="blxa1 ,gplx ,thibanglaixetaihanoi ,thibanglaixea1hanoi ,blx ,thibanglaixea2 ,trungtam ,thibang ,a1 ,thibanglaixe ,banglaixehanoi ,banglaixegiare ,lambanga1 ,thibanglaixehanoi ,lambanguytin ,thibanglaixea1
,doibanglaixemayodauhanoi
,thutucdoibanglaixeoto"
          />
          <meta property="og:locale" content="en_US" />
          <meta property="og:site_name" content="thibanglaixe" />
          <meta property="og:title" content="Thi bằng lái xe số 1" />
          <link
            rel="preload"
            as="style"
            href="https://fonts.googleapis.com/css?family=Roboto%3Aregular%2C500%2Cregular%2C700%7CDancing%20Script%3Aregular%2Cdefault&#038;display=swap"
          />
          <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css?family=Roboto%3Aregular%2C500%2Cregular%2C700%7CDancing%20Script%3Aregular%2Cdefault&#038;display=swap"
            media="print"
          />
          <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css?family=Roboto%3Aregular%2C500%2Cregular%2C700%7CDancing%20Script%3Aregular%2Cdefault&#038;display=swap"
          />
          <meta property="og:description" content="Thi bằng lái xe số 1" />
          <meta property="og:url" content="https://thibanglaixeso1.vn/" />
        
          <meta property="twitter:card" content="next-realworld" />
          <meta property="twitter:url" content="https://thibanglaixeso1.vn/" />
          <meta property="twitter:title" content="Thi bằng lái xe số 1" />
          <meta property="twitter:description" content="Thi bằng lái xe số 1" />
      
         

          <script
            async
            src="https://www.googletagmanager.com/gtag/js?id=G-WF2WDPWK69"
          ></script>
          <script>
            {` window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'G-WF2WDPWK69');`}
          </script>
        </Head>
        <body>
          <Main />

          <NextScript />
        </body>
      </html>
    );
  }
}

export default MyDocument;
