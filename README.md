# Truck Yeah!

A fictitious driver/address management app that tries to assign drivers to delivery addresses based upon scoring criteria.

## How it works

Run the program, and enter the file paths when prompted. You need two files. One that contains addresses and another that contains the driver's names - one record per line in each file, please.

After inputting the file paths, the program will attempt to score the driver/address combinations based upon the criteria stated in the prompt. It will then return the unique combinations ranked from highest to lowest score. It should avoid using the same address or driver twice.

## Important Assumptions

The program assumes there are no duplicate addresses or driver names. It also assumes that all names are valid - no empty strings, malformed characters, etc.

## How to run it

### Pre-Reqs

- dotnet cli
- .net 6 sdk

The following commands should be ran from `/src/TruckYeah`

### Install Dependencies

```
dotnet restore
```

### Compile

```
dotnet build
```

### Run Unit Tests

```
dotnet test
```

### Run program

```
dotnet run --project TruckYeah
```
