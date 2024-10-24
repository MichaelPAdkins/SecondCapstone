// src/Components/SearchResults.jsx
import React, { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';

const SearchResults = () => {
    const [results, setResults] = useState([]);
    const location = useLocation();
    const query = new URLSearchParams(location.search).get('query');

    useEffect(() => {
        if (query) {
            fetch(`https://localhost:7013/api/Search?query=${query}`)
                .then(response => response.json())
                .then(data => setResults(data))
                .catch(error => console.error('Error fetching search results:', error));
        }
    }, [query]);

    return (
        <div className="search-results">
            <h2>Search Results for "{query}"</h2>
            {results.length > 0 ? (
                <ul>
                    {results.map((result, index) => (
                        <li key={index}>
                            <p><strong>File Name:</strong> {result.fileName || 'N/A'}</p>
                            <p><strong>Capture Date:</strong> {result.captureDate || 'N/A'}</p>
                            <p><strong>Resolution:</strong> {result.resolution || 'N/A'}</p>
                            <p><strong>File Size:</strong> {result.fileSize || 'N/A'}</p>
                            <p><strong>Physical Backups:</strong> {result.physicalBackUps || 'N/A'}</p>

                            {/* Display Camera */}
                            {result.camera && (
                                <p><strong>Camera:</strong> {result.camera.name || 'N/A'}</p>
                            )}

                            {/* If you want to render tags and locations */}
                            {/* Render Locations */}
                            {result.entryLocations && result.entryLocations.length > 0 ? (
                                <div>
                                    <p><strong>Locations:</strong></p>
                                    <ul>
                                        {result.entryLocations.map((location, locIndex) => (
                                            <li key={locIndex}>{location.name}</li>
                                        ))}
                                    </ul>
                                </div>
                            ) : (
                                <p>No locations available</p>
                            )}

                            {/* Render Tags */}
                            {result.entryTags && result.entryTags.length > 0 ? (
                                <div>
                                    <p><strong>Tags:</strong></p>
                                    <ul>
                                        {result.entryTags.map((tag, tagIndex) => (
                                            <li key={tagIndex}>{tag.name}</li>
                                        ))}
                                    </ul>
                                </div>
                            ) : (
                                <p>No tags available</p>
                            )}
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No results found</p>
            )}
        </div>
    );
};

export default SearchResults;
