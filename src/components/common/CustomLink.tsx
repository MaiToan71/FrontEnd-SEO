import Link from "next/link";
import React from "react";
import DOMPurify from "isomorphic-dompurify";

interface CustomLinkProps {
  href: string;
  as: string;
  className?: string;
  html:any;
}

const CustomLink = ({ className, href, as,html }: CustomLinkProps) => (
  <Link href={href} as={as} passHref  className={`${className || ""} ` }  dangerouslySetInnerHTML={{ __html: DOMPurify.sanitize(html) }}>
  </Link>
);

export default CustomLink;