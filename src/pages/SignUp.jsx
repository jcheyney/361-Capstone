import React, { useState } from 'react';

const SignUp = ({ setPage }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  const handleSignup = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      alert('Passwords do not match!');
      return;
    }

    console.log('User registered:', { username, password });
    alert('Sign-up successful!');
    setUsername('');
    setPassword('');
    setConfirmPassword('');
    setPage('home');
  };

  return (
    <div className="d-flex vh-100 justify-content-center align-items-center bg-light">
      <div className="card shadow-lg p-5" style={{ width: '28rem' }}>
        <h2 className="text-center mb-4">Create an Account</h2>
        <form onSubmit={handleSignup}>
          <div className="mb-3">
            <label className="form-label">Username</label>
            <input
              type="text"
              className="form-control"
              placeholder="Enter your username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label">Password</label>
            <input
              type="password"
              className="form-control"
              placeholder="Enter your password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label">Confirm Password</label>
            <input
              type="password"
              className="form-control"
              placeholder="Confirm your password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              required
            />
          </div>

          <div className="d-grid">
            <button type="submit" className="btn btn-danger btn-lg">
              Sign Up
            </button>
          </div>
        </form>

        <p className="text-center mt-3">
          Already have an account?{' '}
          <button 
            className="btn btn-link p-0 text-decoration-none" 
            onClick={() => setPage('Login')}>
            Login here
          </button>
        </p>
      </div>
    </div>
  );
};

export default SignUp;
