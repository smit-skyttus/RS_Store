import React, { useState } from "react";

import { Button } from "../styles/Button";
import styled from "styled-components";

const ReadMore = ({ text }) => {
  const [isReadMore, setIsReadMore] = useState(true);

  const toggleReadMore = () => {
    setIsReadMore(!isReadMore);
  };

  return (
    <Wrapper>
      <p className="text">
        {isReadMore ? text.slice(0, 90) : text}{" "}
        <span onClick={toggleReadMore} className="read-or-hide">
          {isReadMore ? "read more" : " show less"}{" "}
        </span>{" "}
      </p>
    </Wrapper>
  );
};

const Wrapper = styled.section`
  .container {
    position: absolute;
    top: 10%;
    left: 23%;
    width: 50%;
  }

  .text {
    display: inline;
    width: 100%;
  }

  .read-or-hide {
    color: rgb(192, 192, 192);
    cursor: pointer;
  }
`;
export default ReadMore;
