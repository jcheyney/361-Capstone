import React from 'react';

const Profile = ({ handleLogout }) => {
  const username = localStorage.getItem('username');

  return (
    <div className="d-flex vh-100 justify-content-center align-items-center">
      <div className="card shadow-lg p-5" style={{ width: '30rem' }}>
        <h2 className="text-center mb-4">Profile</h2>
        <p><strong>Username:</strong> {username}</p>
        <button className="btn btn-danger" onClick={handleLogout}>
          Logout
        </button>
      </div>
    </div>
  );
};

export default Profile;
