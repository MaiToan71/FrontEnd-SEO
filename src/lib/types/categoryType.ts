import {Image} from './imageType';
import { Product } from './productType';
export interface Category  {
    id: number;
    key: number;
    name: string;
    parentId: string;
    title: string;
    note: string;
    description: string,
    banners: [Image],
    products:[Product]
  }

  
  