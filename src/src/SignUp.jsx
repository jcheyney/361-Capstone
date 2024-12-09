import { useState } from 'react';
function signUp() {
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    return (
        <div className='SignUp-Screen'>
            <div className='container'>
                <div>
                    <div className="Login">
                        <div className='text'>Sign Up</div>
                        <div className="userline"></div>
                    </div>
                    <div className="email">
                        <label>Email</label>
                        <input
                            type="email"
                            placeholder="Enter your email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)} />
                    </div>
                    <div className="username">
                        <label>Username</label>
                        <input
                            type="username"
                            placeholder="Enter your username"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)} />
                    </div>
                    <div className="pasword">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="Enter your password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}                        />
                    </div>
                    <div className="confirm-password">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="confirm your password"
                            value={confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}                        />
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
export default signUp
