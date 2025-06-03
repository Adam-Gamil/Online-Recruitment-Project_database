# 🧑‍💼 Online Recruitment System

## 📌 Project Overview

The **Online Recruitment System** is a desktop application that simulates a digital platform connecting job seekers and employers.  
It automates the hiring process by allowing users to add, update, and view job-related data efficiently.  
The system supports both job seekers and employers with clearly structured menus and operations, providing functionalities such as applying to jobs, saving vacancies, and managing listings.

This project demonstrates skills in:
- Entity-Relationship modeling (ERD)
- SQL and database schema design
- ADO.NET data access
- CRUD operations
- Console menu-based user interface
- Simulated multi-role access (Jobseeker, Employer)

---

## 💼 Features

### 🔹 Jobseeker Functionalities
- Find job seeker by ID
- Register a new job seeker
- Update job seeker details
- Apply for jobs
- View applied jobs
- Delete an applied job
- Save a vacancy
- Delete saved vacancy
- View saved jobs
- Display all job seekers

### 🔹 Employer Functionalities
- Find employer by ID
- Register a new employer
- Update employer details
- Add a new job vacancy
- View posted jobs
- Display all employers

### 🔹 Shared Functionalities
- Add a phone number for any user
- Search for user phone number(s)
- Display all current vacancies

---

## 🛠️ Technologies Used

- **C#** – Backend application logic and UI (Console)
- **ADO.NET** – Database connectivity and queries
- **MS SQL Server** – Relational database engine for storing and managing recruitment data
- **SQL** – Data Definition Language (DDL) and Data Manipulation Language (DML)
- **.NET Framework** – Application runtime environment

---

## 🗃️ Database Requirements

### 1. ERD (Entity-Relationship Diagram)
- Designed to support all system functionalities and queries efficiently.

### 2. Physical Model (DDL Scripts)
- ERD converted into SQL Data Definition Language (DDL) scripts.

### 3. SQL Queries
- To answer critical recruitment analytics questions.

---

## 🗃️ ERD & Database Documentation

### 1. Entity-Relationship Diagram (ERD)
- The ERD was designed to support the system’s core functionalities such as job applications, vacancy listings, user management, and reporting.
- It captures key entities like **JobSeeker**, **Employer**, **Vacancy**, **Application**, and **PhoneNumbers**, along with their relationships.
- 📄 You can find the full ERD diagram, relational schema, and explanations for important queries in the PDF report located in the `documentation` folder of the repository:  
  [`/documentation/OnlineRecruitment_Documentation.pdf`](./documentation/OnlineRecruitment_Documentation.pdf)

### 2. Physical Model (DDL Scripts)
- The ERD has been translated into SQL DDL statements to create the actual relational database schema using **MS SQL Server**.

### 3. SQL Queries
The system supports insightful SQL queries such as:
- Job titles with the most or no applicants
- Employers with or without announcements last month
- Available positions grouped by employer
- Job seeker stats, including the number of jobs applied to

📌 **Note:** Most of these queries are included and explained in the accompanying PDF report.




