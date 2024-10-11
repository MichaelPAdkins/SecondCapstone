// src/Components/Navbar.jsx
import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <div className="navbar">
            <h2>SecondCapstone</h2>
            <nav>
                <Link to="/cameras" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Cameras</Link>
                <Link to="/login" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Login</Link>
                <Link to="/register" style={{ color: 'white', textDecoration: 'none' }}>Register</Link>
            </nav>
        </div>
    );
};

export default Navbar;
