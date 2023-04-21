import React from "react";
import styled from "styled-components";
import { useLoginContext } from "../context/login_context";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const { getLogin,isLoggedIn } = useLoginContext();
  let navigate = useNavigate();
  const handleSubmit = (event) => {
    event.preventDefault();
    var [username, password] = document.forms[0];
    getLogin(username.value, password.value);
    }
    if(isLoggedIn){
      navigate("/");

    // console.log(username.value + "|" + password.value);

    // axios.post(`${LOGINAPI}?username=${username.value}&password=${password.value}`)
    // .then((response) =>console.log(response));
  };

  return (
    <Wrapper>
      <h2 className="common-heading">User Login</h2>

      <div className="container">
        <div className="contact-form">
          <form
            onSubmit={handleSubmit}
            action="POST"
            method="POST"
            className="contact-inputs"
          >
            <input
              type="text"
              placeholder="username"
              name="username"
              required
              autoComplete="off"
            />

            <input
              type="password"
              name="password"
              placeholder="password"
              autoComplete="off"
              required
            />

            <input type="submit" value="Submit" />
          </form>
        </div>
      </div>
    </Wrapper>
  );
};

export default Login;

const Wrapper = styled.section`
  form input[type="text"] {
    text-transform: lowercase;
  }

  padding: 9rem 0 5rem 0;
  text-align: center;

  .container {
    margin-top: 6rem;

    .contact-form {
      max-width: 50rem;
      margin: auto;

      .contact-inputs {
        display: flex;
        flex-direction: column;
        gap: 3rem;

        input[type="submit"] {
          cursor: pointer;
          transition: all 0.2s;

          &:hover {
            background-color: ${({ theme }) => theme.colors.white};
            border: 1px solid ${({ theme }) => theme.colors.btn};
            color: ${({ theme }) => theme.colors.btn};
            transform: scale(0.9);
          }
        }
      }
    }
  }
`;
