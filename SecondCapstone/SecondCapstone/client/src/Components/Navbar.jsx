// src/Components/Navbar.jsx
import React, { useState } from 'react';  // Import useState from React
import { Link, useNavigate } from 'react-router-dom';  // Import useNavigate

const Navbar = () => {
    const [searchQuery, setSearchQuery] = useState('');  // Initialize searchQuery state
    const navigate = useNavigate();  // Initialize navigate hook

    const handleSearchChange = (e) => {
        setSearchQuery(e.target.value);  // Update searchQuery state when input changes
    };

    const handleSearchSubmit = (e) => {
        e.preventDefault();
        // Navigate to a search results page or display the search results
        if (searchQuery.trim()) {
            navigate(`/search?query=${searchQuery}`);  // Navigate to the search results page
        }
    };

    return (
        <div className="navbar">
            <h2>Archives Mapped!</h2>
            <nav>
                <Link to="/entries/latest" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Latest Entries</Link>
                {/* <Link to="/entry/create" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Add Entry</Link> */}
                <Link to="/cameras" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Cameras</Link>
                <Link to="/tags/list" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Tag List</Link>
                <Link to="/locations/list" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Locations</Link>

                {/* Uncomment these if you implement login/register */}
                {/* <Link to="/login" style={{ color: 'white', textDecoration: 'none', marginRight: '15px' }}>Login</Link>
                <Link to="/register" style={{ color: 'white', textDecoration: 'none' }}>Register</Link> */}

                {/* Search Bar */}
                <form onSubmit={handleSearchSubmit} style={{ display: 'inline-block', marginLeft: '15px' }}>
                    <input 
                        type="text" 
                        value={searchQuery} 
                        onChange={handleSearchChange} 
                        placeholder="Search..." 
                        style={{ padding: '5px' }}
                    />
                    <button type="submit" style={{ padding: '5px 10px', marginLeft: '5px' }}>Search</button>
                </form>
            </nav>
        </div>
    );
};

export default Navbar;
