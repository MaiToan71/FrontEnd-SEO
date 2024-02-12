import {Image} from './imageType';
export interface Category  {
    id: number;
    key: number;
    name: string;
    parentId: string;
    title: string;
    note: string;
    description: string,
    banners: [Image]
  }

  
  