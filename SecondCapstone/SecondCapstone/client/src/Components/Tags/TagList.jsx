import React, { useState, useEffect } from 'react';

const TagList = () => {
    const [tags, setTags] = useState([]);

    useEffect(() => {
        // Fetch the list of tags
        fetch('https://localhost:7013/api/tag')
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error fetching tags: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                // Sort tags alphabetically by name
                const sortedTags = data.sort((a, b) => a.name.localeCompare(b.name));
                setTags(sortedTags);
            })
            .catch(error => {
                console.error('Error fetching tags:', error);
            });
    }, []);

    return (
        <div>
            <h2>Tags List</h2>
            <ul>
                {tags.length > 0 ? (
                    tags.map((tag) => (
                        <li key={tag.id}>{tag.name}</li>
                    ))
                ) : (
                    <p>No tags available</p>
                )}
            </ul>
        </div>
    );
};

export default TagList;
