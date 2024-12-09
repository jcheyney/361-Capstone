import React, { useState } from 'react';

const mockUsers = [
  { username: 'admin', password: 'admin123' },
  { username: 'testuser', password: 'test1234' },
];

const Login = ({ setPage, onLoginSuccess }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = (e) => {
    e.preventDefault();

    const user = mockUsers.find(
      (user) => user.username === username && user.password === password
    );

    if (user) {
      alert(`Welcome back, ${user.username}!`);
      onLoginSuccess(user.username);
    } else {
      alert('Invalid username or password!');
    }
  };

  return (
    <div className="d-flex vh-100 justify-content-center align-items-center bg-light">
      <div className="card shadow-lg p-5" style={{ width: '25rem' }}>
        <h3 className="text-center mb-4">Login</h3>
        <form onSubmit={handleLogin}>
          <div className="mb-3">
            <label className="form-label">Username</label>
            <input
              type="text"
              className="form-control"
              placeholder="Enter username"
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
              placeholder="Enter password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          <div className="d-grid mb-3">
            <button type="submit" className="btn btn-danger btn-lg">
              Login
            </button>
          </div>
        </form>

        <p className="text-center">
          Forgot your password?{' '}
          <a href="#" className="text-decoration-none text-danger">
            Reset here
          </a>
        </p>

        <p className="text-center">
          Don't have an account?{' '}
          <button
            className="btn btn-link text-decoration-none text-danger"
            onClick={() => setPage('SignUp')}
          >
            Sign Up
          </button>
        </p>
      </div>
    </div>
  );
};

export default Login;
