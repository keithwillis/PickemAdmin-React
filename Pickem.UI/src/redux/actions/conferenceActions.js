import * as types from "./actionTypes";
import * as conferenceApi from "../../api/conferenceApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function createConference(conference) {
  return { type: types.CREATE_CONFERENCE, conference };
}

export function loadConferencesSuccess(conferences) {
  return { type: types.LOAD_CONFERENCES_SUCCESS, conferences };
}

export function loadConferences() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return conferenceApi
      .getConferences()
      .then(conferences => {
        dispatch(loadConferencesSuccess(conferences));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
