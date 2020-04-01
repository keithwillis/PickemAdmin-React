import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput";
import CheckBoxInput from "../common/CheckBoxInput";
import ConferenceList from "../conferences/ConferenceList";

const SportLeagueForm = ({
  sportLeague,
  conferences,
  divisions,
  teams,
  onSave,
  onChange,
  saving = false,
  errors = {}
}) => {
  return (
    <>
      <form onSubmit={onSave}>
        <h2>{sportLeague.id ? "Edit" : "Add"} Sport League</h2>
        {errors.onSave && (
          <div className="alert alert-danger" role="alert">
            {errors.onSave}
          </div>
        )}
        <TextInput
          name="name"
          label="Name"
          value={sportLeague.name}
          onChange={onChange}
          error={errors.name}
        />
        <CheckBoxInput
          name="isEnabled"
          label="Is Enabled"
          checked={sportLeague.isEnabled}
          value="IsEnabled"
          onChange={onChange}
          error={errors.isEnabled}
        />
        <button type="submit" disabled={saving} className="btn btn-primary">
          {saving ? "Saving..." : "Save"}
        </button>
      </form>
      <br />
      <br />

      <ConferenceList
        conferences={conferences}
        divisions={divisions}
        teams={teams}
        sportLeagueId={sportLeague.id}
      ></ConferenceList>
    </>
  );
};

SportLeagueForm.propTypes = {
  conferences: PropTypes.array,
  divisions: PropTypes.array,
  teams: PropTypes.array,
  sportLeague: PropTypes.object.isRequired,
  errors: PropTypes.object,
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  saving: PropTypes.bool
};

export default SportLeagueForm;
