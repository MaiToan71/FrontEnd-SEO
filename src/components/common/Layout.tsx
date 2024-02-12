import React, { ReactNode } from "react";

import Navbar from "./Navbar";
import Footer from "./Footer";
interface Props {
    children?: ReactNode
    // any props that come into the component
}
const Layout =  ({ children}: Props) => (
  <>
    <Navbar />
    <nav className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
      {children}
    </nav>
    <Footer />
  </>
);

export default Layout;