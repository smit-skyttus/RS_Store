import { createContext, useContext, useEffect, useReducer } from "react";
import axios from "axios";
import reducer from "../reducer/productReducer"

const AppContext = createContext();

const API = "https://rgp3107.github.io/APIEcon/Data/Products.json";

const CAT_API = "https://rgp3107.github.io/APIEcon/Data/Categories.json";

const initialState = {
    isLoading : false,
    isError : false,
    products : [],
    featureProducts : [],
    isSingleLoading : false,
    singleProduct : {},
    all_categories:[]
};

const AppProvider = ({children}) => {

    const[state, dispatch] = useReducer(reducer, initialState)

    const getProducts = async (url) =>{
       dispatch({type:"SET_LOADING"}); 
       try {
         const res = await axios.get(url);
         const products = await res.data;
         dispatch({type:"SET_API_DATA", payload:products})
       } catch (error){
         dispatch ({type:"API_ERROR"});
       };
    }

    const getCategories = async (url) =>{
        try {
          const res = await axios.get(url);
          const all_categories = await res.data;
          dispatch({type:"SET_CAT_DATA", payload:all_categories})
        } catch (error){
          dispatch ({type:"API_ERROR"});
        };
     }

    // 2nd API call for single product

    const getSingleProduct = async (url)=>{
        dispatch({type:"SET_SINGLE_LOADING"}); 
        try {
         const res = await axios.get(url);
         const singleProduct = await res.data;
         dispatch({type:"SET_SINGLE_PRODUCT", payload:singleProduct})
        } catch (error) {
            dispatch ({type:"SET_SINGLE_ERROR"});
        }
    };

    useEffect(()=>{
        getProducts(API);
        getCategories(CAT_API);
    }, []);


    return (<AppContext.Provider value={{...state, getSingleProduct}}>
        {children}
        </AppContext.Provider>
    );
};

const useProductContext=()=>{
    return useContext(AppContext);
};

export {AppProvider, AppContext, useProductContext};