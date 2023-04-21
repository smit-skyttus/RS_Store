import {React,useState} from 'react'
import { NavLink } from 'react-router-dom';
import FormatPrice from '../Helpers/FormatPrice';

const Product = (curElem) => {
    const{productId, productName, productImage,productPrice, category} = curElem;

    const [cat,setCat] = useState(category.categoryType);
  return (
  <NavLink to={`/singleproduct/${productId}`} state={{cate:cat}}>
    <div className="card">
        <figure>
            <img src={productImage} alt={productName}></img>
            <figcaption className="caption">{category.categoryType}</figcaption>
        </figure>

        <div className="card-data">
            <div className="card-data-flex">
                <h3>{productName}</h3>
                <p className="card-data-price">{<FormatPrice price={productPrice} />}</p>

            </div>
        </div>
    </div>
  </NavLink>
  );
};

export default Product;
