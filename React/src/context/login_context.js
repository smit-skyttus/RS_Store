import { createContext, useContext, useEffect, useReducer } from "react";
import axios from "axios";
import reducer from "../reducer/loginReducer";


const LoginContext = createContext();

const LOGINAPI = "https://localhost:7252/api/Auth/LoginUser";

const initialState = {
    isLoggedIn :false
};

const LoginProvider = ({children}) => {

    const[state, dispatch] = useReducer(reducer, initialState)

    const getLogin = async (username, password) =>{
       try {
         axios.post(`${LOGINAPI}?username=${username}&password=${password}`)
         .then((response)=>{
            console.log(response);
            dispatch({type:"SET_LOGGED_IN", payload:response.data});
         });
       } catch (error){
         dispatch ({type:"API_ERROR"});
       };
    }

    const logOut = ()=>{
        dispatch({type:"SET_LOGOUT"});
    }
    return (<LoginContext.Provider value={{...state, getLogin, logOut}}>
        {children}
        </LoginContext.Provider>
    );
};

const useLoginContext=()=>{
    return useContext(LoginContext);
};

export {LoginProvider, LoginContext, useLoginContext};