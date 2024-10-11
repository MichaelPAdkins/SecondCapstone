// src/Components/Camera/CameraList.jsx
import React, { useEffect, useState } from 'react';
import "../../App.css";

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

    useEffect(() => {
        fetchCameras();
    }, []);

    return (
        <div>
            <h2>Camera List</h2>
            {/* Debug message to indicate whether any cameras were found */}
            {cameras.length === 0 ? <p>No cameras found.</p> : null}
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {cameras.map((camera) => (
                        <tr key={camera.id}>
                            <td>{camera.id}</td>
                            <td>{camera.name}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CameraList;
