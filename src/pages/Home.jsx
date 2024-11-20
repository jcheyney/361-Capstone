// src/pages/Home.jsx
import React from 'react';

const App = () => {
  return (
    <>
      {/* Hero Section */}
      <section className="bg-danger text-light pt-5 text-center">
        <div className="container">
          <div className="d-sm-flex">
            <div className="ms-auto">
              <h1>For all your style needs</h1>
              <h4>
                We have anything you could ever want for tops to bottoms. We even have dresses and jackets for more
                special occasions.
              </h4>
              <button className="btn btn-light text-danger btn-lg">Shop Now</button>
            </div>
            <img
              className="img-fluid w-40 ms-auto d-none d-md-block"
              src="https://imgs.search.brave.com/Q8y0CN0eDedpS62Z96-leieVbRupZhnJk5CZ1AOz0NM/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvNTM2/NTUyMjkxL3Bob3Rv/L21vZGVybi1mYXNo/aW9uLXNob3Atc3Rv/cmVmcm9udC1hbmQt/c2hvd2Nhc2UuanBn/P3M9NjEyeDYxMiZ3/PTAmaz0yMCZjPXh1/c3pzNUJDbDlaQzFm/cGprM0x4VVdqdEJs/SElkQWpMZjluMnRm/elc0MEE9"
              alt="showcase picture"
            />
          </div>
        </div>
      </section>

      {/* Products Section */}
      <section>
        <div className="container py-3">
          <div className="row">
            <div className="col-md">
              <div className="card" style={{ width: '18rem' }}>
                <img
                  src="https://imgs.search.brave.com/PniBaKE1ZNLggZz5Mk6kpvGE6NaA441N2icqOPnssxM/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9ib25v/Ym9zLXByb2QtczMu/aW1naXgubmV0L3By/b2R1Y3RzLzMyNTE3/MC9vcmlnaW5hbC9K/QUNLRVRfRlVMTC1a/SVAtSkFDS0VUX0JP/VDExMzQ0TjExMTZC/XzNfY2F0ZWdvcnku/anBnPzE2OTQ4MTAx/MzY9JmF1dG89Y29t/cHJlc3MsZm9ybWF0/JmZpdD1jbGlwJmNz/PXNyZ2Imdz0xOTIw/JmZtPXBqcGc"
                  className="card-img-top"
                  alt="Men's Jacket"
                />
                <div className="card-body">
                  <h5 className="card-title">Men's Jacket</h5>
                  <p className="card-text">
                    Some quick example text to build on the card title and make up the bulk of the card's content.
                  </p>
                  <a href="#" className="btn btn-danger">
                    Buy Now
                  </a>
                </div>
              </div>
            </div>

            {/* Duplicate Product Cards */}
            {[...Array(5)].map((_, index) => (
              <div className="col-md" key={index}>
                <div className="card" style={{ width: '18rem' }}>
                  <img
                    src="https://imgs.search.brave.com/5t5Go08DF4AbtG58WTJR_wOTroQfNkAuWc4h5XIPeRc/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pLnBp/bmltZy5jb20vb3Jp/Z2luYWxzLzg1LzNm/Lzk2Lzg1M2Y5NjRj/OGVmZTYxNmY5NDRm/MmZmMGRkYWRlNWIy/LmpwZw"
                    className="card-img-top"
                    alt="Card title"
                  />
                  <div className="card-body">
                    <h5 className="card-title">Card title</h5>
                    <p className="card-text">
                      Some quick example text to build on the card title and make up the bulk of the card's content.
                    </p>
                    <a href="#" className="btn btn-danger">
                      Buy Now
                    </a>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>
    </>
  );
};

export default App;
