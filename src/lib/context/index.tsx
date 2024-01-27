import React, { ReactNode } from "react";

import PageContext from "./PageContext";
import PageCountContext from "./PageCountContext";
interface Props {
    children?: ReactNode
    // any props that come into the component
}
const ContextProvider = ({ children}: Props) => (
  <PageContext>
    <PageCountContext>{children}</PageCountContext>
  </PageContext>
);

export default ContextProvider;