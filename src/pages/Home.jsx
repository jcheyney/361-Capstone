// src/pages/Home.jsx
import React from 'react';

const App = () => {
  const products = [
    {
      title: "Men's Jacket",
      imgSrc: 'https://via.placeholder.com/300x250?text=Men%27s+Jacket',
    },
    {
      title: "Women's Dress",
      imgSrc: 'https://via.placeholder.com/300x250?text=Women%27s+Dress',
    },
    {
      title: 'Casual Shirt',
      imgSrc: 'https://via.placeholder.com/300x250?text=Casual+Shirt',
    },
    {
      title: 'Jeans',
      imgSrc: 'https://via.placeholder.com/300x250?text=Jeans',
    },
    {
      title: 'Sneakers',
      imgSrc: 'https://via.placeholder.com/300x250?text=Sneakers',
    },
    {
      title: 'Handbag',
      imgSrc: 'https://via.placeholder.com/300x250?text=Handbag',
    },
  ];

  return (
    <>
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

      <section>
        <div className="container py-3">
          <div className="row row-cols-1 row-cols-md-3 g-4">
            {products.map((product, index) => (
              <div className="col" key={index}>
                <div className="card h-100">
                  <img
                    src={product.imgSrc}
                    className="card-img-top"
                    alt={product.title}
                    style={{ objectFit: 'cover', height: '250px' }}
                  />
                  <div className="card-body d-flex flex-column">
                    <h5 className="card-title">{product.title}</h5>
                    <p className="card-text">
                      Some quick example text to build on the card title and make up the bulk of the card's content.
                    </p>
                    <div className="mt-auto">
                      <a href="#" className="btn btn-danger">
                        Buy Now
                      </a>
                    </div>
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
