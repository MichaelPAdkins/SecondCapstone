// src/App.jsx
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import Navbar from './Components/Navbar';
import EntryList from './Components/Entry/EntryList.jsx';
import ApplicationViews from './Components/ApplicationViews';

function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                {/* Wrap Route inside Routes and use element instead of component */}
                <Routes>
                    <Route path="/entries/latest" element={<EntryList />} />
                </Routes>
                <ApplicationViews />
            </div>
        </Router>
    );
}

export default App;
