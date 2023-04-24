import { createContext, useContext, useReducer, useEffect } from "react";
import reducer from '../reducer/cartReducer';

const CartContext = createContext();

const getLocalCartData = ()=>{
    let result= [];
    let localCartData =  localStorage.getItem("RSCart");
    if (localCartData ){
        return JSON.parse([localCartData]);
    }
    return result;
}

const initialState = {
    cart : getLocalCartData(),
    total_item : "",
    total_price : "",
    shipping_fee : 50000,
}

const CartProvider = ({children})=>{

    const[state, dispatch] = useReducer(reducer, initialState);

    const addToCart = (id, amount, product) =>{
        dispatch({type:"ADD_TO_CART", payload:{id, amount, product}});    
    };

    const removeItem=(id)=>{
        dispatch ({type:"REMOVE_ITEM", payload:id})
    }

    //to clear the cart
    const clearCart =()=>{
        dispatch({type:"CLEAR_CART"})
    };
    

    //increment and decrement of product
    const setDecrease = (id)=>{
        dispatch({type:"SET_DECREMENT", payload:id})
    }

    const setIncrease = (id)=>{
        dispatch({type:"SET_INCREMENT", payload:id})
    }

    //to add data in localStorage
    useEffect(()=>{
        // dispatch({type:"CART_TOTAL_ITEM"});
        // dispatch({type:"CART_TOTAL_PRICE"});
        dispatch({type:"CART_ITEM_PRICE_TOTAL"});
        localStorage.setItem("RSCart", JSON.stringify(state.cart));
    },[state.cart]);
    
    return <CartContext.Provider 
        value={{...state, addToCart, removeItem, clearCart,setDecrease, setIncrease}}>
        {children}
    </CartContext.Provider>
};

const useCartContext = () =>{
    return useContext(CartContext);
};

export {CartProvider, useCartContext};