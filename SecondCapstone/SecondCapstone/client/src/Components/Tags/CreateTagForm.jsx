import React, { useState } from 'react';
import { addTag } from '../Services/TagServices';  // Ensure correct import path

const CreateTagForm = () => {
    const [tagName, setTagName] = useState('');
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        setErrorMessage('');

        if (tagName.trim() === '') {
            setErrorMessage('Tag name cannot be empty');
            return;
        }

        const newTag = { name: tagName };  // Only send the tag name
        console.log('Submitting tag data:', newTag);  // Log the tag data being sent

        setIsSubmitting(true);

        // Call the addTag function from TagServices
        addTag(newTag)
            .then((response) => {
                if (!response.ok) {
                    console.error('Failed to create tag: ', response);
                    throw new Error('Failed to create tag');
                }
                return response.json();
            })
            .then(() => {
                alert('Tag created successfully!');
                setTagName('');  // Reset the input field after successful creation
            })
            .catch((error) => {
                console.error('Error creating tag:', error);
                setErrorMessage('Failed to create tag. Please try again.');
            })
            .finally(() => {
                setIsSubmitting(false);
            });
    };

    return (
        <div>
            <h2>Create New Tag</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="tagName">Tag Name:</label>
                    <input
                        type="text"
                        id="tagName"
                        value={tagName}
                        onChange={(e) => setTagName(e.target.value)}
                        placeholder="Enter tag name"
                        disabled={isSubmitting}
                    />
                </div>
                <button type="submit" disabled={isSubmitting}>
                    {isSubmitting ? 'Creating...' : 'Create Tag'}
                </button>
            </form>
            {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
        </div>
    );
};

export default CreateTagForm;
