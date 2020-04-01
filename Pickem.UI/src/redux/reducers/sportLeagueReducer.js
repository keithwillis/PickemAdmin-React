import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function sportLeagueReducer(
  state = initialState.sportLeagues,
  action
) {
  switch (action.type) {
    case types.CREATE_SPORTLEAGUE_SUCCESS:
      return [...state, { ...action.sportLeague }];
    case types.LOAD_SPORTLEAGUES_SUCCESS:
      return action.sportLeagues;
    case types.UPDATE_SPORTLEAGUE_SUCCESS:
      return state.map(sportLeague =>
        sportLeague.id === action.sportLeague.id
          ? action.sportLeague
          : sportLeague
      );
    case types.DELETE_SPORTLEAGUE_OPTIMISTIC:
      return state.filter(
        sportLeague => sportLeague.id != action.sportLeague.id
      );
    //return action.sportLeague;
    default:
      return state;
  }
}
