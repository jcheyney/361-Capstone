// src/components/Header.jsx
import React from 'react';

const Header = ({ setPage }) => {
  return (
    <nav class="navbar navbar-expand-md bg-danger navber-danger py-3">

        <div class="container">
        <a href="#" class="navbar-brand text-light">College Clutter</a>
    <button 
        type="button"
        class="btn navbar-toggler text-light "  
        data-bs-toggle="collapse" 
        data-bs-target="#navmenu"
        >
    <span class="navbar-toggler-icon"></span>
    Clothing Options

    </button>
        <div class="collapse navbar-collapse" id="navmenu">
            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <a href="#" class="nav-link text-light">Tops</a>
                </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-light">Bottoms</a>
                </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-light">Dresses</a>
                </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-light">Jackets/Hoodies</a>
                </li>
            </ul>
        </div>
    </div>
    </nav>
  );
};

export default Header;
