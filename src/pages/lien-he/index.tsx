import * as React from 'react';
import Breadcrumb from '../../components/common/Breadcrumb';
export interface ILienHeProps {
}

export default function LienHe (props: ILienHeProps) {
    return (
        <Breadcrumb pageLink='/lien-he' pageName='Liên hệ' key={1}/>
      );
}
