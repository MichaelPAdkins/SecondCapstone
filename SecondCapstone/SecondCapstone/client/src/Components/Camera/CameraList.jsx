// src/Components/Camera/CameraList.jsx
import React, { useEffect, useState } from 'react';
import "../../App.css"; // Adjusted to ensure global styles are applied

const CameraList = () => {
    const [cameras, setCameras] = useState([]);

    const fetchCameras = async () => {
        try {
            const response = await fetch("https://localhost:7013/api/Camera");
            if (response.ok) {
                const data = await response.json();
                setCameras(data);
            } else {
                console.error("Failed to fetch cameras");
            }
        } catch (error) {
            console.error("Error fetching cameras:", error);
        }
    };

    const deleteCamera = async (id) => {
        try {
            const response = await fetch(`https://localhost:7013/api/Camera/${id}`, {
                method: "DELETE",
            });

            if (response.ok) {
                fetchCameras(); // Refresh the list
            } else {
                console.error("Failed to delete camera");
            }
        } catch (error) {
            console.error("Error deleting camera:", error);
        }
    };

    useEffect(() => {
        fetchCameras();
    }, []);

    return (
        <div>
            <h2>Camera List</h2>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {cameras.map((camera) => (
                        <tr key={camera.id}>
                            <td>{camera.id}</td>
                            <td>{camera.name}</td>
                            <td>
                                <button onClick={() => alert(`Edit Camera ${camera.id}`)}>Edit</button>
                                <button onClick={() => deleteCamera(camera.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CameraList;
