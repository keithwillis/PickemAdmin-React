import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.API_URL + "/api/SportLeagues/";

export function getSportLeagues() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveSportLeague(sportLeague) {
  return fetch(baseUrl + (sportLeague.id || ""), {
    method: sportLeague.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(sportLeague)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteSportLeague(sportLeagueId) {
  return fetch(baseUrl + sportLeagueId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
