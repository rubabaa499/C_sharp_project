Create Table Cus
(
    Name   VARCHAR (20) NOT NULL,
    Address VARCHAR (25) NOT NULL,
    Cus_Id  VARCHAR (6) primary key not null,
    phn   VARCHAR (11) NOT NULL,
    nid    VARCHAR (15) NOT NULL,
    pass    VARCHAR (25) NOT NULL,
    email   VARCHAR (50) NOT NULL,
    vacc    VARCHAR (5)  NOT NULL,
    vac_id  VARCHAR (15) NULL
);

CREATE SEQUENCE Cus_seq start with 1 increment by 1001 maxvalue 10000;
