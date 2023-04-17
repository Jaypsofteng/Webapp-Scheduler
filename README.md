# Webapp-Scheduler
## A complete web application for handling course and program scheduling

## Project guidlines and implemented requirements
Required Software:
Visual Studio 2022 and compatible .Net Framework 
Microsoft® SQL Server® 2022 Express

## Setup Steps:
1> Clone the project `git clone https://github.com/Jaypsofteng/Webapp-Scheduler.git`

2> Run Database migration using nuget package manager console or dotnet ef tool
    - `Update-Database` in nuget package manager console or 
    - `dotnet ef database update -- --environment Test`


## Build/Test Project:
Use MSBuild to manually build and run application
or use visual studio to build and test the application(no manual commands are needed).

## Project functions
CURD operations for programs/courses with individual views
Calendar functionality( Select holidays for the timeline ) for auto allocation of programs/courses 

## Images showcasing basic application overview
[![Home page](\WebApp-Scheduler\project-design\Webcapture_17-4-2023_14513_localhost.jpeg)]
[![Calendar Page](\WebApp-Scheduler\project-design\Webcapture_17-4-2023_145035_localhost.jpeg)]
