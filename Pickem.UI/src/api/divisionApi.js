import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.API_URL + "/api/Divisions/";

export function getDivisions() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveDivision(division) {
  return fetch(baseUrl + (division.id || ""), {
    method: division.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(division)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteDivision(divisionId) {
  return fetch(baseUrl + divisionId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
