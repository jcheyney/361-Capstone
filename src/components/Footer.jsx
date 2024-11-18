// src/components/Footer.jsx
import React from 'react';

const Footer = () => {
  return (
    <footer className="bg-dark text-light text-center py-3 mt-4">
      <p className="mb-0">&copy; 2024 Clothing Shop. All Rights Reserved.</p>
      <small>Follow us on 
        <a href="#" className="text-light ms-2">Facebook</a>, 
        <a href="#" className="text-light ms-2">Instagram</a>, 
        and <a href="#" className="text-light ms-2">Twitter</a>.
      </small>
    </footer>
  );
};

export default Footer;
