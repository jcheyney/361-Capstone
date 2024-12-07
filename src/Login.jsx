import { useState } from 'react';
function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    
        
    // Function to handle the login form submission
    const handleLogin = async (e) => {
        e.preventDefault(); // Prevent the default form submission behavior

        // Send the username and password to the backend API using fetch
        const response = await fetch('http://localhost:5173/api/login', {
            method: 'POST',  // We are sending a POST request to the backend
            headers: {
                'Content-Type': 'application/json', // Tell the server the content we're sending is in JSON format
            },
            body: JSON.stringify({
                username: username,  // Send the username from the state
                password: password,  // Send the password from the state
            }),
        });

        // Parse the JSON response from the backend
        const data = await response.json();

        // Check the response to determine if the login was successful
        if (data.success) {
            console.log("Login successful"); // If the login was successful
        } else {
            console.log("Login failed"); // If the login failed
        }
    };
    
    return (
        <div className='Login-Screen'>
            <div className='container'>
                <div>
                    <div className="Login">
                        <div className='text'>Login</div>
                        <div className="userline"></div>
                    </div>
                    <div className="username">
                        <label>Username</label>
                        <input
                            type="username"
                            placeholder="Enter username"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                            />
                    </div>
                    <div className="pasword">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="Enter password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <div className='submit-container'>
                        <div className="submit">
                            <button type="submit" className="login-button">Login</button>
                            <button type="submit" className="login-button">Sign Up</button>
                        </div>
                    </div>
                    <p className="forgot-password text-right">
                        Forgot <a href="#">password?</a>
                    </p>
                </div>
            </div>
        </div>
    )
}
export default Login
