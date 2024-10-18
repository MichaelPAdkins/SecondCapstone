-- Table Definitions
CREATE TABLE UserProfile (
    Id int PRIMARY KEY IDENTITY,
    DisplayName nvarchar(50),
    FirstName nvarchar(50),
    LastName nvarchar(50),
    Email nvarchar(255)
);

CREATE TABLE Tags (
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(50)
);

CREATE TABLE Camera (
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(255)
);

CREATE TABLE Locations (
    Id int PRIMARY KEY IDENTITY,
    Name nvarchar(50)
);

CREATE TABLE Entry (
     Id int PRIMARY KEY IDENTITY,
    FileName nvarchar(255),
    CaptureDate nvarchar(255),
    FileSize nvarchar(255),
    Resolution nvarchar(255),
    PhysicalBackUps nvarchar(255),
    CameraId int,
    UserId int,
    FOREIGN KEY (CameraId) REFERENCES Camera(Id),
    FOREIGN KEY (UserId) REFERENCES UserProfile(Id)
);

CREATE TABLE EntryTags (
     Id int PRIMARY KEY IDENTITY,
    EntryId int,
    TagId int,
    FOREIGN KEY (EntryId) REFERENCES Entry(Id),
    FOREIGN KEY (TagId) REFERENCES Tags(Id)
);

CREATE TABLE EntryLocations (
    Id int PRIMARY KEY IDENTITY,
    EntryId int,
    LocationsId int,
    FOREIGN KEY (EntryId) REFERENCES Entry(Id),
    FOREIGN KEY (LocationsId) REFERENCES Locations(Id)
);
