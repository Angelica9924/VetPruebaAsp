-- Active: 1717530653945@@brktjml67tniiu24xixy-mysql.services.clever-cloud.com@3306@brktjml67tniiu24xixy
CREATE TABLE Owners (
    OwnerId INT AUTO_INCREMENT PRIMARY KEY,
    Names VARCHAR(50) NOT NULL,
    LastNames VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Address VARCHAR(30) NOT NULL,
    Phone VARCHAR(25) NOT NULL
);

CREATE TABLE Vets (
    VetId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(120) NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Address VARCHAR(30) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Pets (
    PetId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(25) NOT NULL,
    Specie ENUM('Dog', 'Cat', 'Bird') NOT NULL,
    Race ENUM('Pitbull','Husky','Yorkie') NOT NULL,
    DateBirth DATE NOT NULL,
    OwnerId INT NOT NULL,
    Photo TEXT NOT NULL,
    FOREIGN KEY (OwnerId) REFERENCES Owners(OwnerId)
);

CREATE TABLE Quotes (
    QuoteId INT AUTO_INCREMENT PRIMARY KEY,
    Date DATETIME NOT NULL,
    PetId INT NOT NULL,
    VetId INT NOT NULL,
    Description TEXT NOT NULL,
    FOREIGN KEY (PetId) REFERENCES Pets(PetId),
    FOREIGN KEY (VetId) REFERENCES Vets(VetId)
);

INSERT INTO `Vets`(`VetId`, `Name`, `Phone`, `Address`, `Email`) VALUES (1,'Alex','3102563289','CR 46 CL 23','alex@gmail.com'),(2,'Valentina','3165863289','CR 30 CL 63','valentina@gmail.com')