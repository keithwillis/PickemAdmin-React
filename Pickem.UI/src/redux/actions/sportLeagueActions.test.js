import * as sportLeagueActions from "./sportLeagueActions";
import * as types from "./actionTypes";
import { sportLeagues } from "../../../tools/mockData";
import thunk from "redux-thunk";
import fetchMock from "fetch-mock";
import configureMockStore from "redux-mock-store";

//test an async action
const middleware = [thunk];
const mockStore = configureMockStore(middleware);

describe("Async Actions", () => {
  afterEach(() => {
    fetchMock.restore();
  });

  describe("Load SportLeagues Thunk", () => {
    it("should create BEGIN_API_CALL and LOAD_SPORTLEAGUES_SUCCESS when loading sport leagues", () => {
      fetchMock.mock("*", {
        body: sportLeagues,
        headers: { "content-type": "application/json" }
      });

      const expectedActions = [
        { type: types.BEGIN_API_CALL },
        { type: types.LOAD_SPORTLEAGUES_SUCCESS, sportLeagues }
      ];

      const store = mockStore({ sportLeagues: [] });
      return store.dispatch(sportLeagueActions.loadSportLeagues()).then(() => {
        expect(store.getActions()).toEqual(expectedActions);
      });
    });
  });
});

describe("createSportLeagueSuccess", () => {
  it("should create a CREATE_SPORTLEAGUE_SUCCESS action", () => {
    //arrange
    const sportLeague = sportLeagues[0];
    const expectedAction = {
      type: types.CREATE_SPORTLEAGUE_SUCCESS,
      sportLeague
    };

    //act
    const action = sportLeagueActions.createSportLeagueSuccess(sportLeague);

    //assert
    expect(action).toEqual(expectedAction);
  });
});
