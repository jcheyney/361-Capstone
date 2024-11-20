
SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS cartItems;
DROP TABLE IF EXISTS cart;
DROP TABLE IF EXISTS userOrder;
DROP TABLE IF EXISTS item;
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS sale;
DROP TABLE IF EXISTS guest;
DROP TABLE IF EXISTS payment;
DROP TABLE IF EXISTS customer;
DROP TABLE IF EXISTS userAddress;


SET FOREIGN_KEY_CHECKS = 1;


CREATE TABLE userAddress (
    userAddressID INT NOT NULL PRIMARY KEY,
    country VARCHAR(255) NOT NULL, 
    userState VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL, 
    zipcode VARCHAR(10) NOT NULL, 
    street VARCHAR(255) NOT NULL
);

CREATE TABLE category (
    categoryID INT NOT NULL PRIMARY KEY,
    categoryName VARCHAR(255) NOT NULL
);

CREATE TABLE sale (
    saleID INT NOT NULL PRIMARY KEY,
    dateOfSale DATETIME NOT NULL,
    saleType VARCHAR(50) NOT NULL, 
    saleAmount INT NOT NULL
);

CREATE TABLE payment (
    paymentID INT NOT NULL PRIMARY KEY, 
    cardNumber VARCHAR(18) NOT NULL UNIQUE, 
    expirationDate DATE NOT NULL,
    cvv INT NOT NULL, 
    addressID INT NOT NULL,
    customerID INT,
    FOREIGN KEY (addressID) REFERENCES userAddress(userAddressID)
);

CREATE TABLE customer (
    customerID INT NOT NULL PRIMARY KEY,
    userName VARCHAR(255) NOT NULL,
    addressID INT NOT NULL,
    paymentID INT,
    FOREIGN KEY (addressID) REFERENCES userAddress(userAddressID),
    FOREIGN KEY (paymentID) REFERENCES payment(paymentID)
);

ALTER TABLE payment ADD FOREIGN KEY (customerID) REFERENCES customer(customerID);

CREATE TABLE guest (
    guestID INT NOT NULL,
    paymentID INT NOT NULL,
    FOREIGN KEY (paymentID) REFERENCES payment(paymentID)
);

CREATE TABLE item (
    itemID INT NOT NULL PRIMARY KEY,
    saleID INT NOT NULL,
    itemWeight INT NOT NULL,
    dimensions VARCHAR(25) NOT NULL,
    manufacturer VARCHAR(255) NOT NULL, 
    itemDescription VARCHAR(250) NOT NULL, 
    quantity INT NOT NULL,
    imageURL LONGBLOB,
    sku VARCHAR(225) NOT NULL UNIQUE,
    rating FLOAT NOT NULL, 
    itemType INT,
    FOREIGN KEY (itemType) REFERENCES category(categoryID),
    FOREIGN KEY (saleID) REFERENCES sale(saleID)
);

CREATE TABLE userOrder (
    userOrderID INT NOT NULL PRIMARY KEY,
    cartID INT,
    dateShipped DATETIME
);

CREATE TABLE cart (
    cartID INT NOT NULL PRIMARY KEY,
    customerID INT NOT NULL, 
    totalCost INT NOT NULL, 
    orderID INT,
    FOREIGN KEY (customerID) REFERENCES customer(customerID),
    FOREIGN KEY (orderID) REFERENCES userOrder(userOrderID)
);

CREATE TABLE cartItems (
    cartID INT NOT NULL,
    itemID INT NOT NULL,
    itemCount INT NOT NULL,
    itemPrice INT NOT NULL,
    PRIMARY KEY (cartID, itemID),
    FOREIGN KEY (cartID) REFERENCES cart(cartID),
    FOREIGN KEY (itemID) REFERENCES item(itemID)
);

ALTER TABLE userOrder ADD FOREIGN KEY (cartID) REFERENCES cart(cartID);
