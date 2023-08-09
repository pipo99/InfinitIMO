# InfinitIMO
Real Estate Property Management System

Portfolio project developed by: 

Márcio Borges 
https://www.linkedin.com/in/marcioborges/



*************************************************************************************************************************************************
*****************************											OVERVIEW									*****************************
*************************************************************************************************************************************************


Project developed using the following technology stack:
- Usage of .NET CORE MVC for building the application
- Usage of C# for server-side coding
- Design and implementation of SQL Server database
- Usage of Entity Framework Core 
- Design and implementation of Microservices
- Usage of .Net Core Identity for Basic user authentication 
- Usage of Web API

Backlog items to a future version:
- Implement JWT Token to increase Microservice security 
- Unit Tests using NUnit to Ensure Delivery Quality



*************************************************************************************************************************************************
*****************************											DECISIONS									*****************************
*************************************************************************************************************************************************
I decided not to create a service for user management.
Instead I used .Net Core Identity because for the proposed objective, it meets the requirement and saved a lot of development time.
Besides, it is always a good practice to use libraries provided by .NET

Regarding the layout, not much focus was given, due to the limited time available. I create a simple and functional layout





*************************************************************************************************************************************************
*****************************					Instructions for opening and running the project					*****************************
*************************************************************************************************************************************************


Step 1 - Open solution on visual studio 2022
1.1 - After opening the solution in vs 2022, three projects will be displayed: InquiryService, PropertyService and WebSite 

Step 2 - Configure SQL CONNECTION in each project
2.1 Write yout server name on Data Source= on DBConnection tag at appsetting.json .
2.2 Write a valid user and password to authenticate on sql server, or integrated security (based on your sql preferences)
2.2 Make the same in projects: InquiryService, PropertyService and WebSite 

Step 3 - Create Database to store USERS on SQL SERVER 
3.1 Create a database in sql server called <b>InfinitIMO_User</b>
3.2 Expand project WebSite
3.3 Verify Migration Folder and confirm if 20230809191706_CreateUserDataModel.cs exists
3.4 Right side on WebSite project and click on OPEN IN TERMINAL
3.5 Please apply migrations by running ef database update command in console window
3.6 If everything went well, we will now have tables AspNetRoleClaims,AspNetRoles,AspNetUserClaims,AspNetUserLogins,AspNetUserRoles,AspNetUsers and AspNetUserTokens in the database InfinitIMO_User

Step 4 - Create Database to store PROPERTIES on SQL SERVER 
4.1 Create a database in sql server called InfinitIMO_Property
4.2 Expand project PropertyService
4.3 Verify Migration Folder and confirm if 20230809192429_CreatePropertyDataModel.cs exists
4.4 Right side on PropertyService project and click on OPEN IN TERMINAL
4.5 Please apply migrations by running ef database update command in console window
4.6 If everything went well, we will now have table Properties in the database InfinitIMO_User

Step 5 - Create Database to store INQUIRIES on SQL SERVER 
5.1 Create a database in sql server called InfinitIMO_Inquiry
5.2 Expand project InquiryService
5.3 Verify Migration Folder and confirm if 20230809192719_CreateInquiryDataModel.cs exists
5.4 Right side on InquiryService project and click on OPEN IN TERMINAL
5.5 Please apply migrations by running ef database update command in console window
5.6 If everything went well, we will now have table Inquiries in the database InfinitIMO_User

Step 6  - Configure Startup Projects
6.1 Right click on Solution 
6.2 Click in Configure Startup Projects
6.3 Click in Multiple Startup Project
6.4 Click in each project (InquiryService, PropertyService, WebSite) and choose Action= Startup

Step 7 - Run solution 
7.1 Click in play button to run solution
7.2 Will open 3 browser tabs, one for each project
7.3 Confirm microservice URL Property and Inquiry
7.4 Adjust the url of each API in the appsetting.json file at WEBSITE project
"ApiSettings": {
	"PropertyAPIURL": "https://localhost:7143",
	"InquiryAPIURL": "https://localhost:7041"
}


Step 8 - Stop and Run again 
8.1 After change the correct URL of each service please run again the solution




*************************************************************************************************************************************************
*****************************										POST MAN COLLECTION								*****************************
*************************************************************************************************************************************************
Please test the Microservices, import a collection in your postman.
The collection is present in the DOCS folder on github, named: InfinitIMO.postman_collection.json




*************************************************************************************************************************************************
*****************************										API DOCUMENTATION								*****************************
*************************************************************************************************************************************************
Please consult all the documentation of our micro services, present in the DOCS folder, called: InquiryService.html and PropertyService.html

