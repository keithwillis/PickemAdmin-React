import { combineReducers } from "redux";
import sportLeagues from "./sportLeagueReducer";
import conferences from "./conferenceReducer";
import divisions from "./divisionReducer";
import teams from "./teamReducer";
import apiCallsInProgress from "./apiStatusReducer";

const rootReducer = combineReducers({
  sportLeagues,
  conferences,
  divisions,
  teams,
  apiCallsInProgress
});

export default rootReducer;
