import React from "react";
import PropTypes from "prop-types";
import TeamList from "../teams/TeamList";
import * as Utilities from "../common/Utilities";
import Accordion from "react-bootstrap/Accordion";
import Card from "react-bootstrap/Card";

//import { Link } from "react-router-dom";

const DivisionList = ({ divisions, teams, conferenceId }) => (
  <Accordion>
    {getDivisionsById(divisions, conferenceId).map(division => {
      return (
        <Card key={division.id}>
          <Accordion.Toggle eventKey={division.id}>
            <a className="btn btn-light" href={"/sportleague/" + division.id}>
              {division.name}
            </a>
            <input type="checkbox" checked={division.isActive} readOnly />
            &nbsp;{" "}
          </Accordion.Toggle>
          <Accordion.Collapse eventKey={division.id}>
            <Card.Body>
              <TeamList teams={teams} divisionId={division.id}></TeamList>
            </Card.Body>
          </Accordion.Collapse>
        </Card>
      );
    })}
  </Accordion>
);

export function getDivisionsById(divisions, id) {
  let sl =
    divisions
      .filter(division => parseInt(division.conferenceId) === parseInt(id))
      .sort(Utilities.compareObjectName) || [];
  return sl;
}

DivisionList.propTypes = {
  divisions: PropTypes.array.isRequired,
  teams: PropTypes.array.isRequired,
  conferenceId: PropTypes.number.isRequired
};

export default DivisionList;
