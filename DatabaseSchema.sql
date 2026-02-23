-- ============================================================
-- Gym Management System – SQL Server Database Schema
-- Database: Gym-Database
-- ============================================================

-- Create the database (run once; skip if it already exists)
-- CREATE DATABASE [Gym-Database];
-- GO

USE [Gym-Database];
GO

-- ------------------------------------------------------------
-- Table: MembershipTypes
-- Stores the different membership plans offered by the gym.
-- Must be created before Members because Members references it.
-- ------------------------------------------------------------
CREATE TABLE MembershipTypes (
    MembershipTypeID INT          IDENTITY(1,1) PRIMARY KEY,
    TypeName         VARCHAR(100) NOT NULL,
    Description      VARCHAR(500) NOT NULL,
    DurationMonths   INT          NOT NULL,   -- length of the plan in months
    Price            DECIMAL(10,2) NOT NULL   -- cost in PKR
);
GO

-- ------------------------------------------------------------
-- Table: Staff
-- Stores gym trainers / staff members.
-- Must be created before Members because Members references it.
-- ------------------------------------------------------------
CREATE TABLE Staff (
    StaffID    INT          IDENTITY(1,1) PRIMARY KEY,
    Staff_Name VARCHAR(100) NOT NULL,
    Phone      VARCHAR(20)  NOT NULL,
    Position   VARCHAR(100) NOT NULL          -- e.g. "Head Trainer", "Nutritionist"
);
GO

-- ------------------------------------------------------------
-- Table: Members
-- Stores gym members and their active membership details.
-- ------------------------------------------------------------
CREATE TABLE Members (
    MemberID            INT          IDENTITY(1,1) PRIMARY KEY,
    MemberName          VARCHAR(100) NOT NULL,
    DateOfBirth         DATETIME     NOT NULL,
    Gender              VARCHAR(10)  NOT NULL,   -- 'Male' | 'Female'
    Phone               VARCHAR(20)  NOT NULL,
    MembershipTypeID    INT          NOT NULL
        REFERENCES MembershipTypes(MembershipTypeID),
    TrainerID           INT          NULL
        REFERENCES Staff(StaffID),              -- optional; NULL = no trainer assigned
    MembershipStartDate DATETIME     NOT NULL DEFAULT GETDATE(),
    MembershipEndDate   DATETIME     NOT NULL,   -- calculated: DATEADD(month, DurationMonths, MembershipStartDate)
    MembershipStatus    VARCHAR(20)  NOT NULL    -- 'Active' | 'Expired' | 'Terminated'
);
GO

-- ============================================================
-- Relationships summary
-- ============================================================
-- Members.MembershipTypeID  →  MembershipTypes.MembershipTypeID  (INNER JOIN – required)
-- Members.TrainerID         →  Staff.StaffID                      (LEFT JOIN  – optional)
-- ============================================================
