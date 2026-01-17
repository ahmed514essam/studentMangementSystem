# Student Management System (Academic Portal)

## 📌 Overview
This project is a **Student Management System** built with **ASP.NET Core MVC** and **Entity Framework**.  
It provides a complete academic portal with CRUD operations for students, departments, and courses.  
The system is designed to handle academic years, sports, and department-specific structures, ensuring a scalable and secure solution.

---

## 🚀 Features
- **CRUD Operations**  
  - Students  
  - Departments  
  - Courses  

- **Seed Data**  
  - Academic years seeded based on department type  
    - Education / Computer Science → 4 years  
    - Engineering → Preparatory year + 4 years  

- **Authentication & Security**  
  - Only registered students can log in  
  - Encrypted and secured passwords (without using Identity, to demonstrate manual implementation)  
  - Unauthorized users cannot access any information  

- **Student Dashboard**  
  - Displays student’s department and registered courses  
  - Ability to register new courses (restricted to the student’s department)  

- **Database Relationships**  
  - Restrict Delete: entities cannot be deleted unless dependent records are removed  
    - Example: A department cannot be deleted until its courses are deleted  

- **Technical Implementation**  
  - Fluent API for entity configuration  
  - Entity Framework **Code First** approach  
  - SQL Server database integration  

---

## 🛠️ Tech Stack
- **Language:** C#  
- **Framework:** ASP.NET Core MVC  
- **UI:** Razor Pages + Bootstrap  
- **Database:** SQL Server  
- **ORM:** Entity Framework (Code First)  

---

## 📂 Project Highlights
- Demonstrates strong understanding of **Entity Framework relationships** and **Fluent API**.  
- Secure login system with **custom password encryption** (without Identity).  
- Proper handling of **Restrict Delete** to maintain data integrity.  
- Second project using **MVC + Entity Framework**, showing progression in architectural design and implementation.  

---

## ⚠️ Known Limitations (to be improved in next release)
- Student grades per course and academic year are not yet implemented.  
- Automatic student status evaluation (e.g., pass/fail based on grades) is missing due to time constraints.  
- These features are planned for **Version 2** of the project.  

---

## 📖 How to Run
1. Clone the repository.  
2. Update the connection string in `appsettings.json` to match your SQL Server setup.  
3. Run migrations to create the database (`dotnet ef database update`).  
4. Launch the project from Visual Studio or via CLI (`dotnet run`).  

---

## 👨‍💻 Author
Developed by *Ahmed Essam El Sayed*  
- Passionate about building scalable web applications  
- Focused on clean architecture, secure authentication, and polished UI/UX  

