import React, { useState, useEffect } from 'react';

const EntryList = () => {
    const [entries, setEntries] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7013/api/Entry/latest')  // Update the URL with the correct backend port
            .then(response => {
                console.log('Full response:', response);  // Log the full response for debugging
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => setEntries(data))
            .catch(error => console.error('Error fetching entries:', error));
    }, []);
    
    


    return (
        <div>
            <h2>Last 10 Entries</h2>
            <ul>
                {entries.map((entry) => (
                    <li key={entry.id}>
                        <p><strong>File Name:</strong> {entry.fileName}</p>
                        <p><strong>Capture Date:</strong> {entry.captureDate}</p>
                        <p><strong>Resolution:</strong> {entry.resolution}</p>
                        <p><strong>File Size:</strong> {entry.fileSize}</p>
                        <p><strong>Physical Backups:</strong> {entry.physicalBackUps}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default EntryList;
