import React, { useState } from "react";

import { Button } from "../styles/Button";

const ReadMore = ({ text }) => {
  const [isReadMore, setIsReadMore] = useState(true);

  const toggleReadMore = () => {
    setIsReadMore(!isReadMore);
  };

  return (
    <p className="text">
     {isReadMore ? text.slice(0, 90) : text}{" "}
      <Button onClick={toggleReadMore} className="read-or-hide">
         {isReadMore ? "read more" : " show less"}{" "}
      </Button>
      {" "}
    </p>
  );
};

export default ReadMore;
