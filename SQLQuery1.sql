Create Table Bus (
    BusId VARCHAR (25) primary key NOT NULL,
    BusName VARCHAR (25) NOT NULL,
    BusFrom VARCHAR (25) NOT NULL,
    BusTo VARCHAR (25) NOT NULL,
    Time VARCHAR (11) NOT NULL,
    TFormat VARCHAR (15) NOT NULL,
    Fare VARCHAR (15) NOT NULL,
);
Create Table Ticket (
    TicketId VARCHAR (10) primary key NOT NULL,
    Seat VARCHAR (10) NOT NULL,
    Cus_Id VARCHAR (10) NOT NULL,
    BusId VARCHAR (10) NOT NULL,
    Date Date NOT NULL,
    Time VARCHAR (10) NOT NULL,
);
Create Table CancelTicket (
    CancelId VARCHAR (10) primary key NOT NULL,
    TicketId VARCHAR (10) NOT NULL,
    Cus_Id VARCHAR (10) NOT NULL,
);