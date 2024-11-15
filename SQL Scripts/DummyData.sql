-- Insert data into userAddress
INSERT INTO userAddress (userAddressID, country, userState, city, zipcode, street)
VALUES
(1, 'USA', 'California', 'Los Angeles', '90001', '123 Main St'),
(2, 'USA', 'New York', 'New York City', '10001', '456 Broadway'),
(3, 'Canada', 'Ontario', 'Toronto', 'M5B1T8', '789 Queen St');

-- Insert data into payment
INSERT INTO payment (paymentID, cardNumber, expirationDate, cvv, addressID, customerID)
VALUES
(1, '1234567890123456', '2025-12-31', 123, 1, 1),
(2, '9876543210987654', '2026-06-30', 456, 2, 2);

-- Insert data into customer
INSERT INTO customer (customerID, userName, addressID, paymentID)
VALUES
(1, 'JohnDoe', 1, 1),
(2, 'JaneSmith', 2, 2);

-- Insert data into category
INSERT INTO category (categoryID, categoryName)
VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Books');

-- Insert data into sale
INSERT INTO sale (saleID, dateOfSale, saleType, saleAmount)
VALUES
(1, '2024-11-01 12:00:00', 'Online', 200),
(2, '2024-11-05 15:30:00', 'In-Store', 150);

-- Insert data into item
INSERT INTO item (itemID, saleID, itemWeight, dimensions, manufacturer, itemDescription, quantity, imageURL, sku, rating, itemType)
VALUES
(1, 1, 500, '10x10x5', 'TechCorp', 'Smartphone with high-resolution display', 20, NULL, 'SM12345', 4.5, 'Electronics'),
(2, 2, 200, '8x5x3', 'ApparelCo', 'Cotton t-shirt, unisex', 50, NULL, 'TS67890', 4.2, 'Clothing');

-- Insert data into cart
INSERT INTO cart (cartID, customerID, totalCost, orderID)
VALUES
(1, 1, 350, 1),
(2, 2, 150, 2);

-- Insert data into cartItems
INSERT INTO cartItems (cartID, itemID, itemCount, itemPrice)
VALUES
(1, 1, 2, 100),
(1, 2, 1, 150),
(2, 1, 1, 100);

-- Insert data into userOrder
INSERT INTO userOrder (userOrderID, cartID, dateShipped)
VALUES
(1, 1, '2024-11-03 09:00:00'),
(2, 2, NULL);

-- Insert data into guest
INSERT INTO guest (guestID, paymentID)
VALUES
(1, 2);
