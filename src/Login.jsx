function Login() {
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
                            placeholder="Enter username" />
                    </div>
                    <div className="pasword">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="Enter password" />
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
