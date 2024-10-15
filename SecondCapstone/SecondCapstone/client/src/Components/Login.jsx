// src/Components/Login.jsx
import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import "./Login.css";

const Login = ({ setIsLoggedIn }) => {
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const loginSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("https://localhost:7013/api/UserProfile/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ email, password }),
            });

            if (response.ok) {
                const userProfile = await response.json();
                localStorage.setItem("userProfile", JSON.stringify(userProfile));
                setIsLoggedIn(true);
                navigate("/");
            } else {
                alert("Invalid email or password");
            }
        } catch (error) {
            console.error("Login error:", error);
            alert("An error occurred while logging in. Please try again.");
        }
    };

    return (
        <form className="login-form" onSubmit={loginSubmit}>
            <fieldset>
                <legend>Login</legend>
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
                    <label htmlFor="password">Password</label>
                    <input
                        id="password"
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div>
                    <button type="submit">Login</button>
                </div>
                <em>
                    Not registered? <Link to="/register">Register</Link>
                </em>
            </fieldset>
        </form>
    );
};

export default Login;
