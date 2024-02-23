import Head from "next/head";
import React from "react";
import { AppProps } from 'next/app';
import Layout from "../components/common/Layout";
import ContextProvider from "../lib/context";
import '../lib/styles/globals.css';
import '../lib/styles/tiny.css';
import 'flowbite';
if (typeof window !== "undefined") {
  require("lazysizes/plugins/attrchange/ls.attrchange.js");
  require("lazysizes/plugins/respimg/ls.respimg.js");
  require("lazysizes");
}

const MyApp = ({ Component, pageProps }:AppProps) => (
  <>
    <Head>
        <title>Thi bằng lái xe số 1</title>
        <meta name="description" content="Thi bằng lái xe số 1" />
        
    </Head>
    <ContextProvider>
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </ContextProvider>
  </>
);

export default MyApp;