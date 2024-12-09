import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const Cart = ({ setPage }) => {
  const [cartItems, setCartItems] = useState([
    { id: 1, name: 'T-Shirt', price: 19.99, quantity: 2, image: 'https://via.placeholder.com/150' },
    { id: 2, name: 'Jeans', price: 49.99, quantity: 1, image: 'https://via.placeholder.com/150' },
    { id: 3, name: 'Jacket', price: 89.99, quantity: 1, image: 'https://via.placeholder.com/150' }
  ]);

  const updateQuantity = (id, delta) => {
    setCartItems(prevItems =>
      prevItems.map(item =>
        item.id === id ? { ...item, quantity: Math.max(1, item.quantity + delta) } : item
      )
    );
  };

  const getTotalPrice = () => {
    return cartItems.reduce((total, item) => total + item.price * item.quantity, 0).toFixed(2);
  };

  const removeItem = id => {
    setCartItems(prevItems => prevItems.filter(item => item.id !== id));
  };

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Shopping Cart</h1>
      {cartItems.length === 0 ? (
        <p className="text-center">Your cart is empty.</p>
      ) : (
        <div className="cart-items">
          {cartItems.map(item => (
            <div key={item.id} className="d-flex align-items-center mb-3 p-3 border rounded">
              <img
                src={item.image}
                alt={item.name}
                style={{ width: '80px', height: '80px', objectFit: 'cover', borderRadius: '8px' }}
              />
              <div className="ms-3 flex-grow-1">
                <h5 className="mb-1">{item.name}</h5>
                <p className="mb-0 text-muted">Price: ${item.price.toFixed(2)}</p>
                <div className="d-flex align-items-center mt-2">
                  <button
                    className="btn btn-sm btn-outline-secondary"
                    onClick={() => updateQuantity(item.id, -1)}
                  >
                    -
                  </button>
                  <span className="mx-2">{item.quantity}</span>
                  <button
                    className="btn btn-sm btn-outline-secondary"
                    onClick={() => updateQuantity(item.id, 1)}
                  >
                    +
                  </button>
                </div>
              </div>
              <div>
                <p className="mb-0 fw-bold">${(item.price * item.quantity).toFixed(2)}</p>
                <button
                  className="btn btn-sm btn-danger mt-2"
                  onClick={() => removeItem(item.id)}
                >
                  Remove
                </button>
              </div>
            </div>
          ))}
          <div className="d-flex justify-content-between align-items-center border-top pt-3 mt-3">
            <h4 className="mb-0">Total:</h4>
            <h4 className="mb-0">${getTotalPrice()}</h4>
          </div>
          <div className="text-end mt-3">
            <button
              className="btn btn-sm btn-primary"
              onClick={() => setPage('checkout')}
            >
              Proceed to Checkout
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Cart;