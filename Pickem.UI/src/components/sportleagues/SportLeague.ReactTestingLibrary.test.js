import React from "react";
import { cleanup, render } from "react-testing-library";
import SportLeagueForm from "./SportLeagueForm";

afterEach(cleanup);

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
  return render(<SportLeagueForm {...props} />);
}

it("should render Add Sport League Header", () => {
  const { getByText } = renderSportLeagueForm();
  getByText("Add Sport League");
});

it('should label save button as "Save" when not saving', () => {
  const { getByText } = renderSportLeagueForm();
  getByText("Save");
});

it('should label save button as "Saving..." when saving', () => {
  const { getByText } = renderSportLeagueForm({ saving: true });
  getByText("Saving...");
});
