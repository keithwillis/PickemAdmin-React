import * as types from "./actionTypes";
import * as divisionApi from "../../api/divisionApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function createDivision(division) {
  return { type: types.CREATE_DIVISION, division };
}

export function loadDivisionsSuccess(divisions) {
  return { type: types.LOAD_DIVISIONS_SUCCESS, divisions };
}

export function loadDivisions() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return divisionApi
      .getDivisions()
      .then(divisions => {
        dispatch(loadDivisionsSuccess(divisions));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
