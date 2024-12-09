// src/pages/Checkout.jsx
import React, { useState } from 'react';

const Checkout = () => {
  const [cartItems] = useState([
    { id: 1, name: 'T-Shirt', price: 19.99, quantity: 2, image: 'https://via.placeholder.com/150' },
    { id: 2, name: 'Jeans', price: 49.99, quantity: 1, image: 'https://via.placeholder.com/150' },
    { id: 3, name: 'Jacket', price: 89.99, quantity: 1, image: 'https://via.placeholder.com/150' }
  ]);

  const [address, setAddress] = useState({
    fullName: '',
    street: '',
    city: '',
    state: '',
    zipCode: '',
    phone: ''
  });

  const [paymentMethod, setPaymentMethod] = useState('credit-card');
  const [couponCode, setCouponCode] = useState('');

  const handleAddressChange = (e) => {
    const { name, value } = e.target;
    setAddress({ ...address, [name]: value });
  };

  const handleApplyCoupon = () => {
    alert(`Coupon "${couponCode}" applied!`);
  };

  const getTotalPrice = () => {
    return cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
  };

  const calculateOrderTotal = () => {
    const shipping = 5.99;
    const tax = getTotalPrice() * 0.07;
    return (getTotalPrice() + shipping + tax).toFixed(2);
  };

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Checkout</h1>
      <div className="row">
        {/* Left Section */}
        <div className="col-md-8">
          {/* Shipping Address */}
          <div className="mb-4">
            <h4>Shipping Address</h4>
            <div className="border rounded p-3">
              <div className="mb-3">
                <label className="form-label">Full Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="fullName"
                  value={address.fullName}
                  onChange={handleAddressChange}
                  required
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Street</label>
                <input
                  type="text"
                  className="form-control"
                  name="street"
                  value={address.street}
                  onChange={handleAddressChange}
                  required
                />
              </div>
              <div className="mb-3">
                <label className="form-label">City</label>
                <input
                  type="text"
                  className="form-control"
                  name="city"
                  value={address.city}
                  onChange={handleAddressChange}
                  required
                />
              </div>
              <div className="row">
                <div className="col-md-6 mb-3">
                  <label className="form-label">State</label>
                  <input
                    type="text"
                    className="form-control"
                    name="state"
                    value={address.state}
                    onChange={handleAddressChange}
                    required
                  />
                </div>
                <div className="col-md-6 mb-3">
                  <label className="form-label">Zip Code</label>
                  <input
                    type="text"
                    className="form-control"
                    name="zipCode"
                    value={address.zipCode}
                    onChange={handleAddressChange}
                    required
                  />
                </div>
              </div>
              <div className="mb-3">
                <label className="form-label">Phone Number</label>
                <input
                  type="tel"
                  className="form-control"
                  name="phone"
                  value={address.phone}
                  onChange={handleAddressChange}
                  required
                />
              </div>
            </div>
          </div>

          {/* Order Items */}
          <div className="mb-4">
            <h4>Order Items</h4>
            <div className="border rounded p-3">
              {cartItems.map((item) => (
                <div key={item.id} className="d-flex align-items-center mb-3">
                  <img
                    src={item.image}
                    alt={item.name}
                    style={{ width: '80px', height: '80px', objectFit: 'cover', borderRadius: '8px' }}
                  />
                  <div className="ms-3 flex-grow-1">
                    <h5 className="mb-0">{item.name}</h5>
                    <p className="mb-0 text-muted">
                      Quantity: {item.quantity} | Price: ${(item.price * item.quantity).toFixed(2)}
                    </p>
                  </div>
                </div>
              ))}
            </div>
          </div>

          {/* Payment Method */}
          <div className="mb-4">
            <h4>Payment Method</h4>
            <div className="border rounded p-3">
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  name="paymentMethod"
                  id="credit-card"
                  value="credit-card"
                  checked={paymentMethod === 'credit-card'}
                  onChange={(e) => setPaymentMethod(e.target.value)}
                />
                <label className="form-check-label" htmlFor="credit-card">
                  Credit Card
                </label>
              </div>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  name="paymentMethod"
                  id="paypal"
                  value="paypal"
                  onChange={(e) => setPaymentMethod(e.target.value)}
                />
                <label className="form-check-label" htmlFor="paypal">
                  PayPal
                </label>
              </div>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  name="paymentMethod"
                  id="cash-on-delivery"
                  value="cash-on-delivery"
                  onChange={(e) => setPaymentMethod(e.target.value)}
                />
                <label className="form-check-label" htmlFor="cash-on-delivery">
                  Cash on Delivery
                </label>
              </div>
            </div>
          </div>
        </div>

        {/* Right Section */}
        <div className="col-md-4">
          <h4>Order Summary</h4>
          <div className="border rounded p-3">
            <div className="mb-3">
              <label className="form-label">Enter Coupon Code</label>
              <div className="d-flex">
                <input
                  type="text"
                  className="form-control me-2"
                  value={couponCode}
                  onChange={(e) => setCouponCode(e.target.value)}
                />
                <button className="btn btn-primary" onClick={handleApplyCoupon}>
                  Apply
                </button>
              </div>
            </div>
            <div className="d-flex justify-content-between">
              <span>Subtotal:</span>
              <span>${getTotalPrice().toFixed(2)}</span>
            </div>
            <div className="d-flex justify-content-between">
              <span>Shipping:</span>
              <span>$5.99</span>
            </div>
            <div className="d-flex justify-content-between">
              <span>Sales Tax:</span>
              <span>${(getTotalPrice() * 0.07).toFixed(2)}</span>
            </div>
            <hr />
            <div className="d-flex justify-content-between fw-bold">
              <span>Total:</span>
              <span>${calculateOrderTotal()}</span>
            </div>
          </div>
          <div className="mt-3 text-end">
            <button className="btn btn-success btn-lg">Place Order</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Checkout;
