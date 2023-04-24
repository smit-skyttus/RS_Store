import React, { useState } from "react";
import styled from "styled-components";
import { BsFillGridFill, BsList } from "react-icons/bs";
import { useFilterContext } from "../../context/filter_context";
// import Select from "react-select";

const Sort = () => {
  const { filter_products, grid_view, setGridView, setListView, sorting } =
    useFilterContext();
  const [isClearable, setIsClearable] = useState(false);
  const [isSearchable, setIsSearchable] = useState(true);
  const [isDisabled, setIsDisabled] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [isRtl, setIsRtl] = useState(true);

  const handleChange = (event) => {
    console.log(event.target.value);
    // setSelected(event.target.value);
  };
  const options = [
    { value: "lowest", label: "Price(lowest)" },
    { value: "highest", label: "Price(highest)" },
    { value: "a-z", label: "Name(a-z)" },
    { value: "z-a", label: "Name(z-a)" },
  ];
  return (
    <Wrapper className="sort-section">
      {/* 1st column  */}
      <div className="sorting-list--grid">
        <button
          className={grid_view ? "active sort-btn" : "sort-btn"}
          onClick={setGridView}
        >
          <BsFillGridFill className="icon" />
        </button>
        <button
          className={!grid_view ? "active sort-btn" : "sort-btn"}
          onClick={setListView}
        >
          <BsList className="icon" />
        </button>
      </div>
      {/* 2nd column  */}
      <div className="product-data">
        <p>{`${filter_products.length} Products Available`}</p>
      </div>

      {/* 3rd column  */}
      <div className="sort-selection">
        <form action="#">
          <label htmlFor="sort"></label>
          <select name="sort" id="sort" className="sort-selection--style"
            onClick={sorting}
          >
            <option value="lowest">Price(lowest)</option>
            <option value="#" disabled ></option>
            <option value="highest">Price(highest)</option>
            <option value="#" disabled ></option>
            <option value="a-z">Price(a-z)</option>
            <option value="#" disabled ></option>
            <option value="z-a">Price(z-a)</option>

          </select>
          {/* <Select
            options={options}
            className="basic-single"
            classNamePrefix="select"
            defaultValue={options[0]}
            isDisabled={isDisabled}
            isLoading={isLoading}
            isClearable={isClearable}
            isRtl={isRtl}
            isSearchable={isSearchable}
            name="sort"
            id="sort"
            autoFocus={true}
            onChange={handleChange}
          /> */}
        </form>
      </div>
    </Wrapper>
  );
};

const Wrapper = styled.section`
  display: flex;
  justify-content: space-between;
  margin-top: 5rem;
  .sorting-list--grid {
    display: flex;
    gap: 2rem;
    .sort-btn {
      padding: 0.8rem 1rem;
      border: none;
      display: flex;
      justify-content: center;
      align-items: center;
      cursor: pointer;
    }
    .icon {
      font-size: 1.6rem;
    }
    .active {
      background-color: ${({ theme }) => theme.colors.black};
      color: #fff;
    }
  }
  .sort-selection .sort-selection--style {
    padding: 0.5rem;
    cursor: pointer;
    .sort-select--option {
      padding: 0.5rem 0;
      cursor: pointer;
      height: 2rem;
      padding: 10px;
    }
  }
`;

export default Sort;
