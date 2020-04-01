import React from "react";
import { mount } from "enzyme";
import {
  sportLeagues,
  newSportLeague,
  conferences,
  divisions,
  teams
} from "../../../tools/mockData";
import { ManageSportLeaguePage } from "./ManageSportLeaguePage";

function render(args) {
  const defaultProps = {
    sportLeagues,
    conferences,
    divisions,
    teams,
    history: {},
    saveSportLeague: jest.fn(),
    loadSportLeague: jest.fn(),
    sportLeague: newSportLeague,
    match: {}
  };

  const props = { ...defaultProps, ...args };

  return mount(<ManageSportLeaguePage {...props} />);
}

it("sets error when attmpting to save an empty name field", () => {
  const wrapper = render();
  wrapper.find("form").simulate("submit");
  const error = wrapper.find(".alert").first();
  expect(error.text()).toBe("Sport League Name is Required");
});
