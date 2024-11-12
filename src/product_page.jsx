import { useState } from 'react';

function ProductPage() {
  const [quantity, setQuantity] = useState(1);
  const [selectedSize, setSelectedSize] = useState('Medium');

  // product data
  const product = {
    name: 'Vantage Nylon Ripstop Track Jacket',
    category: 'Jacket',
    description: 'Designed for a loose, relaxed fit—size down if you prefer a closer fit.',
    material: 'Lightweight, swishy fabric, 100% Nylon',
    sizes: ['Small', 'Medium', 'Large', 'Extra Large'],
    weight: '16 ounces',
    price: 59.99,
    imageUrl: 'https://via.placeholder.com/500',
  };

  // related products data
  const relatedProducts = [
    { id: 1, name: 'Lightweight Windbreaker', imageUrl: 'https://via.placeholder.com/300' },
    { id: 2, name: 'Waterproof Hiking Jacket', imageUrl: 'https://via.placeholder.com/300' },
    { id: 3, name: 'Insulated Winter Coat', imageUrl: 'https://via.placeholder.com/300' },
  ];

  const handleQuantityChange = (event) => {
    const value = Math.max(1, parseInt(event.target.value) || 1);
    setQuantity(value);
  };

  const handleSizeChange = (event) => {
    setSelectedSize(event.target.value);
  };

//   const handleRelatedProductClick = (productId) => {
//     // when a related product is clicked
//   };

  return (
    

    <div className="container mt-5">
      <div className="row">
        <div className="col-md-6 order-md-1 order-2">
          <img src={product.imageUrl} alt={product.name} className="img-fluid rounded" />
        </div>
        <div className="col-md-6 order-md-2 order-1">
          <h2 className="display-4 fw-bold">{product.name}</h2>
          <p className="text-muted">Category: {product.category}</p>
          <p>{product.description}</p>
          <p><strong>Material:</strong> {product.material}</p>
          <p><strong>Weight:</strong> {product.weight}</p>
          <p><strong>Price:</strong> ${product.price.toFixed(2)}</p>

          <div className="mt-3">
            <label htmlFor="size" className="form-label">Size</label>
            <select
              id="size"
              className="form-select"
              value={selectedSize}
              onChange={handleSizeChange}
            >
              {product.sizes.map((size) => (
                <option key={size} value={size}>{size}</option>
              ))}
            </select>
          </div>

          <div className="mt-3">
            <label htmlFor="quantity" className="form-label">Quantity</label>
            <input
              type="number"
              id="quantity"
              className="form-control"
              value={quantity}
              onChange={handleQuantityChange}
              min="1"
            />
          </div>

          <button className="btn btn-primary mt-3">
            Add {quantity} {selectedSize} size to Cart
          </button>
        </div>
      </div>

      { /* Related Products Section */ }
      <div className="mt-5">
        <h2>Related Products</h2>
        <div className="row">
          {relatedProducts.map((relatedProduct) => (
            <div className="col-6 col-md-4 mb-4" key={relatedProduct.id}>
              <div className="card">
                <img
                  src={relatedProduct.imageUrl}
                  alt={relatedProduct.name}
                  className="card-img-top"
                  style={{ cursor: 'pointer' }}
                //   onClick={() => 
                />
                <div className="card-body">
                  <h5 className="card-title text-center">{relatedProduct.name}</h5>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default ProductPage;
