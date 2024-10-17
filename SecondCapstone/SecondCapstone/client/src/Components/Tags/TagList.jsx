import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { getAllTags, deleteTag } from '../Services/TagServices'; // Assuming you have the delete function in TagServices

const TagList = () => {
    const [tags, setTags] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetchTags();
    }, []);

    const fetchTags = () => {
        getAllTags()
            .then(data => {
                // Sort tags alphabetically by name
                const sortedTags = data.sort((a, b) => a.name.localeCompare(b.name));
                setTags(sortedTags);
            })
            .catch(error => console.error('Error fetching tags:', error));
    };

    const handleDelete = (tagId) => {
        if (window.confirm("Are you sure you want to delete this tag?")) {
            deleteTag(tagId)
                .then(() => fetchTags()) // Refresh the list after deleting
                .catch(error => console.error('Error deleting tag:', error));
        }
    };

    const handleEdit = (tagId) => {
        navigate(`/tags/create/${tagId}`); // Navigate to the edit page with the tag ID
    };

    return (
        <div>
            <h2>Tag List</h2>

            {/* Create New Tag Button */}
            <Link to="/tags/create">
                <button>Create New Tag</button>
            </Link>

            {/* List of Tags */}
            <ul>
                {tags.length > 0 ? (
                    tags.map((tag) => (
                        <li key={tag.id} style={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
                            <span style={{ marginRight: '20px' }}>{tag.name}</span>

                            {/* Edit Button */}
                            <button onClick={() => handleEdit(tag.id)} style={{ marginRight: '10px' }}>Edit</button>

                            {/* Delete Button */}
                            <button onClick={() => handleDelete(tag.id)} style={{ marginRight: '10px' }}>Delete</button>
                        </li>
                    ))
                ) : (
                    <p>No Tags Available</p>
                )}
            </ul>
        </div>
    );
};

export default TagList;
