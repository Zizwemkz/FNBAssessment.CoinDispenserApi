<div align="center">
  <h1>
   Coin Dispenser API
  </h1>
  <p>   
   The Coin Dispenser project is a service that calculates the minimum number of coins needed to make a given amount using specific denominations. This can be useful in various applications such as vending machines, automated teller machines (ATMs), or any system where change needs to be dispensed efficiently.
  </p>

</div>

# Introduction 

# Key Features:
Calculate Minimum Coins: Given a set of coin denominations and an amount, the service calculates the minimum number of coins needed to make that amount.
Store Calculations: The results of the calculations are stored in a database for future reference.
RESTful API: The project provides a RESTful API for interacting with the coin dispenser service.

# Project Structure:
Models: Defines the CoinDispenser model with properties for denominations, amount, and minimum coins.
Data Access: Contains the CoinDispenserContext class for database interactions using Entity Framework Core.
Repositories: Implements the CoinDispenserRepository for data operations.
Services: Implements the CoinDispenserService for business logic.
Controllers: RESTful API controllers for handling HTTP requests.


# Getting Started
To get started first clone the repo to check it out locally.

```bash
```

# Getting Started
# Prerequisites:
    .NET 6.0 SDK
    SQL Server or any other SQL database
    Visual Studio or any other preferred IDE

## Building
To build the code, ensure you have installed the [BuildIt](https://confluence.derivco.co.za/display/DDOLC/Build+Setup#BuildSetup-BuildIt) tool. Once installed locally, run the following in powershell:

    dotnet buildit

Further actions can be found running `.\build.ps1 --help` or `.\build.ps1 --plan`.

### Running the API
To run the CoinDispenser project , ensure you have installed [Docker Desktop](https://docs.docker.com/desktop/install/windows-install) and follow this [guide](https://confluence.derivco.co.za/display/DDOLC/Install+and+Configure+Docker+Desktop) to configure. Once installed, ensure your path is set to the root of the project and run the following in powershell:

    docker compose up

### Running the T1 tests
To run the CoinDispenser project T1 tests

## Design
High Level Architecture Diagrmas can be found here: ![Design diagrame](/FNBAssessment.CoinDispenserApi/Design/diagrame1.png)</a>

