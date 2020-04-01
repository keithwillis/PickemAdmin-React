import React from "react";
import PropTypes from "prop-types";
import DivisionList from "../divisions/DivisionList";
import * as Utilities from "../common/Utilities";
import TabContainer from "react-bootstrap/TabContainer";
import TabContent from "react-bootstrap/TabContent";
import TabPane from "react-bootstrap/TabPane";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Nav from "react-bootstrap/Nav";
import "./ConferenceList.css";

//import { Link } from "react-router-dom";

const ConferenceList = ({ conferences, divisions, teams, sportLeagueId }) => (
  <TabContainer
    id="left-tabs-example"
    defaultActiveKey={conferences[0] ? conferences[0].id : 0}
  >
    <Row>
      <Col sm={3}>
        <Nav variant="pills" className="flex-column">
          {getConferencesById(conferences, sportLeagueId).map(conference => {
            return (
              <Nav.Item key={conference.id}>
                <Nav.Link eventKey={conference.id}>{conference.name}</Nav.Link>
              </Nav.Item>
            );
          })}
        </Nav>
      </Col>
      <Col sm={6}>
        <TabContent>
          {getConferencesById(conferences, sportLeagueId).map(conference => {
            return (
              <TabPane
                key={conference.id}
                eventKey={conference.id}
                title={conference.name}
              >
                <button type="submit" className="btn btn-primary">
                  {"Edit " + conference.name + " Conference"}
                </button>
                {"   "}
                <button type="submit" className="btn btn-primary">
                  {"Add New Division"}
                </button>
                <br />
                <br />
                <DivisionList
                  divisions={divisions}
                  teams={teams}
                  conferenceId={conference.id}
                ></DivisionList>
              </TabPane>
            );
          })}
        </TabContent>
      </Col>
    </Row>
  </TabContainer>
);

export function getConferencesById(conferences, id) {
  let sl =
    conferences
      .filter(conference => parseInt(conference.sportLeagueId) === parseInt(id))
      .sort(Utilities.compareObjectName) || [];
  return sl;
}

ConferenceList.propTypes = {
  conferences: PropTypes.array,
  divisions: PropTypes.array,
  teams: PropTypes.array,
  sportLeagueId: PropTypes.number
};

export default ConferenceList;
