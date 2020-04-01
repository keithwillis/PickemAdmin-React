import React from "react";
import SportLeagueForm from "./SportLeagueForm";
import { shallow } from "enzyme";

function renderSportLeagueForm(args) {
  const defaultProps = {
    conferences: [],
    sportLeague: {},
    saving: false,
    errors: {},
    onSave: () => {},
    onChange: () => {}
  };

  const props = { ...defaultProps, ...args };
  return shallow(<SportLeagueForm {...props} />);
}

it("renders form and header", () => {
  const wrapper = renderSportLeagueForm();

  expect(wrapper.find("form").length).toBe(1);
  expect(wrapper.find("h2").text()).toEqual("Add Sport League");
});

it('labels save buttons as "Save" when not saving', () => {
  const wrapper = renderSportLeagueForm();

  expect(wrapper.find("button").text()).toBe("Save");
});

it('labels save buttons as "Saving..." when saving', () => {
  const wrapper = renderSportLeagueForm({ saving: true });

  expect(wrapper.find("button").text()).toBe("Saving...");
});
