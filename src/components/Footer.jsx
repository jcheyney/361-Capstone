// src/components/Footer.jsx
import React from 'react';
import LOGO from '../assets/Clutter_Red.png'

const Footer = () => {
  return (
    <footer className="bg-dark text-light text-center py-3 mt-4">
      <div class="container mt-4">
      <div class="row text-center">
                <div class="col-md-3">
                    <i class="fas fa-info-circle fa-2x mb-2"></i>
                    <p>About Us</p>
                    <a href="https://github.com/jcheyney/361-Capstone" class="text-decoration-none text-white">Learn More</a>
                </div>
                <div class="col-md-3">
                    <i class="fas fa-headset fa-2x mb-2"></i>
                    <p>Customer Service</p>
                    <a href="https://github.com/jcheyney/361-Capstone/issues" class="text-decoration-none text-white">Contact Us?</a>
                </div>
                <div class="col-md-3">
                    <i class="fas fa-question-circle fa-2x mb-2"></i>
                    <p>FAQs</p>
                    <a href="#" class="text-decoration-none text-white">You have No Question</a>
                </div>
                <div class="col-md-3">
                    <i class="fas fa-share-alt fa-2x mb-2"></i>
                    <p>Follow Us</p>
                    <a href="https://github.com/jcheyney/361-Capstone" class="text-white"><i class="fab fa-github fa-2x"></i></a>
                </div>
            </div>


        < br />
        <img src={LOGO} alt="LOGO" />
        <div>
          <p className="mb-0">&copy; 2024 College Clutter. All Rights Reserved.</p>
        </div>
      </div>




    </footer>
  );
};

export default Footer;
