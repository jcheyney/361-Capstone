// src/pages/Cart.jsx
import React, { useState } from 'react';

const Cart = () => {
  // 模拟的购物车数据
  const [cartItems, setCartItems] = useState([
    { id: 1, name: 'T-Shirt', price: 19.99, quantity: 2, image: 'https://via.placeholder.com/150' },
    { id: 2, name: 'Jeans', price: 49.99, quantity: 1, image: 'https://via.placeholder.com/150' },
    { id: 3, name: 'Jacket', price: 89.99, quantity: 1, image: 'https://via.placeholder.com/150' }
  ]);

  // 更新商品数量
  const updateQuantity = (id, delta) => {
    setCartItems(prevItems =>
      prevItems.map(item =>
        item.id === id ? { ...item, quantity: Math.max(1, item.quantity + delta) } : item
      )
    );
  };

  // 计算总价
  const getTotalPrice = () => {
    return cartItems.reduce((total, item) => total + item.price * item.quantity, 0).toFixed(2);
  };

  // 移除商品
  const removeItem = id => {
    setCartItems(prevItems => prevItems.filter(item => item.id !== id));
  };

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Your Shopping Cart</h1>
      {cartItems.length === 0 ? (
        <p>Your cart is empty.</p>
      ) : (
        <div className="table-responsive">
          <table className="table align-middle">
            <thead>
              <tr>
                <th scope="col">Product</th>
                <th scope="col">Name</th>
                <th scope="col">Price</th>
                <th scope="col">Quantity</th>
                <th scope="col">Subtotal</th>
                <th scope="col">Actions</th>
              </tr>
            </thead>
            <tbody>
              {cartItems.map(item => (
                <tr key={item.id}>
                  <td>
                    <img src={item.image} alt={item.name} className="img-thumbnail" style={{ width: '80px' }} />
                  </td>
                  <td>{item.name}</td>
                  <td>${item.price.toFixed(2)}</td>
                  <td>
                    <div className="input-group" style={{ maxWidth: '120px' }}>
                      <button
                        className="btn btn-outline-secondary"
                        onClick={() => updateQuantity(item.id, -1)}
                      >
                        -
                      </button>
                      <input
                        type="text"
                        className="form-control text-center"
                        value={item.quantity}
                        readOnly
                      />
                      <button
                        className="btn btn-outline-secondary"
                        onClick={() => updateQuantity(item.id, 1)}
                      >
                        +
                      </button>
                    </div>
                  </td>
                  <td>${(item.price * item.quantity).toFixed(2)}</td>
                  <td>
                    <button className="btn btn-danger" onClick={() => removeItem(item.id)}>
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="d-flex justify-content-end mt-3">
            <h4>Total: ${getTotalPrice()}</h4>
          </div>
        </div>
      )}
    </div>
  );
};

export default Cart;
