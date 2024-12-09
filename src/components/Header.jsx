import React from 'react';

const Header = ({ setPage, isLoggedIn }) => {
  return (
    <nav className="navbar navbar-expand-md bg-danger navbar-danger py-3">
      <div className="container">
        <a href="#" className="navbar-brand text-light" onClick={() => setPage('home')}>
          College Clutter
        </a>
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
              <a href="#" className="nav-link text-light" onClick={() => setPage('Top')}>
                Tops
              </a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light" onClick={() => setPage('Bottom')}>
                Bottoms
              </a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light" onClick={() => setPage('Dress')}>
                Dresses
              </a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light" onClick={() => setPage('Jacket')}>
                Jackets/Hoodies
              </a>
            </li>
            <li className="nav-item">
              <a href="#" className="nav-link text-light" onClick={() => setPage('cart')}>
                <i className="fa-solid fa-cart-shopping fa-2x text-white"></i>
              </a>
            </li>
            <li className="nav-item">
              <a
                href="#"
                className="nav-link text-light"
                onClick={() => setPage(isLoggedIn ? 'profile' : 'Login')}
              >
                <i className="fa-solid fa-user fa-2x text-white"></i>
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Header;
