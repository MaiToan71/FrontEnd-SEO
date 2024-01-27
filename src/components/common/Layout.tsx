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

    {children}
    <Footer />
  </>
);

export default Layout;