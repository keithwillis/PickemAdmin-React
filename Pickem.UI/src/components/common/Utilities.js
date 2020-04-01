export function compareObjectName(a, b) {
  const objectA = a.name.toUpperCase();
  const objectB = b.name.toUpperCase();

  let comparison = 0;

  if (objectA > objectB) comparison = 1;
  else if (objectA < objectB) comparison = -1;

  return comparison;
}

export function compareTeam(a, b) {
  const locationA = a.location.toUpperCase();
  const locationB = b.location.toUpperCase();
  const nameA = a.name.toUpperCase();
  const nameB = b.name.toUpperCase();

  let comparison = 0;

  if (locationA > locationB) comparison = 1;
  else if (locationA < locationB) comparison = -1;
  else if (locationA === locationB) {
    if (nameA > nameB) comparison = 1;
    else if (nameA < nameB) comparison = -1;
  }

  return comparison;
}
