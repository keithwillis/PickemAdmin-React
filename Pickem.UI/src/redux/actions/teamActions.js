import * as types from "./actionTypes";
import * as teamApi from "../../api/teamApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function createTeam(team) {
  return { type: types.CREATE_TEAM, team };
}

export function loadTeamsSuccess(teams) {
  return { type: types.LOAD_TEAMS_SUCCESS, teams };
}

export function loadTeams() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return teamApi
      .getTeams()
      .then(teams => {
        dispatch(loadTeamsSuccess(teams));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
