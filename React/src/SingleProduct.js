import styled from "styled-components";
import { useLocation, useParams } from "react-router-dom";
import { useEffect } from "react";
import { useProductContext } from "./context/productcontext";
import PageNavigation from "./components/PageNavigation";
import { Container } from "./styles/Container";
import MyImage from "./components/MyImage";
import FormatPrice from "./Helpers/FormatPrice";
import { MdSecurity } from "react-icons/md";
import { TbTruckDelivery, TbReplace } from "react-icons/tb";
import AddToCart from "./components/AddToCart";


const API = "https://rgp3107.github.io/APIEcon/Data/Products/";

const SingleProduct = () =>{
  const{getSingleProduct, isSingleLoading, singleProduct} = useProductContext();
  // console.log(singleProduct);
  const{productId} = useParams();

  const location = useLocation();

  const{
    productId : alias,
    productName,
    productPrice,
    productDescription,
    category,
    images,
  } = singleProduct;

  useEffect(()=>{
    window.scrollTo(0,0);
    getSingleProduct(API + productId+".json");
  },[])

  if (isSingleLoading) {
    return <div className="page_loading">Loading.....</div>;
  }
  return (
    <Wrapper>
      <PageNavigation title={productName}/>
      <Container className="container">
        <div className="grid grid-two-column">
          {/* Product Images */}
          <div className="product_images">
            <MyImage imgs={images} />
          </div>
          {/* console.log(images) */}

          {/* Product Data */}
          <div className="product-data">
            <h2>{productName}</h2>
            <p className="product-data-price">
              MRP:
              <del>
                <FormatPrice price={productPrice+250000}/>
              </del>
            </p>
            <p className="product-data-price product-data-real-price">
              Deal of the Day: <FormatPrice price = {productPrice} />
            </p>
            <p>{productDescription}</p>
            <div className="product-data-warranty">
              <div className="product-warranty-data">
                <TbTruckDelivery className="warranty-icon" />
                <p>Free Delivery</p>
              </div>

              <div className="product-warranty-data">
                <TbReplace className="warranty-icon" />
                <p>30 Days Replacement</p>
              </div>

              <div className="product-warranty-data">
                <TbTruckDelivery className="warranty-icon" />
                <p>RS Delivered </p>
              </div>

              <div className="product-warranty-data">
                <MdSecurity className="warranty-icon" />
                <p>2 Year Warranty </p>
              </div>
             
            </div>
            <div className="product-data-info">
              <p>
                Available:
                <span>In Stock</span>
              </p>
              <p>
                ID : <span> {productId} </span>
              </p>
              <p>
                Category :<span> {location.state.cate} </span>
              </p>
            </div>
            <hr />
            <AddToCart product={singleProduct} />
          </div>

        </div>
      </Container>
    </Wrapper>
  )
};


const Wrapper = styled.section`
  .container {
    padding: 9rem 0;
  }
  .product-data {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: center;
    gap: 2rem;

    .product-data-warranty {
      width: 100%;
      display: flex;
      justify-content: space-between;
      align-items: center;
      border-bottom: 1px solid #ccc;
      margin-bottom: 1rem;

      .product-warranty-data {
        text-align: center;

        .warranty-icon {
          background-color: rgba(220, 220, 220, 0.5);
          border-radius: 50%;
          width: 4rem;
          height: 4rem;
          padding: 0.6rem;
        }
        p {
          font-size: 1.4rem;
          padding-top: 0.4rem;
        }
      }
    }

    .product-data-price {
      font-weight: bold;
    }
    .product-data-real-price {
      color: ${({ theme }) => theme.colors.btn};
    }
    .product-data-info {
      display: flex;
      flex-direction: column;
      gap: 1rem;
      font-size: 1.8rem;

      span {
        font-weight: bold;
      }
    }

    hr {
      max-width: 100%;
      width: 90%;
      /* height: 0.2rem; */
      border: 0.1rem solid #000;
      color: red;
    }
  }

  .product-images {
    display: flex;
    justify-content: center;
    align-items: center;
  }

  @media (max-width: ${({ theme }) => theme.media.mobile}) {
    padding: 0 2.4rem;
  }
`;

export default SingleProduct;
