// src/App.jsx
import React from 'react';
import './App.css';
import Navbar from './Components/Navbar';
import ApplicationViews from './Components/ApplicationViews';

function App() {
    return (
        <div className="App">
            <Navbar />
            <ApplicationViews />
        </div>
    );
}

export default App;
