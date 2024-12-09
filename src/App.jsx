import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import Home from './pages/Home';
import Cart from './pages/Cart';
import Checkout from './pages/Checkout';
import Tops from './pages/Tops';
import Bottoms from './pages/Bottoms';
import Jackets from './pages/Jackets';
import Dresses from './pages/Dresses';
import Login from './pages/Login';
import SignUp from './pages/SignUp';
import Profile from './pages/Profile';

const App = () => {
  const [page, setPage] = useState('home');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    const storedLoginStatus = localStorage.getItem('isLoggedIn');
    if (storedLoginStatus === 'true') {
      setIsLoggedIn(true);
    }
  }, []);

  const handleLoginSuccess = (username) => {
    setIsLoggedIn(true);
    localStorage.setItem('isLoggedIn', 'true');
    localStorage.setItem('username', username);
    setPage('home');
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    localStorage.removeItem('isLoggedIn');
    localStorage.removeItem('username');
    setPage('home');
  };

  const renderPage = () => {
    switch (page) {
      case 'cart':
        return <Cart />;
      case 'checkout':
        return <Checkout />;
      case 'Tops':
        return <Tops />;
      case 'Bottoms':
        return <Bottoms />;
      case 'Jackets':
        return <Jackets />;
      case 'Dresses':
        return <Dresses />;
      case 'Login':
        return <Login setPage={setPage} onLoginSuccess={handleLoginSuccess} />;
      case 'SignUp':
        return <SignUp setPage={setPage} />;
      case 'profile':
        return <Profile handleLogout={handleLogout} />;
      case 'home':
      default:
        return <Home />;
    }
  };

  return (
    <div>
      <Header setPage={setPage} isLoggedIn={isLoggedIn} />
      <main>{renderPage()}</main>
      <Footer />
    </div>
  );
};

export default App;
