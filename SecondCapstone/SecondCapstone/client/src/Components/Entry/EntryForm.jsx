// src/Components/Entry/EntryForm.jsx

import React, { useState } from 'react';
import { createEntry } from '../Services/EntryService.jsx';

// "id": 51,
// "fileName": "20191017orf7432.jpg",
// "captureDate": "10/17/2019",
// "fileSize": "19.92 MB",
// "resolution": "6192 x 8526",
// "physicalBackUps": "Master 1, External Drive 4",
// "cameraId": 3,
// "userId": 1,


const EntryForm = () => {
  const [entry, setEntry] = useState({
    fileName: '',
    captureDate: '',
    fileSize: '',
    resolution: '',
    physicalBackUps: '',
    cameraId: 0,
    userId: 0,  // Replace with the actual logged-in user ID if needed
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setEntry({
      ...entry,
      [name]: value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    createEntry(entry)
      .then((data) => {
        console.log('Entry created successfully:', data);
        // Optionally reset the form or redirect the user
      })
      .catch((error) => {
        console.error('Error creating entry:', error);
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>File Name:</label>
      <input type="text" name="fileName" value={entry.fileName} onChange={handleChange} required />

      <label>Capture Date:</label>
      <input type="text" name="captureDate" value={entry.captureDate} onChange={handleChange} required />

      <label>File Size:</label>
      <input type="text" name="fileSize" value={entry.fileSize} onChange={handleChange} required />

      <label>Resolution:</label>
      <input type="text" name="resolution" value={entry.resolution} onChange={handleChange} required />

      <label>Physical Backups:</label>
      <input type="text" name="physicalBackUps" value={entry.physicalBackUps} onChange={handleChange} required />

      <label>Camera ID:</label>
      <input type="number" name="cameraId" value={entry.cameraId} onChange={handleChange} required />

      <label>User ID:</label>
      <input type="number" name="userId" value={entry.userId} onChange={handleChange} required />

      <button type="submit">Create Entry</button>
    </form>
  );
};

export default EntryForm;
