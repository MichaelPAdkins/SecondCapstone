import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { addLocation, getLocationById, updateLocation } from '../Services/LocationServices';  // Ensure correct imports

const CreateLocationForm = () => {
    const [locationName, setLocationName] = useState('');
    const [isEditing, setIsEditing] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const { id } = useParams(); // Get location ID from URL if editing
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            setIsEditing(true);  // This is an edit
            getLocationById(id)  // Fetch the location data to edit
                .then((data) => {
                    setLocationName(data.name);  // Populate the form with existing location data
                })
                .catch((error) => console.error('Error fetching location:', error));
        }
    }, [id]);

    const handleSubmit = (event) => {
        event.preventDefault();
        setErrorMessage('');

        if (locationName.trim() === '') {
            setErrorMessage('Location name cannot be empty');
            return;
        }

        const location = { id: id, name: locationName };  // Include the location ID if editing

        setIsSubmitting(true);

        if (isEditing) {
            // Update existing location
            updateLocation(id, location)
                .then((response) => {
                    if (!response.ok) {
                        console.error('Failed to update location: ', response);
                        throw new Error('Failed to update location');
                    }
                    navigate('/locations/list');  // Navigate back to the location list after updating
                })
                .catch((error) => {
                    console.error('Error updating location:', error);
                    setErrorMessage('Failed to update location. Please try again.');
                })
                .finally(() => setIsSubmitting(false));
        } else {
            // Create new location
            addLocation(location)
                .then((response) => {
                    if (!response.ok) {
                        console.error('Failed to create location: ', response);
                        throw new Error('Failed to create location');
                    }
                    return response.json();
                })
                .then(() => {
                    alert('Location created successfully!');
                    setLocationName('');  // Reset the form after successful creation
                    navigate('/locations/list');  // Navigate back to the location list after creating
                })
                .catch((error) => {
                    console.error('Error creating location:', error);
                    setErrorMessage('Failed to create location. Please try again.');
                })
                .finally(() => setIsSubmitting(false));
        }
    };

    return (
        <div>
            <h2>{isEditing ? 'Edit Location' : 'Create New Location'}</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="locationName">Location Name:</label>
                    <input
                        type="text"
                        id="locationName"
                        value={locationName}
                        onChange={(e) => setLocationName(e.target.value)}
                        placeholder="Enter location name"
                        disabled={isSubmitting}
                    />
                </div>
                <button type="submit" disabled={isSubmitting}>
                    {isEditing ? (isSubmitting ? 'Updating...' : 'Update Location') : (isSubmitting ? 'Creating...' : 'Create Location')}
                </button>
            </form>
            {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
        </div>
    );
};

export default CreateLocationForm;
