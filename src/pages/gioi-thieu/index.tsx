import * as React from 'react';
import Breadcrumb from '../../components/common/Breadcrumb';
export interface IGioiThieuProps {
}

export default function GioiThieu (props: IGioiThieuProps) {
  return (
   <Breadcrumb pageLink='/gioi-thieu' pageName='Giới thiệu' key={1}/>
  );
}
