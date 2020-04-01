import * as types from "./actionTypes";
import * as sportLeagueApi from "../../api/sportLeagueApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function loadSportLeaguesSuccess(sportLeagues) {
  return { type: types.LOAD_SPORTLEAGUES_SUCCESS, sportLeagues };
}

export function updateSportLeagueSuccess(sportLeague) {
  return { type: types.UPDATE_SPORTLEAGUE_SUCCESS, sportLeague };
}

export function createSportLeagueSuccess(sportLeague) {
  return { type: types.CREATE_SPORTLEAGUE_SUCCESS, sportLeague };
}

export function deleteSportLeagueOptimistic(sportLeague) {
  return { type: types.DELETE_SPORTLEAGUE_OPTIMISTIC, sportLeague };
}

export function loadSportLeagues() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return sportLeagueApi
      .getSportLeagues()
      .then(sportLeagues => {
        dispatch(loadSportLeaguesSuccess(sportLeagues));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

export function addSportLeague(sportLeague) {
  return function(dispatch) {
    dispatch(beginApiCall());
    return sportLeagueApi
      .saveSportLeague(sportLeague)
      .then(savedSportLeague => {
        dispatch(createSportLeagueSuccess(savedSportLeague));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

export function saveSportLeague(sportLeague) {
  return function(dispatch) {
    dispatch(beginApiCall());
    return sportLeagueApi
      .saveSportLeague(sportLeague)
      .then(dispatch(updateSportLeagueSuccess(sportLeague)))
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

export function deleteSportLeague(sportLeague) {
  return function(dispatch) {
    dispatch(deleteSportLeagueOptimistic(sportLeague));
    return sportLeagueApi.deleteSportLeague(sportLeague.id);
  };
}
