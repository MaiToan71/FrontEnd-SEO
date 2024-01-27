import Link from "next/link";
import React from "react";

interface CustomLinkProps {
  href: string;
  as: string;
  className?: string;
  name: string;
}

const CustomLink = ({ className, href, as, name }: CustomLinkProps) => (
  <Link href={href} as={as} passHref  className={`${className || ""} ` }>
    {name}
  </Link>
);

export default CustomLink;