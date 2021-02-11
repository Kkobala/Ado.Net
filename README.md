# ADO.NET. Basics

## Purpose
**The purpose of the task:** to get a practical experience on how to work with ADO.NET to connect and store the applicatin data in the MS SQL local database.You will learn:
- how to create a sample database using Visual Studio 2019;
- how to expolore and update properties of the database by using VS Server Explorer;
- how to store the connection string in the appsetting.json configuration file;
- how to read, update and delete data from the database tables using ADO.NET classes.

**Estimated time to complete:** 3 hours.   

**Task status:** mandatory / manually-checked.   

## Description
1. Clone a skeleton solution from the repository provided by AutoCode
1. Create a new project and add to the solution. Use the `Console App (.NET Core)` VS 2019 project type
1. Create `Folder Database`
1. Select folder in `Solution` explorer and Add Database `Customers`:  
    
    ![](Pictures/ado.net.1.png) 

1. You should get
   
    ![](Pictures/ado.net.2.png)   

1. Open `VS Server Explorer` and see your database in the server view
  
    ![](Pictures/ado.net.3.png)

1. Add `Customers` Table to the `Customers.mdf` database

    ![](Pictures/ado.net.4.png)

1. Rename the default name `Table` to `Customers` by running script

    ![](Pictures/ado.net.5.png)

1. Refresh the Server Explorer View and make sure you got the database table renamed

    ![](Pictures/ado.net.6.png)

1. Select `Customers.mdf` in Server Explorer view, open `Properties` window and copy a connection string to the database

    ![](Pictures/ado.net.7.png)

1. Add a local variable to the `Main` method to store the connection string (see sample below)
1. Add a code to open the database connection using ADO.NET  and close the connection

    ![](Pictures/ado.net.8.png)

1. Run the application and make sure it works
1. Add `appsettings.json` and configure it

    ![](Pictures/ado.net.9.png)

1. Configure `appsettings.json` (Copy if newer)

    ![](Pictures/ado.net.10.png)

1. Move connection string value to the `appsettings.json`

    ![](Pictures/ado.net.11.png)

1. Change code in Main, so you read your connection settings from the appsettings.json file

    ![](Pictures/ado.net.12.png)

1. Run the application and make sure it works. Now you read the path to the database from the connection string. 


1. Add code for:
    - Adding records to the database
    - Deleting a record by the customer name
    - Updating a record by the customer name
    - Getting all records
    - etc.

