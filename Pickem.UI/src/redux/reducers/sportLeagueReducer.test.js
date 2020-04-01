import sportLeagueReducer from "./sportLeagueReducer";
import * as actions from "../actions/sportLeagueActions";
import configureStore from "../configureStore";

it("should add sport league when passed CREATE_SPORTLEAGUE_SUCCESS", () => {
  //arrange
  const initialState = [
    {
      name: "A"
    },
    {
      name: "B"
    }
  ];

  const newSportLeague = {
    name: "C"
  };

  const action = actions.createSportLeagueSuccess(newSportLeague);

  //act
  const newState = sportLeagueReducer(initialState, action);

  //assert
  expect(newState.length).toEqual(3);
  expect(newState[0].name).toEqual("A");
  expect(newState[1].name).toEqual("B");
  expect(newState[2].name).toEqual("C");
});

it("should update sport league when passed UPDATE_SPORTLEAGUE_SUCCESS", () => {
  const initialState = [
    { id: 1, name: "A" },
    { id: 2, name: "B" },
    { id: 3, name: "C" }
  ];

  const sportLeague = { id: 2, name: "New Name" };
  const action = actions.updateSportLeagueSuccess(sportLeague);

  //act
  const newState = sportLeagueReducer(initialState, action);
  const updatedSportLeague = newState.find(a => a.id == sportLeague.id);
  const untouchedSportLeague = newState.find(a => a.id == 1);

  //assert
  expect(updatedSportLeague.name).toEqual("New Name");
  expect(untouchedSportLeague.name).toEqual("A");
  expect(newState.length).toEqual(3);
});
