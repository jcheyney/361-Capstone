// src/App.jsx
import React, { useState } from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import Home from './pages/Home';
import About from './pages/About';
import Cart from './pages/Cart';
import Top from './pages/Tops';
import Checkout from './pages/Checkout';
import Jacket from './pages/Jackets';
import Bottom from './pages/Bottoms';
import Dress from './pages/Dresses';
import Login from './pages/Login';
import SignUp from './pages/SignUp';


const App = () => {
  const [page, setPage] = useState('home');

  const renderPage = () => {
    switch (page) {
      case 'about':
        return <About />;
      case 'cart':
        return <Cart setPage={setPage}/>;
      case 'top':
        return<Top />;  
      case 'checkout':
        return<Checkout />
      case 'jacket':
        return<Jacket />
      case 'bottom':
          return<Bottom />
      case 'dress':
        return<Dress />
      case 'login':
        return<Login setPage={setPage}/>
      case 'signup':
        return<SignUp setPage={setPage}/>
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
