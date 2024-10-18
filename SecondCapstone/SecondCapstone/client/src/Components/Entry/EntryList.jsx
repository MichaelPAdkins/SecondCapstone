import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';  // Import Link for navigation
import '../../App.css';

const EntryList = () => {
    const [entries, setEntries] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7013/api/Entry/latest')  // Ensure backend URL is correct
            .then(response => {
                console.log('Full response:', response);  // Log the full response for debugging
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                console.log('Fetched data:', data);  // Log the fetched data for debugging
                setEntries(data);
            })
            .catch(error => console.error('Error fetching entries:', error));
    }, []);

    return (
        <div className="entries-container">
            <h2>Last 10 Entries</h2>

            {/* Add Entry button */}
            <div className="add-entry-button">
                <Link to="/entry/create">
                    <button>Add New Entry</button>
                </Link>
            </div>

            <ul>
                {entries.map((entry) => (
                    <li key={entry.id} className="entry-item">
                        <p><strong>File Name:</strong> {entry.fileName}</p>
                        <p><strong>Capture Date:</strong> {entry.captureDate}</p>
                        <p><strong>Resolution:</strong> {entry.resolution}</p>
                        <p><strong>File Size:</strong> {entry.fileSize}</p>
                        <p><strong>Physical Backups:</strong> {entry.physicalBackUps}</p>

                        {/* Display Camera */}
                        {entry.camera && (
                            <p><strong>Camera:</strong> {entry.camera.name}</p>
                        )}

                        {/* Display EntryLocations */}
                        {entry.entryLocations && entry.entryLocations.length > 0 ? (
                            <div>
                                <p><strong>Locations:</strong></p>
                                <ul>
                                    {entry.entryLocations.map((location, index) => (
                                        <li key={index}>{location.name}</li>
                                    ))}
                                </ul>
                            </div>
                        ) : (
                            <p>No locations available</p>
                        )}

                        {/* Display EntryTags */}
                        {entry.entryTags && entry.entryTags.length > 0 ? (
                            <div>
                                <p><strong>Tags:</strong></p>
                                <ul>
                                    {entry.entryTags.map((tag, index) => (
                                        <li key={index}>{tag.name}</li>
                                    ))}
                                </ul>
                            </div>
                        ) : (
                            <p>No tags available</p>
                        )}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default EntryList;
