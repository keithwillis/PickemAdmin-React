import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function conferenceReducer(
  state = initialState.conferences,
  action
) {
  switch (action.type) {
    case types.CREATE_CONFERENCE:
      return [...state, { ...action.conference }];
    case types.LOAD_CONFERENCES_SUCCESS:
      return action.conferences;
    default:
      return state;
  }
}
