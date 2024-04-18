CREATE TABLE Users (
    userID numeric PRIMARY KEY,
    userType varchar(10) NOT NULL,
    user_name varchar(100) NOT NULL,
    salary numeric(10, 2) DEFAULT NULL,
    jobTitle varchar(50) DEFAULT NULL,
    home_address varchar(100) DEFAULT NULL,
    delivery_address varchar(100) DEFAULT NULL,
    payment_address varchar(100) DEFAULT NULL
);

CREATE TABLE Product (
    prod_id numeric PRIMARY KEY,
    prod_name VARCHAR(50),
    price NUMERIC NOT NULL
);

CREATE TABLE CreditCards (
    cardID numeric PRIMARY KEY,
    user_ID NUMERIC NOT NULL,
    cardNumber VARCHAR(20) NOT NULL,
    expiryDate DATE NOT NULL,
    FOREIGN KEY (user_ID) REFERENCES Users(userID)
);

CREATE TABLE Warehouse (
    warehouse_id numeric PRIMARY KEY,
    capacity NUMERIC NOT NULL,
    address VARCHAR(255) NOT NULL
);

CREATE TABLE Orders (
    order_id SERIAL PRIMARY KEY,
    user_ID NUMERIC NOT NULL,
    prod_id NUMERIC NOT NULL,
    quantity NUMERIC NOT NULL,
    credit_card NUMERIC NOT NULL,
    status VARCHAR(50),
    delivery_type VARCHAR(50),
    delivery_price NUMERIC,
    ship_date DATE NOT NULL,
    delivery_date DATE NOT NULL,
    FOREIGN KEY (user_ID) REFERENCES Users(userID),
    FOREIGN KEY (prod_id) REFERENCES Product(prod_id),
    FOREIGN KEY (credit_card) REFERENCES CreditCards(cardID)
);

CREATE TABLE Stock (
    stock_id SERIAL PRIMARY KEY,
    prod_id NUMERIC NOT NULL,
    warehouse_id NUMERIC NOT NULL,
    quantity NUMERIC NOT NULL,
    FOREIGN KEY (prod_id) REFERENCES Product(prod_id),
    FOREIGN KEY (warehouse_id) REFERENCES Warehouse(warehouse_id)
);

CREATE TABLE Suppliers (
    sup_id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    prod_id NUMERIC NOT NULL,
    price NUMERIC NOT NULL,
    address VARCHAR(255) NOT NULL,
    FOREIGN KEY (prod_id) REFERENCES Product(prod_id)
);

INSERT INTO Users (userID, userType, user_name, salary, jobTitle, home_address, delivery_address, payment_address)
VALUES
    (1, 'Customer', 'John Doe', NULL, NULL, '123 Main St, Anytown, USA', '123 Main St, Anytown, USA', '123 Main St, Anytown, USA'),
    (2, 'Customer', 'Jane Smith', NULL, NULL, '456 Elm St, Somecity, USA', '456 Elm St, Somecity, USA', '456 Elm St, Somecity, USA'),
    (3, 'Staff', 'Dan Johnson', 60000.00, 'Manager', '789 Oak St, Othercity, USA', NULL, NULL),
    (4, 'Staff', 'Bob Williams', 45000.00, 'Sales Associate', '321 Pine St, Anothercity, USA', NULL, NULL);

INSERT INTO CreditCards (cardID, user_ID, cardNumber, expiryDate) VALUES
(1, 1, '1234567890123456', '2025-12-31'),
(2, 2, '9876543210987654', '2024-09-30');

INSERT INTO Warehouse (warehouse_id, capacity, address) VALUES
(1, 1000, '123 Main Street'),
(2, 1500, '456 Elm Street');

INSERT INTO Product (prod_id, prod_name, price) VALUES
(1, 'Wilson Evolution Indoor Basketball', 59.99),
(2, 'Spalding NBA Street Outdoor Basketball', 29.99),
(3, 'Nike Elite Championship Basketball', 89.99),
(4, 'Under Armour 495 Indoor/Outdoor Basketball', 39.99),
(5, 'Molten BGG Composite Basketball', 44.99);

INSERT INTO Suppliers (name, prod_id, price, address) VALUES
('Supplier A', 1, 25.99, '789 Oak Street'),
('Supplier B', 2, 89.99, '101 Maple Avenue');

INSERT INTO Stock (prod_id, warehouse_id, quantity) VALUES
(1, 1, 50),
(2, 2, 30);