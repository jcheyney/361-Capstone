
INSERT INTO userAddress (userAddressID, country, userState, city, zipcode, street)
VALUES
(1, 'USA', 'California', 'Los Angeles', '90001', '123 Main St'),
(2, 'USA', 'New York', 'New York City', '10001', '456 Broadway'),
(3, 'Canada', 'Ontario', 'Toronto', 'M5B1T8', '789 Queen St');


INSERT INTO customer (customerID, userName, addressID, paymentID)
VALUES
(1, 'JohnDoe', 1, NULL),
(2, 'JaneSmith', 2, NULL);


INSERT INTO payment (paymentID, cardNumber, expirationDate, cvv, addressID, customerID)
VALUES
(1, '1234567890123456', '2025-12-31', 123, 1, 1),
(2, '9876543210987654', '2026-06-30', 456, 2, 2);


UPDATE customer SET paymentID = 1 WHERE customerID = 1;
UPDATE customer SET paymentID = 2 WHERE customerID = 2;


INSERT INTO category (categoryID, categoryName)
VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Books');


INSERT INTO sale (saleID, dateOfSale, saleType, saleAmount)
VALUES
(1, '2024-11-01 12:00:00', 'Online', 200),
(2, '2024-11-05 15:30:00', 'In-Store', 150);

INSERT INTO item (itemID, saleID, itemWeight, dimensions, manufacturer, itemDescription, quantity, imageURL, sku, rating, itemType)
VALUES
(1, 1, 500, '10x10x5', 'TechCorp', 'Smartphone with high-resolution display', 20, NULL, 'SM12345', 4.5, 1), 
(2, 2, 200, '8x5x3', 'ApparelCo', 'Cotton t-shirt, unisex', 50, NULL, 'TS67890', 4.2, 2); 


INSERT INTO userOrder (userOrderID, cartID, dateShipped)
VALUES
(1, NULL, '2024-11-03 09:00:00'), 
(2, NULL, NULL);


INSERT INTO cart (cartID, customerID, totalCost, orderID)
VALUES
(1, 1, 350, 1), 
(2, 2, 150, 2); 


UPDATE userOrder SET cartID = 1 WHERE userOrderID = 1;
UPDATE userOrder SET cartID = 2 WHERE userOrderID = 2;


INSERT INTO cartItems (cartID, itemID, itemCount, itemPrice)
VALUES
(1, 1, 2, 100),
(1, 2, 1, 150),
(2, 1, 1, 100);


INSERT INTO guest (guestID, paymentID)
VALUES
(1, 2);
