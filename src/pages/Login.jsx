import { useState } from 'react';
function Login({ setPage }) {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = (e) => {
        e.preventDefault();
        if (username && password) {
            alert(`Welcome back, ${username}!`);
            setPage('home');
        } else {
            alert('Please fill in both fields.');
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
                        </div>
                    </div>
                    <p className="forgot-password text-right">
                        Forgot <a href="#">password?</a>
                    </p>
                    <p>
                        Don't have an account?{' '}
                        <button onClick={() => setPage('SignUp')}>Sign Up</button>
                    </p>

                </div>
            </div>
        </div>
    )
}
export default Login