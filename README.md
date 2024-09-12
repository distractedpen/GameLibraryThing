# Game Library Thing (Name subject to Change)

Personal Game Library Manager. Track the games you own/want and if you have completed them.

# Dev Setup
Requirements:
- .Net 8.0+
- Nodejs
- SQL Server Developer 2022

For backend:  
This project uses SQL Server 2022 as the database for development.
Make sure that the database `gamelibrary` exists in your local instance.
Run the following command to `dotnet database update` to build the tables for the database

Run `dotnet run watch` to start the backend



For frontend:  
`npm i` in frontend dir  
`npm run dev`
