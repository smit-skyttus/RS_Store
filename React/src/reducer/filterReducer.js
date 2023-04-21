const filterReducer = (state, action) => {
  switch (action.type) {
    case "LOAD_FILTER_PRODUCTS":
      let priceArr = action.payload.map((curElem) => curElem.productPrice);
      // console.log(priceArr);

      let maxPrice = Math.max(...priceArr);
      let minPrice = Math.min(...priceArr);
      // console.log(maxPrice);
      return {
        ...state,
        filter_products: [...action.payload],
        all_products: [...action.payload],
        filters: { ...state.filters, maxPrice, minPrice, price: maxPrice },
      };

    case "SET_GRID_VIEW":
      return {
        ...state,
        grid_view: true,
      };
    case "SET_LIST_VIEW":
      return {
        ...state,
        grid_view: false,
      };
    case "GET_SORT_VALUE":
      // let userSortValue = document.getElementById("sort");
      // let sort_value = userSortValue.options[userSortValue.selectedIndex].value;
      // console.log(sort_value);
      return {
        ...state,
        sorting_value: action.payload,
      };
    case "SORTING_PRODUCTS":
      let newSortData;
      // let tempSortProduct = [...action.payload];

      const { filter_products, sorting_value } = state;
      let tempSortProduct = [...filter_products];

      const sortingProducts = (a, b) => {
        if (sorting_value === "lowest") {
          return a.productPrice - b.productPrice;
        }

        if (sorting_value === "highest") {
          return b.productPrice - a.productPrice;
        }

        if (sorting_value === "a-z") {
          return a.productName.localeCompare(b.productName);
        }

        if (sorting_value === "z-a") {
          return b.productName.localeCompare(a.productName);
        }
      };
      newSortData = tempSortProduct.sort(sortingProducts);

      return {
        ...state,
        filter_products: newSortData,
      };

    case "UPDATE_FILTERS_VALUE":
      const { name, value } = action.payload;

      return {
        ...state,
        filters: {
          ...state.filters,
          [name]: value,
        },
      };

    case "FILTER_PRODUCTS":
      let { all_products } = state;
      let tempFilterProduct = [...all_products];
      //   console.log(tempFilterProduct);

      const { text, category, price } = state.filters;

      if (text) {
        tempFilterProduct = tempFilterProduct.filter((curElem) => {
          return curElem.productName.toLowerCase().includes(text);
        });
        // console.log(tempFilterProduct);
      }
      if (category != "all") {
        tempFilterProduct = tempFilterProduct.filter((curElem) => {
          return curElem.category.categoryType === category;
        });
      }

      if (price) {
        tempFilterProduct = tempFilterProduct.filter(
          (curElem) => curElem.productPrice <= price
        );
      }
      return {
        ...state,
        filter_products: tempFilterProduct,
      };

    case "CLEAR_FILTERS":
      return {
        ...state,
        filters: {
          ...state.filters,
          text: "",
          category: "all",
          maxPrice: state.filters.maxPrice,
          price: state.filters.maxPrice,
        //   minPrice: state.filters.minPrice,
        },
      };

    default:
      return state;
  }
};

export default filterReducer;
