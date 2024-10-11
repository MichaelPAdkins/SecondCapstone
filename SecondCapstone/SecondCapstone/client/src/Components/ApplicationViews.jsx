// src/Components/ApplicationViews.jsx
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import CameraList from './Camera/CameraList';
import Authorize from './Authorize';

const ApplicationViews = () => {
    return (
        <Routes>
            <Route path="/cameras" element={<CameraList />} />
            <Route path="/*" element={<Authorize />} />
        </Routes>
    );
};

export default ApplicationViews;
