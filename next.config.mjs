/** @type {import('next').NextConfig} */
const nextConfig = {
  output: 'export',
  reactStrictMode: true,
  exportTrailingSlash: true,
  swcMinify: true,
  images: {
    loader: 'custom',
    loaderFile: './src/assets/loader.js',
  },
};

export default nextConfig;
