DROP TABLE IF EXISTS guest;
DROP TABLE IF EXISTS userAddress;
DROP TABLE IF EXISTS payment; 
DROP TABLE IF EXISTS customer; 
DROP TABLE IF EXISTS item; 
DROP TABLE IF EXISTS category;
DROP TABLE IF EXISTS sale; 
DROP TABLE IF EXISTS cart; 
DROP TABLE IF EXISTS userOrder;

CREATE TABLE guest(
    guestID INT NOT NULL,
    paymentID INT NOT NULL,
    FOREIGN KEY (paymentID) REFERENCES Payment (paymentID)
);

CREATE TABLE userAddress (
    userAddressID INT NOT NULL PRIMARY KEY,
    country VARCHAR(255) NOT NULL, 
    userState VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL, 
    zipcode VARCHAR(10) NOT NULL, 
    street VARCHAR(255) NOT NULL
);

CREATE TABLE customer (
    customerID INT NOT NULL PRIMARY KEY,
    userName VARCHAR(255) NOT NULL,
    addressID INT NOT NULL,
    paymentID INT NOT NULL,
    FOREIGN KEY (paymentID) REFERENCES payment (paymentID),
    FOREIGN KEY (addressID) REFERENCES userAddress(userAddressID)
);

CREATE TABLE payment(
    paymentID INT NOT NULL PRIMARY KEY, 
    cardNumber VARCHAR(18) NOT NULL UNIQUE, -- stores this encrypted  
    expirationDate DATE NOT NULL,
    cvv INT NOT NULL, 
    addressID INT NOT NULL,
    customerID INT NOT NULL, 
    FOREIGN KEY (addressID) REFERENCES userAddress(userAddressID),
    FOREIGN KEY (customerID) REFERENCES customer(customerID)
);

CREATE TABLE category(
    categoryID INT NOT NULL PRIMARY KEY,
    categoryName VARCHAR(255) NOT NULL,
);

CREATE TABLE item (
    itemID INT NOT NULL PRIMARY KEY,
    saleID INT NOT NULL,
    itemWeight INT NOT NULL,
    dimensions VARCHAR(25) NOT NULL,
    manufacturer VARCHAR(255) NOT NULL, 
    itemDescription VARCHAR(250) NOT NULL, 
    quantity INT NOT NULL,
    imageURL VARBINARY(MAX),
    sku varchar(225) NOT NULL UNIQUE,
    rating FLOAT NOT NULL, 
    itemType VARCHAR(255),
    FOREIGN KEY (itemType) REFERENCES category(categoryName),
    FOREIGN KEY (saleID) REFERENCES sale(saleID)
);

CREATE TABLE sale (
    saleID INT NOT NULL PRIMARY KEY,
    dateOfSale DATETIME NOT NULL,
    saleType VARCHAR(50) NOT NULL, 
    saleAmount INT NOT NULL
);

CREATE TABLE cart (
    cartID INT NOT NULL PRIMARY KEY,
    customerID INT NOT NULL, 
    totalCost INT NOT NULL, 
    orderID INT NOT NULL,
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

CREATE TABLE userOrder (
    userOrderID INT NOT NULL PRIMARY KEY,
    cartID INT NOT NULL, 
    dateShipped DATETIME,
    FOREIGN KEY (cartID) REFERENCES cart(cartID)
);