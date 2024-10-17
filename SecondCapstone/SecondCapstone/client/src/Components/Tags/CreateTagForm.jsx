import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { addTag, getTagById, updateTag } from '../Services/TagServices'; // Assuming these functions exist

const CreateTagForm = () => {
    const [tagName, setTagName] = useState('');
    const [isEditing, setIsEditing] = useState(false);
    const { id } = useParams(); // Get tag ID from URL if editing
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            setIsEditing(true);
            getTagById(id)
                .then((data) => {
                    setTagName(data.name);
                })
                .catch((error) => console.error('Error fetching tag:', error));
        }
    }, [id]);

    const handleSubmit = (event) => {
        event.preventDefault();
        const tag = { id: id, name: tagName };  // Include the tag ID if editing
    
        if (isEditing) {
            updateTag(id, tag)  // Ensure the ID is being passed
                .then((response) => {
                    if (!response.ok) {
                        console.error('Failed to update tag: ', response);
                        throw new Error('Failed to update tag');
                    }
                    navigate('/tags/list');
                })
                .catch(error => console.error('Error updating tag:', error));
        } else {
            addTag(tag)
                .then(() => navigate('/tags/list'))
                .catch(error => console.error('Error creating tag:', error));
        }
    };
    

    return (
        <div>
            <h2>{isEditing ? 'Edit Tag' : 'Create New Tag'}</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="tagName">Tag Name:</label>
                    <input
                        type="text"
                        id="tagName"
                        value={tagName}
                        onChange={(e) => setTagName(e.target.value)}
                        placeholder="Enter tag name"
                        required
                    />
                </div>
                <button type="submit">{isEditing ? 'Update Tag' : 'Create Tag'}</button>
            </form>
        </div>
    );
};

export default CreateTagForm;
