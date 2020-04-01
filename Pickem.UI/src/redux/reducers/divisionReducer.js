import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function divisionReducer(
  state = initialState.divisions,
  action
) {
  switch (action.type) {
    case types.CREATE_DIVISION:
      return [...state, { ...action.division }];
    case types.LOAD_DIVISIONS_SUCCESS:
      return action.divisions;
    default:
      return state;
  }
}
