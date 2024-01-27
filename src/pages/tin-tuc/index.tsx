import * as React from 'react';
import Breadcrumb from '../../components/common/Breadcrumb';
export interface ITinTucProps {
}

export default function TinTuc (props: ITinTucProps) {
    return (
        <Breadcrumb pageLink='/tin-tuc' pageName='Tin tức' key={1}/>
      );
}
