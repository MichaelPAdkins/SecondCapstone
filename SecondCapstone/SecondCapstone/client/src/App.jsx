// src/App.jsx
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import Navbar from './Components/Navbar';
import ApplicationViews from './Components/ApplicationViews';

function App() {
    return (
        <BrowserRouter>
            <div className="App">
                <Navbar />
                <ApplicationViews />
            </div>
        </BrowserRouter>
    );
}

export default App;
