const LoginReducer = (state,action) =>{

    switch(action.type){
        case "SET_LOGGED_IN":
            let {data,success} = action.payload;
            let result = false;
            if(success){
                result = true;
                localStorage.setItem("loginToken", data);
            }
            return{
                ...state,
                isLoggedIn:result,
            };
         
        case "SET_LOGOUT":
            return{
                ...state,
                isLoggedIn :false,
            } 
         
        default:
            return state;
    }
};

export default LoginReducer;