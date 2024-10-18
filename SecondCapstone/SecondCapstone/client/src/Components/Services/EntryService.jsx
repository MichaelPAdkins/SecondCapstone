// src/Components/Services/EntryService.jsx

const baseUrl = 'https://localhost:7013/api/Entry';  // Update the URL if needed

export const createEntry = (entryData) => {
  return fetch(baseUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(entryData),
  })
    .then(response => {
      if (!response.ok) {
        throw new Error('Failed to create new entry');
      }
      return response.json();
    });
};
