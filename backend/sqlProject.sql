-- TABLE : Category
CREATE TABLE Category (
                          Id SERIAL PRIMARY KEY,
                          CategoryName VARCHAR(100) NOT NULL
);

-- TABLE : Product
CREATE TABLE Product (
                         Id SERIAL PRIMARY KEY,
                         CategoryId INT REFERENCES Category(Id),
                         Name VARCHAR(255) NOT NULL,
                         Description TEXT,
                         Ingredients TEXT,
                         PracticalInfo TEXT,
                         Brand VARCHAR(100),
                         ProductPrice DECIMAL(10,2),
                         PricePerKilo DECIMAL(10,2),
                         StockQuantity INT DEFAULT 0
);

-- TABLE : MemberCard
CREATE TABLE MemberCard (
                            Id UUID PRIMARY KEY,
                            UserId NVARCHAR(450) REFERENCES AspNetUsers(Id),
                            TotalPoints INT DEFAULT 0
);

-- TABLE : PointHistory
CREATE TABLE PointHistory (
                              Id SERIAL PRIMARY KEY,
                              MemberCardId UUID REFERENCES MemberCard(Id),
                              PointsChanged INT NOT NULL,
                              ChangeReason VARCHAR(255),
                              ChangeDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- TABLE : Favoris
CREATE TABLE Favoris (
                         Id SERIAL PRIMARY KEY,
                         UserId NVARCHAR(450) REFERENCES AspNetUsers(Id),
                         ProductId INT REFERENCES Product(Id),
                         Liked BOOLEAN DEFAULT TRUE
);

-- TABLE : Promo
CREATE TABLE Promo (
                       Id SERIAL PRIMARY KEY,
                       GeneratedCode VARCHAR(15) NOT NULL UNIQUE,
                       Percent INT NOT NULL,
                       ExpirationDate DATE
);

-- TABLE : UserCommand
CREATE TABLE UserCommand (
                             Id SERIAL PRIMARY KEY,
                             UserId NVARCHAR(450) REFERENCES AspNetUsers(Id),
                             OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                             TotalAmount DECIMAL(10,2) NOT NULL
);

-- TABLE : OrderItem
CREATE TABLE OrderItem (
                           Id SERIAL PRIMARY KEY,
                           UserCommandId INT REFERENCES UserCommand(Id),
                           ProductId INT REFERENCES Product(Id),
                           PriceAtPurchase DECIMAL(10,2) NOT NULL,
                           Quantity INT NOT NULL
);

-- TABLE : Notification
CREATE TABLE Notification (
                              Id SERIAL PRIMARY KEY,
                              UserId NVARCHAR(450) REFERENCES AspNetUsers(Id),
                              Message TEXT NOT NULL,
                              IsRead BOOLEAN DEFAULT FALSE,
                              CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- TABLE : ErrorLog
CREATE TABLE ErrorLog (
                          Id SERIAL PRIMARY KEY,
                          ErrorMessage TEXT NOT NULL,
                          StackTrace TEXT,
                          LoggedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- TABLE : StockMovement
CREATE TABLE StockMovement (
                               Id SERIAL PRIMARY KEY,
                               ProductId INT REFERENCES Product(Id),
                               QuantityChanged INT NOT NULL,
                               MovementType VARCHAR(50) NOT NULL, -- IN / OUT
                               MovementDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
