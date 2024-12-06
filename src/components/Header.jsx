// src/components/Header.jsx
import React from 'react';

const Header = ({ setPage }) => {
  return (
    <><nav class="navbar navbar-expand-md bg-danger navbar-danger py-3">
      <div class="container">
        <a href="Home.jsx" class="navbar-brand text-light">College Clutter</a>
        <button
          type="button"
          class="navbar-toggler"
          data-bs-toggle="collapse"
          data-bs-target="#navmenu"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navmenu">
          <ul class="navbar-nav ms-auto">
            <li class="nav-item">
              <button href="Tops.jsx" class="nav-link text-light" onClick={() => setPage('top')}>Tops</button>
              
            </li>
            <li class="nav-item">
              <button href="Bottoms.jsx" class="nav-link text-light" onClick={() => setPage('bottom')}>Bottoms</button>
            </li>
            <li class="nav-item">
              <button href="Dresses.jsx" class="nav-link text-light" onClick={() => setPage('dress')}>Dresses</button>
            </li>
            <li class="nav-item">
              <button href="Jackets.jsx" class="nav-link text-light" onClick={() => setPage('jacket')}>Jackets/Hoodies</button>
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
    </>
   );
};

export default Header;
