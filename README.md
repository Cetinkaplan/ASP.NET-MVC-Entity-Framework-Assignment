# ASP.NET MVC Insurance Quote Application

## Assignment Part 3

This project is an ASP.NET MVC application that uses Entity Framework to collect customer information and automatically calculate an insurance quote.

The application was created as part of an ASP.NET MVC and Entity Framework course assignment.

---

## Project Overview

The Insurance Quote Application allows a user to enter personal and vehicle information.

After the form is submitted, the application automatically calculates the customer's monthly insurance quote based on the assignment requirements.

The quote is calculated by the `InsureeController` and saved to the database using Entity Framework.

An Admin page is also included to display all insurance quotes that have been issued.

---

## Technologies Used

* C#
* ASP.NET MVC
* Entity Framework
* .NET Framework
* Razor
* SQL Server
* HTML
* CSS
* Bootstrap
* Visual Studio
* Git
* GitHub
* Course/project overview
* C# skills learned
* Object-oriented programming
* Classes and objects
* Inheritance
* Interfaces
* Polymorphism
* Operator overloading
* Methods and parameters
* Arrays and collections
* Debugging
* ASP.NET MVC
* Entity Framework
* Code-First
* SQL/database concepts
* Projects completed during the course
* Links to your individual GitHub projects

---

## Quote Calculation

The insurance quote starts with a base price of:

**$50 per month**

### Age

The following charges are added based on the customer's age:

| Age         | Additional Charge |
| ----------- | ----------------: |
| 18 or under |             +$100 |
| 19–25       |              +$50 |
