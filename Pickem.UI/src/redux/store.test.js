import { createStore } from "redux";
import rootReducer from "./reducers";
import initialState from "./reducers/initialState";
import * as sportLeagueActions from "./actions/sportLeagueActions";

it("Should handle creating sportLeagues", function() {
  //arrange
  const store = createStore(rootReducer, initialState);
  const sportLeague = { name: "NFL-TEST" };

  //act
  const action = sportLeagueActions.createSportLeagueSuccess(sportLeague);
  store.dispatch(action);

  //assert
  const createdSportLeague = store.getState().sportLeagues[0];
  expect(createdSportLeague).toEqual(sportLeague);
});
