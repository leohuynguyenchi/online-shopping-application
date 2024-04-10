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