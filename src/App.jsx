// src/App.jsx
import React, { useState } from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import Home from './pages/Home';
import About from './pages/About';
import Cart from './pages/Cart';
import Checkout from './pages/Checkout';


const App = () => {
  const [page, setPage] = useState('home');

  const renderPage = () => {
    switch (page) {
      case 'about':
        return <About />;
      case 'cart':
        return <Cart setPage={setPage} />;
      case 'checkout':
        return <Checkout />
      case 'home':
      default:
        return <Home />;
    }
  };

  return (
    <div>
      <Header setPage={setPage} />
      <main>{renderPage()}</main>
      <Footer />
    </div>
  );
};

export default App;
