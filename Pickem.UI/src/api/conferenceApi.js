import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.API_URL + "/api/Conferences/";

export function getConferences() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveConference(conference) {
  return fetch(baseUrl + (conference.id || ""), {
    method: conference.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(conference)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteConference(conferenceId) {
  return fetch(baseUrl + conferenceId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
