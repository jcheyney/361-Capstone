import React from 'react';

const Header = ({ setPage }) => {
  return (
    <nav className="navbar navbar-expand-md bg-danger navbar-danger py-3">
      <div className="container">
        <a href="#" className="navbar-brand text-light" onClick={() => setPage('')}>College Clutter</a>
        <button
          type="button"
          className="navbar-toggler"
          data-bs-toggle="collapse"
          data-bs-target="#navmenu"
          
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navmenu">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <a href="#" className="nav-link text-light"                onClick={() => setPage('Top')}
              >Tops</a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light"                onClick={() => setPage('Bottom')}
              >Bottoms</a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light "                onClick={() => setPage('Dress')}
              >Dresses</a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light"                 onClick={() => setPage('Jacket')}
              >Jackets/Hoodies</a>
            </li>
            <li className="nav-item">
              <button
                className="btn btn-light text-danger"
                onClick={() => setPage('cart')}
              >
                Cart
              </button>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Header;
