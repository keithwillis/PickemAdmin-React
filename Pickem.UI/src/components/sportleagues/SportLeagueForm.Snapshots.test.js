import React from "react";
import SportLeagueForm from "./SportLeagueForm";
import renderer from "react-test-renderer";
import { sportLeagues } from "../../../tools/mockData";

it("sets submit button label 'Saving...' wen saving is true", () => {
  const tree = renderer.create(
    <SportLeagueForm
      sportLeague={sportLeagues[0]}
      conferences={[]}
      onSave={jest.fn()}
      onChange={jest.fn}
      saving
    />
  );
  expect(tree).toMatchSnapshot();
});

it("sets submit button label 'Save' wen saving is false", () => {
  const tree = renderer.create(
    <SportLeagueForm
      sportLeague={sportLeagues[0]}
      conferences={[]}
      onSave={jest.fn()}
      onChange={jest.fn}
      saving={false}
    />
  );
  expect(tree).toMatchSnapshot();
});
