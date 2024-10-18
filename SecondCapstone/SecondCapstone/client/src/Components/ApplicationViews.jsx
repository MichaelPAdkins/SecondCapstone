import React from 'react';
import { Route, Routes } from 'react-router-dom';
import CameraList from './Camera/CameraList';
import EntryList from './Entry/EntryList';
import LocationList from './Locations/LocationList.jsx';  
import CreateLocationForm from './Locations/CreateLocationForm.jsx';
import TagList from './Tags/TagList.jsx';
import CreateTagForm from './Tags/CreateTagForm.jsx';
import EntryForm from './Entry/EntryForm.jsx';
import Authorize from './Authorize';

const ApplicationViews = () => {
  return (
    <Routes>
      {/* Define your specific routes first */}
      <Route path="/entries/latest" element={<EntryList />} />
      <Route path="/entry/create" element={<EntryForm />} />
    <Route path="/tags/list" element={<TagList />} />
      <Route path="/tags/create" element={<CreateTagForm />} />{" "}
      {/* Route for Create Tag */}
      {/* Route to create/edit a tag */}
      <Route path="/tags/create/:id?" element={<CreateTagForm />} />
      <Route path="/locations" element={<LocationList />} />

      <Route path="/locations/list" element={<LocationList />} />
      <Route path="/locations/create" element={<CreateLocationForm />} />
      {/* Route for Create Tag */}
      {/* Route to create/edit a tag */}
      <Route path="/locations/create/:id?" element={<CreateLocationForm />} />
      <Route path="/cameras" element={<CameraList />} />
      {/* Catch-all route for non-matching paths */}
      <Route path="/*" element={<Authorize />} />
    </Routes>
  );
};

export default ApplicationViews;
