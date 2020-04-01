import React from "react";
import { connect } from "react-redux";
import * as sportLeagueActions from "../../redux/actions/sportLeagueActions";
import * as conferenceActions from "../../redux/actions/conferenceActions";
import PropTypes from "prop-types";
import { bindActionCreators } from "redux";
import SportLeagueList from "./SportLeagueList";
import { Redirect } from "react-router-dom";
import Spinner from "../common/Spinner";
import { toast } from "react-toastify";

class SportLeaguesPage extends React.Component {
  state = {
    redirectToAddSportLeaguePage: false
  };

  componentDidMount() {
    const { sportLeagues, conferences, actions } = this.props;
    if (sportLeagues.length === 0) {
      actions.loadSportLeagues().catch(error => {
        alert("Loading of Sport Leagues failed" + error);
      });
    }

    if (conferences.length === 0) {
      actions.loadConferences().catch(error => {
        alert("Loading of Conferences failed" + error);
      });
    }
  }

  handleDeleteSportLeague = async sportLeague => {
    toast.success("Course Deleted");
    try {
      await this.props.actions.deleteSportLeague(sportLeague);
    } catch (error) {
      toast.error("Delete Failed " + error.message, { autoClose: false });
    }
  };

  render() {
    return (
      <>
        {this.state.redirectToAddSportLeaguePage && (
          <Redirect to="/sportleague" />
        )}
        <h2>Sport Leagues</h2>
        {this.props.loading ? (
          <Spinner />
        ) : (
          <>
            <button
              style={{ marginBottom: 20 }}
              className="btn btn-primary add-sportleague"
              onClick={() =>
                this.setState({ redirectToAddSportLeaguePage: true })
              }
            >
              Add Sport League
            </button>

            <SportLeagueList
              sportLeagues={this.props.sportLeagues}
              conferences={this.props.conferences}
              onDeleteClick={this.handleDeleteSportLeague}
            ></SportLeagueList>
          </>
        )}
      </>
    );
  }
}

SportLeaguesPage.propTypes = {
  sportLeagues: PropTypes.array.isRequired,
  conferences: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
  loading: PropTypes.bool.isRequired
};

function mapStateToProps(state) {
  return {
    sportLeagues: state.sportLeagues,
    conferences: state.conferences,
    loading: state.apiCallsInProgress > 0
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      loadSportLeagues: bindActionCreators(
        sportLeagueActions.loadSportLeagues,
        dispatch
      ),
      loadConferences: bindActionCreators(
        conferenceActions.loadConferences,
        dispatch
      ),
      deleteSportLeague: bindActionCreators(
        sportLeagueActions.deleteSportLeague,
        dispatch
      )
    }
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(SportLeaguesPage);
