import React from 'react';

function Jacket() {
  return (
    <>
      {/* Header */}
      <header className="bg-danger text-white text-center py-4">
        <div className="container">
          <h1>Jacket Catalog</h1>
          <p>Find everything you need from our collection</p>
        </div>
      </header>

      {/* Main Content */}
      <main className="container my-5">
        <div className="row">
          {/* Sidebar Filters */}
          <aside className="col-md-3">
            <h5>Filters</h5>
            <hr />
            <div className="mb-3">
              <h6>Category</h6>
              <div className="form-check">
                <input className="form-check-input" type="checkbox" id="men" />
                <label className="form-check-label" htmlFor="men">
                  Men's Wear
                </label>
              </div>
              <div className="form-check">
                <input className="form-check-input" type="checkbox" id="women" />
                <label className="form-check-label" htmlFor="women">
                  Women's Wear
                </label>
              </div>
              <div className="form-check">
                <input className="form-check-input" type="checkbox" id="kids" />
                <label className="form-check-label" htmlFor="kids">
                  Kids' Wear
                </label>
              </div>
            </div>
            <div className="mb-3">
              <h6>Price</h6>
              <input
                type="range"
                className="form-range"
                min="0"
                max="500"
                step="10"
              />
            </div>
            <div className="mb-3">
              <h6>Rating</h6>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  name="rating"
                  id="4stars"
                />
                <label className="form-check-label" htmlFor="4stars">
                  4 stars & up
                </label>
              </div>
              <div className="form-check">
                <input
                  className="form-check-input"
                  type="radio"
                  name="rating"
                  id="3stars"
                />
                <label className="form-check-label" htmlFor="3stars">
                  3 stars & up
                </label>
              </div>
            </div>
            <button className="btn btn-danger w-100">Apply Filters</button>
          </aside>

          {/* Product Grid */}
          <section className="col-md-9">
          <div className="row g-4">
              {/* Row 1 */}
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://imgs.search.brave.com/egZx8sp14BHG8-MR9GCnO_eOIZR_AE6-q2FSfPvo8No/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTQ3/NDMzNzU5NC9waG90/by9tZW5zLXN1ZWRl/LWphY2tldC5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9bVd2/MC1jOHJaYUdjUVJU/TVB6QXBSalg3YzA3/UlhSekhGdlM1dXVm/ODQxZz0"
                    className="card-img-top"
                    alt="Product 1"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Men's Jacket</h5>
                    <p className="card-text">$49.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★★☆</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://via.placeholder.com/300x200"
                    className="card-img-top"
                    alt="Product 2"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Women's Dress</h5>
                    <p className="card-text">$39.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★★★</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://via.placeholder.com/300x200"
                    className="card-img-top"
                    alt="Product 3"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Kid's Hoodie</h5>
                    <p className="card-text">$29.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★☆☆</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>

              {/* Row 2 */}
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://via.placeholder.com/300x200"
                    className="card-img-top"
                    alt="Product 4"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Men's Shirt</h5>
                    <p className="card-text">$24.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★★☆</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://via.placeholder.com/300x200"
                    className="card-img-top"
                    alt="Product 5"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Women's Blouse</h5>
                    <p className="card-text">$34.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★★☆</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-4">
                <div className="card h-100">
                  <img
                    src="https://via.placeholder.com/300x200"
                    className="card-img-top"
                    alt="Product 6"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Kid's T-shirt</h5>
                    <p className="card-text">$19.99</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <span className="text-danger">★★★☆☆</span>
                      <a href="#" className="btn btn-sm btn-danger">
                        Add to Cart
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            {/* Pagination */}
            <nav className="mt-4">
              <ul className="pagination justify-content-center">
                <li className="page-item">
                  <a className="page-link" href="#">
                    Previous
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    1
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    2
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    3
                  </a>
                </li>
                <li className="page-item">
                  <a className="page-link" href="#">
                    Next
                  </a>
                </li>
              </ul>
            </nav>
          </section>
        </div>
      </main>

      
    </>
  );
}

export default Jacket;
