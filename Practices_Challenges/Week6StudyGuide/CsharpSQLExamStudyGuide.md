# C#/SQL Exam Study Guide

## Git

    1. What is Git?
    My answer: Git is a tool for managing code repositories. It allows for easy branching and merging.
    Textbook answer:

    2. What is Gitbash?
    My answer: Gitbash is a Command Line interface designed to better interface with the git method of handling repositories.
    Textbook answer:

    3. How do we create a branch?
    My answer: the command git branch. There are a numberof arguments that modify the branch creation.
    Textbook answer:

    4. How do we clone a repo?
    My answer: the command git clone. There are a numberof arguments that modify the branch creation.
    Textbook answer:

    5. Git add/commit/push and pull.
    My answer: Add: git add. the '.' argumnet allows everything to be added without having to select.Commit: git commit. There are a number of arguments to mdify how the commit works. Push: git push. Pull: git pull
    Textbook answer:

    6. What does Git allow us to do in a collaborative environment?
    My answer: Git allow us to control the merging of code written by collaborators, with tools to catch and resolve conflicts.
    Textbook answer:

## C#/OOP

    1. What are you OOP Fundamentals? (4 Pillars of OOP)
       1. Abstraction -
       My answer: To simplify the details of implementation with 
       Example: have a button that you push and it makes coffe. no abstraction: have separate buttons for each step in the cofee making process
       Textbook answer: Modelin g the relevant attributes and interactions of entities as classes to define an abstract representation of a system

       2. Encapsulation - 
       My answer: keeping access to data and code restricted only to what needs it.
       Textbook answer: Hiding the internal state and functionality of an object and only allowing access through a public set of functions.

       3. Inheritance -
       My answer: A new object taking on on the properties of an existing object so that you don't need to redefine those propertiescd
       Textbook answer: Ability to create new abstractions based on eisting abstractions.

       4. Polymorphism -
       My answer: Code should be flexible enough to be used in multiple applications. Example: if a Shape class has a draw method, t he child classes should both be able to use the draw method without cncern to whether the child is a circle, square, triangle, etc.         
       Textbook answer: Ability to implement inherited properties of methods in different ways across multiple abstractions


    2. What does the syntax (in our code) look like for...
       1. implementing an interface?
       My answer:
       Textbook answer:

       2. inheriting from a parent class?
       My answer:
       Textbook answer:

       3. Declaring a collection of some specific type?
       My answer:
       Textbook answer:


    3. Exception Handling (Try-Catch-Finally)
       My answer:
       Textbook answer:

    4. Within a class...
       1. What are class members? (fields/methods)
       My answer:
       Textbook answer:

       2. How do we declare a property (using that {get;set;})
       My answer:
       Textbook answer:

       3. What is a constructor? What does it allow us to do?
       My answer:
       Textbook answer:

          1. How/when do we call it?
          My answer:
          Textbook answer:

    5. Access modifiers (Public vs Private vs Internal)
    My answer: 
    Textbook answer: 
    
    6. Control Flow
       1. Our loops
       My answer: 
       Textbook answer: 
    
       2. If-elseif-else
       My answer: 
       Textbook answer: 
    
       3. Switch
       My answer: 
       Textbook answer: 
    
       4. Our different comparison operatos (==, !=, >=, etc)
       My answer: 
       Textbook answer: 
    
       5. For loops vs foreach
       My answer: 
       Textbook answer: 

    7. What is an interface?
    My answer: 
    Textbook answer: 
    
       1. How are they used?
       My answer: 
       Textbook answer: 
    
       2. How do they compare/contrast to a class?
       My answer: 
       Textbook answer: 
    
    8. List vs Dictionary?
    My answer: 
    Textbook answer: 
    
       1. Both are collections, but how do they differ?
       My answer: 
       Textbook answer: 
    
    9. What does our .csproj contain?
    My answer: 
    Textbook answer: 
    
       1.  Meta-data about our project (things like it's name)
       My answer: 
       Textbook answer: 
    
       2.  Package references that we brought in via Nuget (things we dotnet add'd)
       My answer: 
       Textbook answer: 
    
       3.  Project references to other .csproj files that we want to bundle together, such as with xUnit testing projects
       My answer: 
       Textbook answer: 
    

## SQL

    1. SQL Sublanguages (DML, DQL, DDL, DCL*)
        My answer: 
    Textbook answer: 
    
       1. Data Query Language - SELECT
           My answer: 
    Textbook answer: 
    
       2. Data Definition Language - CREATE, DROP, ALTER, TRUNCATE
           My answer: 
    Textbook answer: 
    
       3. Data Manipulation Language - INSERT, UPDATE, DELETE
           My answer: 
    Textbook answer: 
    
       4. Data Control Language* - GRANT, REVOKE (These probably *hint* wont come up in the exam)
    2. SELECTs with filters inside  -SELECT WHERE
        My answer: 
    Textbook answer: 
    
    3. Basics of Joins
       1. What is a Join?
           My answer: 
    Textbook answer: 
    
       2. What do they do/return for us?
           My answer: 
    Textbook answer: 
    
       3. Inner vs Outer Join, Left vs Right Joins.
           My answer: 
    Textbook answer: 
    
       4. Null values in a table, and Joins - How do nulls behave within a Join query?
           My answer: 
    Textbook answer: 
    
    4. What are the properties of a Primary Key in SQL? (Unique, Not Null)
        My answer: 
    Textbook answer: 
    
    5. What is a Foreign Key?
        My answer: 
    Textbook answer: 
    

## ADO.NET

    1. What is ADO.NET (at a high level?)
        My answer: 
    Textbook answer: 
    
    2. What does it let us do in our projects?
        My answer: 
    Textbook answer: 
    
    3. What is a connection string?
        My answer: 
    Textbook answer: 
    
    4. What is the DataReader in ADO.NET
        My answer: 
    Textbook answer: 
    
       1. What is it's behavior?
          1. Read only, forward only.
