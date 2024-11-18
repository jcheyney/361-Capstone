// src/pages/Home.jsx
import React from 'react';

const Home = () => {
  return (
    <div>
      <section className="bg-danger text-light pt-5 text-center">
        <div className="container">
          <div className="d-sm-flex">
            <div className="ms-auto">
              <h1>For all your style needs</h1>
              <h4>We have anything you could ever want for tops to bottoms. We even have dresses and Jackets for more special occasions.</h4>
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
      <div className="container pt-5">
        <form className="d-flex">
          <input className="form-control me-2 bg-danger text-light" type="search" placeholder="Search" aria-label="Search" />
          <button className="btn btn-outline-danger" type="submit">Search</button>
        </form>
      </div>
      <section>
        <div className="container py-3">
          <div className="row">
            <div className="col-md">
              <div className="card">
                <img 
                  src="https://imgs.search.brave.com/PniBaKE1ZNLggZz5Mk6kpvGE6NaA441N2icqOPnssxM/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9ib25v/Ym9zLXByb2QtczMu/aW1naXgubmV0L3By/b2R1Y3RzLzMyNTE3/MC9vcmlnaW5hbC9K/QUNLRVRfRlVMTC1a/SVAtSkFDS0VUX0JP/VDExMzQ0TjExMTZC/XzNfY2F0ZWdvcnku/anBnPzE2OTQ4MTAx/MzY9JmF1dG89Y29t/cHJlc3MsZm9ybWF0/JmZpdD1jbGlwJmNz/PXNyZ2Imdz0xOTIw/JmZtPXBqcGc" 
                  className="card-img-top" 
                  alt="Men's Jacket" 
                />
                <div className="card-body">
                  <h5 className="card-title">Mens Jacket</h5>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                  <a href="#" className="btn btn-danger">Buy Now</a>
                </div>
              </div>
            </div>
            {/* Repeat similar structure for other cards */}
          </div>
        </div>
      </section>
    </div>
  );
};

export default Home;
