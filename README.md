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

#### Purpose
The program skims though 32 round files to get information about the matches

#### File Naming
Round files should be named like this: ***round-*** + ***[Round Number]*** + ***.csv***

Naming example:
```
round-4.csv
```

#### Content Formatting
First line in the file is descriptive to help with knowing what each value stands for:\
```home,home goals,away,away goals```\
The program starts reading data from line 2.

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

#### File Naming
The setup file should just be called setup.csv

Example:
```
setup.csv
```
#### Content Formatting
First line in the file is descriptive to help with knowing what each value stands for:\
```League name,Champions League,Conference League,Europa League,Relegation```\
The program starts reading data from line 2.

Setup File Example:
```
League name,Champions League,Conference League,Europa League,Relegation
SuperLigaen,1,2,1,2
```

### Teams File

#### Purpose
The Teams file container information about each individual team

#### File Naming
The teams file should just be called teams.csv

Example:
```
teams.csv
```

#### Content Formatting
First line in the file is descriptive to help with knowing what each value stands for:\
```Abbreviation,Full club name,Special ranking```\
The program starts reading data from line 2.

Teams File Example:
```
Abbreviation,Full club name,Special ranking
FCK,FC Copenhagen,W
BIF,Brondby IF,C
AGF,Aarhus GF,P
HBK,HB Køge,R
VFF,Vejle Boldklub,
AAB,Aalborg BK,
SIF,Silkeborg IF,P
RFC,Randers FC,
EFC,Esbjerg fB,
FCM,FC Midtjylland,
FCN,FC Nordsjælland,
HOB,Hobro IK,R
```





