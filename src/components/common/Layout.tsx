import React, { ReactNode } from "react";

import Navbar from "./Navbar";
import Footer from "./Footer";
interface Props {
  children?: ReactNode;
  // any props that come into the component
}
const Layout = ({ children }: Props) => (
  <>
    <Navbar />

    {children}

    <footer className=" bg-[#007242] mt-5 pt-5 pb-5">
      <Footer />
    </footer>
  </>
);

export default Layout;
