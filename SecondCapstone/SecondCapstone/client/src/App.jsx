// src/App.jsx
import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import './App.css';
import Navbar from './Components/Navbar';
import ApplicationViews from './Components/ApplicationViews'; // Handle all routes here

function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                <ApplicationViews />
            </div>
        </Router>
    );
}

export default App;
