const SignUp = () => {
    return (
        <div className='container'>
            <div className="header">
                <div className='text'>Sign Up</div>
                <div className="userline"></div>
            </div>
            <div className="inputs">
                <div className="inputs">
                <input type='text'/>
                </div>
                <div className="inputs">
                    <input type='email' />
                </div>
                <div className="inputs">
                    <input type='username' />
                </div>
                <div className="inputs">
                    <input type='password' />
                </div>
                <div className="inputs">
                    <input type='password' />
                </div>
            </div>
            <div className='submit-container'>
                <div className="submit">Sign Up</div>
                <div className="submit">Login</div>
            </div>
        </div>
    )
}