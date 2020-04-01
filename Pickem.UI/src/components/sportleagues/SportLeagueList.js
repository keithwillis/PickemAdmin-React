import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const SportLeagueList = ({ sportLeagues, onDeleteClick }) => (
  <table className="table">
    <thead>
      <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Is Enabled</th>
        <th />
      </tr>
    </thead>
    <tbody>
      {sportLeagues.map(sportLeague => {
        return (
          <tr key={sportLeague.id}>
            <td>{sportLeague.id}</td>
            <td>
              <Link to={"/sportleague/" + sportLeague.id}>
                {sportLeague.name}
              </Link>
            </td>
            <td>
              <input type="checkbox" checked={sportLeague.isEnabled} readOnly />
            </td>
            <td>
              <button
                className="btn btn-outline-danger"
                onClick={() => onDeleteClick(sportLeague)}
              >
                Delete
              </button>
            </td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

SportLeagueList.propTypes = {
  sportLeagues: PropTypes.array.isRequired,
  onDeleteClick: PropTypes.func.isRequired
};

export default SportLeagueList;
