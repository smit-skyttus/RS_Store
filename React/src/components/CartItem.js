import React from 'react'
import FormatPrice from '../Helpers/FormatPrice';
import { FaTrash } from "react-icons/fa";
import { useCartContext } from "../context/cart_context";
import CartAmountToggle from "./CartAmountToggle";

const CartItem = ({id, name, amount, image, price}) => {
    const { removeItem, setDecrease, setIncrease } = useCartContext();
  return (
    <div className="cart_heading grid grid-five-column">
        <div className="cart-image--name">
            <div>
                <figure>
                    <img src={image} alt={id}/>
                </figure>
            </div>
            <div>
                <p>{name}</p>
            </div>
        </div>

        {/* Price */}
        <div className='cart-hide'>
            <p>
                <FormatPrice price={price} />
            </p>
        </div>
         {/* Quantity  */}
        <CartAmountToggle
        amount={amount}
        setDecrease={() => setDecrease(id)}
        setIncrease={() => setIncrease(id)}
      />

        {/* //Subtotal */}
        <div className="cart-hide">
        <p>
          <FormatPrice price={price * amount} />
        </p>
      </div>
      <div>
        <FaTrash className="remove_icon" onClick={() => removeItem(id)} />
      </div>

    </div>
  ) 
}

export default CartItem