// src/Components/Services/OtherService.js

const baseUrl = 'https://localhost:7013/api';  // Base URL for API

export const getAllTags = () => {
  return fetch(`${baseUrl}/tags`)
    .then(response => response.json())
    .catch(error => {
      console.error("Failed to fetch tags:", error);
      throw error;
    });
};

export const getAllLocations = () => {
  return fetch(`${baseUrl}/locations`)
    .then(response => response.json())
    .catch(error => {
      console.error("Failed to fetch locations:", error);
      throw error;
    });
};
