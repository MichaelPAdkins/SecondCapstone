import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';  // Import Link for navigation
import '../../App.css';
import { Entry } from './Entry.jsx';

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
                    <Entry entry={entry} />
                ))}
            </ul>
        </div>
    );
};

export default EntryList;
