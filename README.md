[![Build Status](https://codingflow.visualstudio.com/NorthwindTraders/_apis/build/status/NorthwindTraders%20-%20CI?branchName=master)](https://codingflow.visualstudio.com/NorthwindTraders/_build/latest?definitionId=22&branchName=master)

# Appointment OS

About Appointment OS

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)
 * [Node.js](https://nodejs.org/en/) (version 10 or later) with npm (version 6.11.3 or later)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Next, within the `\Src\WebUI\ClientApp` directory, launch the front end by running:
      ```
     npm start
     ```
  5. Once the front end has started, within the `\Src\WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [https://localhost:44376/](http://localhost:44376/) in your browser to view the Web UI
  
  6. Launch [https://localhost:44376/api](http://localhost:44376/api) in your browser to view the API

## Technologies
* .NET Core 3
* ASP.NET Core 3
* Entity Framework Core 3
* Angular 8
