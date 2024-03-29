PHLEET is a new webapp that enables the user to manage a fleet of vehicles and drivers, while also tracking trips that they make and any 
incidents that happen along the way. PHLEET allows a manager to checkout Vehicles to Drivers, tracking WHO drove WHAT, WHERE they drove it and
WHEN the trip took place. Any business who makes deliveries, offers rides or otherwise uses vehicles needs PHLEET.

PHLEET connects to the user's database to perform standard CRUD functions with their data. PHLEET manages Vehicles, Drivers, Trips, Incidents and
will eventually track maintenance schedules for vehicles.

For each item that PHLEET tracks, users will be able to do the following (example: Vehicles):
*Generate a list (index) of all Vehicles in the user's fleet
	*This list will also show all basic information about each Vehicle, such as Make, Model, Year, Mileage, etc.
*Add new Vehicles to their fleet
*Edit information about a Vehicle manually
*Remove a Vehicle from their fleet

Other features to be implemented:
*PHLEET will track the mileage on a certain trip so that distance can be analyzed
*PHLEET will track "marks" on a driver
	*If a driver repeatedly has at-fault incidents, they can be made inactive so that they cannot check out vehicles


PHLEET is a Model-View-Controller pattern project written in C# and designed and coded by Darrin Daugherty.
________________________________________________________________________________________________________________________________________

Query for database construction and seed/testing data:

Database construction:

USE MASTER
GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'Phleet'
)

CREATE DATABASE Phleet
GO

USE Phleet
GO

DROP TABLE IF EXISTS Vehicle;

create table Vehicle (
	Id INT,
	Description VARCHAR(50),
	Make VARCHAR(50),
	Model VARCHAR(50),
	Year VARCHAR(50),
	Plate INT,
	Mileage INT
);
insert into Vehicle (Id, Description, Make, Model, Year, Plate, Mileage) values (1, 'Chevy Suburban', 'Chevrolet', 'Suburban 2500', 2010, 265982, 46720);
insert into Vehicle (Id, Description, Make, Model, Year, Plate, Mileage) values (2, 'The Rust Bucket', 'Ford', 'Galaxie', 1964, 224921, 3228);
insert into Vehicle (Id, Description, Make, Model, Year, Plate, Mileage) values (3, 'The MPV', 'Mazda', 'MPV', 2001, 579784, 10412);

create table Driver (
	id INT,
	firstName VARCHAR(50),
	lastName VARCHAR(50),
	title VARCHAR(50),
	marks INT,
	active INT
);
insert into Driver (id, firstName, lastName, title, marks, active) values (1, 'Giuseppe', 'Wherton', 'Fleet Manager', 1, 1);
insert into Driver (id, firstName, lastName, title, marks, active) values (2, 'Caren', 'Phillips', 'Warehouse Worker', 0, 1);
insert into Driver (id, firstName, lastName, title, marks, active) values (3, 'Alison', 'Mathers', 'Foreman', 1, 1);

