const baseURL = 'https://localhost:7013/api/location';  // Make sure to update the URL to match your backend route

export const getAllLocations = () => {
    return fetch(`${baseURL}`)
        .then((res) => res.json());
};

export const addLocation = (newLocation) => {
    return fetch('https://localhost:7013/api/location', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newLocation),
    });
};


export const getLocationById = (id) => {
    return fetch(`${baseURL}/${id}`)
        .then((res) => res.json());
};

export const updateLocation = (id, updatedLocation) => {
    return fetch(`${baseURL}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedLocation),
    });
};

export const deleteLocation = (locationId) => {
    return fetch(`${baseURL}/${locationId}`, {
        method: 'DELETE',
    });
};
