// src/Components/Navbar.jsx
import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <div className="navbar">
            <h2>SecondCapstone</h2>
            <nav>
                <Link to="/entries/latest" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Latest Entries</Link>
                <Link to="/entry/create" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Add Entry</Link>
                <Link to="/cameras" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Cameras</Link>
                <Link to="/tags/list" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Tag List</Link>
                <Link to="/locations/list" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Locations</Link>

                {/* Uncomment these if you implement login/register */}
                {/* <Link to="/login" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Login</Link>
                <Link to="/register" style={{ color: 'white', textDecoration: 'none' }}>Register</Link> */}
            </nav>
        </div>
    );
};

export default Navbar;
