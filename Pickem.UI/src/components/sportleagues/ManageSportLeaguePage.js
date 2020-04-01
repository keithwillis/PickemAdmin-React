import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import {
  loadSportLeagues,
  saveSportLeague,
  addSportLeague
} from "../../redux/actions/sportLeagueActions";
import { loadConferences } from "../../redux/actions/conferenceActions";
import { loadDivisions } from "../../redux/actions/divisionActions";
import { loadTeams } from "../../redux/actions/teamActions";
import PropTypes from "prop-types";
import SportLeagueForm from "./SportLeagueForm";
import Spinner from "../common/Spinner";
import { toast } from "react-toastify";

export function ManageSportLeaguePage({
  sportLeagues,
  conferences,
  divisions,
  teams,
  loadSportLeagues,
  loadConferences,
  loadDivisions,
  loadTeams,
  saveSportLeague,
  addSportLeague,
  history,
  ...props
}) {
  const [sportLeague, setSportLeague] = useState({ ...props.sportLeague });
  const [errors, setErrors] = useState({});
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    if (sportLeagues.length === 0) {
      loadSportLeagues().catch(error => {
        alert("Loading of Sport Leagues failed" + error);
      });
    } else {
      setSportLeague({ ...props.sportLeague });
    }

    if (conferences.length === 0) {
      loadConferences().catch(error => {
        alert("Loading of Conferences failed" + error);
      });
    }

    if (divisions.length === 0) {
      loadDivisions().catch(error => {
        alert("Loading of Divisions failed" + error);
      });
    }

    if (teams.length === 0) {
      loadTeams().catch(error => {
        alert("Loading of Teams failed" + error);
      });
    }
  }, [props.sportLeague]);

  function handleChange(event) {
    const { name, value, checked } = event.target;
    setSportLeague(prevSportLeague => ({
      ...prevSportLeague,
      [name]:
        name === "id"
          ? parseInt(value, 10)
          : name === "isEnabled"
          ? checked
          : value
    }));
  }

  function goToList() {
    history.push("/sportleagues");
  }

  function formIsValid() {
    const { name } = sportLeague;
    const errors = {};
    if (!name) errors.name = "Sport League Name is Required";

    setErrors(errors);
    //Form is valid if errors object still has no properties
    return Object.keys(errors).length === 0;
  }

  function handleSave(event) {
    event.preventDefault();

    if (!formIsValid()) return;

    setSaving(true);
    (sportLeague.id
      ? saveSportLeague(sportLeague)
      : addSportLeague(sportLeague)
    )
      .then(() => {
        toast.success("Sport League Saved");
        goToList();
      })
      .catch(error => {
        setSaving(false);
        setErrors({ onSave: error.message });
      });
  }
  return sportLeagues.length === 0 ? (
    <Spinner />
  ) : (
    <SportLeagueForm
      sportLeague={sportLeague}
      errors={errors}
      conferences={conferences}
      divisions={divisions}
      teams={teams}
      onChange={handleChange}
      onSave={handleSave}
      saving={saving}
    />
  );
}

ManageSportLeaguePage.propTypes = {
  sportLeague: PropTypes.object,
  sportLeagues: PropTypes.array,
  conferences: PropTypes.array.isRequired,
  divisions: PropTypes.array.isRequired,
  teams: PropTypes.array.isRequired,
  loadSportLeagues: PropTypes.func,
  loadConferences: PropTypes.func,
  loadDivisions: PropTypes.func,
  loadTeams: PropTypes.func,
  saveSportLeague: PropTypes.func.isRequired,
  addSportLeague: PropTypes.func,
  history: PropTypes.object.isRequired
};

export function getSportLeagueById(sportLeagues, id) {
  let sl =
    sportLeagues.find(
      sportLeague => parseInt(sportLeague.id) === parseInt(id)
    ) || null;
  return sl;
}

function mapStateToProps(state, ownProps) {
  const id = ownProps.match.params.id;
  const sportLeague =
    id && state.sportLeagues.length > 0
      ? getSportLeagueById(state.sportLeagues, id)
      : newSportLeague;
  return {
    sportLeague,
    sportLeagues: state.sportLeagues,
    conferences: state.conferences,
    divisions: state.divisions,
    teams: state.teams
  };
}

const mapDispatchToProps = {
  loadSportLeagues,
  loadConferences,
  loadDivisions,
  loadTeams,
  saveSportLeague,
  addSportLeague
};

const newSportLeague = {
  id: 0,
  name: "",
  isEnabled: false
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ManageSportLeaguePage);
