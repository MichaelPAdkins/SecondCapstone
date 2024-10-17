import React from 'react';
import { Route, Routes } from 'react-router-dom';
import CameraList from './Camera/CameraList';
import EntryList from './Entry/EntryList';  
import TagList from './Tags/TagList.jsx';
import CreateTagForm from './Tags/CreateTagForm.jsx';
import Authorize from './Authorize';

const ApplicationViews = () => {
    return (
        <Routes>
            {/* Define your specific routes first */}
            <Route path="/entries/latest" element={<EntryList />} />
            <Route path="/tags/list" element={<TagList />} />
            <Route path="/tags/create" element={<CreateTagForm />} />  {/* Route for Create Tag */}
            <Route path="/cameras" element={<CameraList />} />
            
            {/* Catch-all route for non-matching paths */}
            <Route path="/*" element={<Authorize />} />
        </Routes>
    );
};

export default ApplicationViews;
