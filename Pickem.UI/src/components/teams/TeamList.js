import React from "react";
import PropTypes from "prop-types";
import * as Utilities from "../common/Utilities";
//import { Link } from "react-router-dom";

const TeamList = ({ teams, divisionId }) => (
  <table className="table">
    <tbody>
      {getTeamsByDivisionId(teams, divisionId).map(team => {
        return (
          <tr key={team.id}>
            <td>
              <a className="btn btn-light" href={"/teams/" + team.id}>
                {team.location} {team.name}
              </a>
              <input type="checkbox" checked={team.isActive} readOnly />
            </td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

export function getTeamsByDivisionId(teams, id) {
  let sl =
    teams
      .filter(team => parseInt(team.divisionId) === parseInt(id))
      .sort(Utilities.compareTeam) || [];
  return sl;
}

TeamList.propTypes = {
  teams: PropTypes.array.isRequired,
  divisionId: PropTypes.number.isRequired
};

export default TeamList;
