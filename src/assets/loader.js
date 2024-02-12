export default function MyImageLoader({ src, width, quality }) {
    return `${src}?w=${width}&q=${quality || 75}`
  }