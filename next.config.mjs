/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    loader: 'custom',
    loaderFile: './src/assets/loader.js',
  },
};

export default nextConfig;
