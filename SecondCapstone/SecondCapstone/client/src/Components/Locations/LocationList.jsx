import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { getAllLocations, deleteLocation } from '../Services/LocationServices'; // Ensure services are correctly imported

const LocationList = () => {
    const [locations, setLocations] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetchLocations();
    }, []);

    const fetchLocations = () => {
        getAllLocations()
            .then(data => {
                // Sort locations alphabetically by name
                const sortedLocations = data.sort((a, b) => a.name.localeCompare(b.name));
                setLocations(sortedLocations);
            })
            .catch(error => console.error('Error fetching locations:', error));
    };

    const handleDelete = (locationId) => {
        if (window.confirm("Are you sure you want to delete this location?")) {
            deleteLocation(locationId)
                .then(() => fetchLocations()) // Refresh the list after deletion
                .catch(error => console.error('Error deleting location:', error));
        }
    };

    const handleEdit = (locationId) => {
        navigate(`/locations/create/${locationId}`); // Correctly use backticks for template string
    };

    return (
        <div>
            <h2>Location List</h2>

            {/* Create New Location Button */}
            <Link to="/locations/create">
                <button>Create New Location</button>
            </Link>

            {/* List of Locations */}
            <ul>
                {locations.length > 0 ? (
                    locations.map((location) => (
                        <li key={location.id} style={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
                            <span style={{ marginRight: '20px' }}>{location.name}</span>

                            {/* Edit Button */}
                            <button onClick={() => handleEdit(location.id)} style={{ marginRight: '10px' }}>Edit</button>

                            {/* Delete Button */}
                            <button onClick={() => handleDelete(location.id)} style={{ marginRight: '10px' }}>Delete</button>
                        </li>
                    ))
                ) : (
                    <p>No Locations Available</p>
                )}
            </ul>
        </div>
    );
};

export default LocationList;
