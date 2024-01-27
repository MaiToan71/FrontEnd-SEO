import * as React from "react";
import Image from "next/image";
export interface ICustomImageProps {
  src: string;
  alt: string;
  className?: string;
  width: number;
  height: number;
}

export default function CustomImage({
  className,
  src,
  alt,
  height,
  width,
}: ICustomImageProps) {
  return (
    <Image
      src={src}
      alt={alt}
      className={className || ""}
      width={width}
      height={height}
      // blurDataURL="data:..." automatically provided
      // placeholder="blur" // Optional blur-up while loading
    />
  );
}
