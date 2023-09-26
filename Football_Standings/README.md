# Mandatory assignment: Football Standings

##  A C# program that outputs a table with football-league information based on csv files

This project takes different sorts of csv files to output information
about how a league is going.

This program requires:
* Multiple round files
* A setup file
* a teams file

## How to format information in your files

### Round files

**Purpose**\
The program skims though 32 round files to get information about the matches

#### File Naming 
Round files should be named like this:***round-*** + ***[Round Number]*** + ***.csv***

Naming example:
```
round-4.csv
```

#### Formatting
The information should be formatted like this: 

The program automatically skips the first line, so the ```home,home goals,away,away goals```  ***Must*** be included first

Formatting example:
```
home,home goals,away,away goals
FCK,4,BIF,0
BIF,0,AGF,3
AGF,1,HBK,1
HBK,4,VFF,3
VFF,1,AAB,4
AAB,1,SIF,1
```
> [!NOTE]
> The program is currently made to check though 32 rounds so make sure that you make use of 32 round files

### Setup file

#### Purpose
The setup file is used for information about the league itself

### File Naming
The setup file should just be called setup.csv

Example:
``` 
setup.csv
```
#### Formatting
First line in the file is descriptive to help with knowing what each value stands for:\
```League name,Champions League,Conference League,Europa League,Relegation```\
Second line is what the program actually reads. It's organized like this:
```
Name of the league , Quantity of positions for Champions league promotion, Quantity of positions for Conference league promotion, e.t.c. 
```


Setup File Example:
``` 
League name,Champions League,Conference League,Europa League,Relegation
SuperLigaen,1,2,1,2
```




