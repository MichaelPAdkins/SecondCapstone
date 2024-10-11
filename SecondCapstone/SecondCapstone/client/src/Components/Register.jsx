// src/Components/Register.jsx
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Register.css";

const Register = ({ setIsLoggedIn }) => {
    const navigate = useNavigate();

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [displayName, setDisplayName] = useState("");
    const [email, setEmail] = useState("");
    const [imageLocation, setImageLocation] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const registerClick = async (e) => {
        e.preventDefault();

        if (password && password !== confirmPassword) {
            alert("Passwords don't match.");
            return;
        }

        const userProfile = { firstName, lastName, displayName, email, imageLocation };

        try {
            const response = await fetch("https://localhost:7013/api/UserProfile/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ userProfile, password }),
            });

            if (response.ok) {
                const userProfileData = await response.json();
                localStorage.setItem("userProfile", JSON.stringify(userProfileData));
                setIsLoggedIn(true);
                navigate("/");
            } else {
                alert("Registration failed. Please try again.");
            }
        } catch (error) {
            console.error("Registration error:", error);
            alert("An error occurred during registration. Please try again.");
        }
    };

    return (
        <form className="register-form" onSubmit={registerClick}>
            <fieldset>
                <legend>Register</legend>
                <div>
                    <label htmlFor="firstName">First Name</label>
                    <input
                        id="firstName"
                        type="text"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="lastName">Last Name</label>
                    <input
                        id="lastName"
                        type="text"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="displayName">Display Name</label>
                    <input
                        id="displayName"
                        type="text"
                        value={displayName}
                        onChange={(e) => setDisplayName(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="email">Email</label>
                    <input
                        id="email"
                        type="text"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="imageLocation">Profile Image URL</label>
                    <input
                        id="imageLocation"
                        type="text"
                        value={imageLocation}
                        onChange={(e) => setImageLocation(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="password">Password</label>
                    <input
                        id="password"
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input
                        id="confirmPassword"
                        type="password"
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                    />
                </div>
                <div>
                    <button type="submit">Register</button>
                </div>
            </fieldset>
        </form>
    );
};

export default Register;
