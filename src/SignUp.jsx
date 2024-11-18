function signUp() {
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
                            placeholder="Enter your email" />
                    </div>
                    <div className="username">
                        <label>Username</label>
                        <input
                            type="username"
                            placeholder="Enter your username" />
                    </div>
                    <div className="pasword">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="Enter your password" />
                    </div>
                    <div className="confirm-password">
                        <label>Password</label>
                        <input
                            type="password"
                            placeholder="confirm your password" />
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
