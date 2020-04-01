import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.API_URL + "/api/Teams/";

export function getTeams() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveTeam(team) {
  return fetch(baseUrl + (team.id || ""), {
    method: team.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(team)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteTeam(teamId) {
  return fetch(baseUrl + teamId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
