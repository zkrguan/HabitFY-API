# HabitFY-API

## What is HabitFY?

HabitFY is not just another ; it's a catalyst for positive change.

It's that something. That gets your lazy butt moving, urging you to toss away the whole pack of smokes. It's the nudge that breaks the cycle of endless TikTok scrolling, motivating you to get up and engage in activities that truly matter. HabitFY is your partner in transforming routines, fostering healthier habits, and bringing a positive shift to your lifestyle.

## Tech Detail

Framework: dot net core 8.0 

ORM: EF Core 8.0

Recommended IDE: Visual Studio 2022 > 17.8 

Security: MS identity

DB: MS SQL Server

(More packages will be updated at here)

## Work flow

Main is protected. A topic branch requires two members to approve before it merges to the main. ( For example, Sujan is trying to merge his feature branch to the main, and he of course will approve it. But it is not enough, he also needs either Anson or Amit or myself to approve so the PR can be merged.) 

Main will have CI/CD pipelines built up and unit tests when the project is appoaching to the end. 

Dev is not protected, you are asked to merged your topic branch to the dev first, and then test it on your station. 

Then merge the dev to the main to bring the changes from dev to the main. 

So the flow works like:

Topic Branch -> Dev -> Main

## Repo Pattern and design structure

### Presentation Layer

Will not be included at here since UI is developed in an individual repo. 

### User Service Layer

"Controllers:" REST api end points to allow front-end interactions.

### Application layer:

"Services": Controller based service. One controller could have one service, so the controller codes will be much cleaner and only cares about HTTP request related tasks.  

### Facade layer:

"Repository": C# people call this Repository layer. DB interaction should be centralized. A spcialized layer just for interacting with DB. 

### Persistence layer:

"Models": The files in models will reflect how the actual DB tables look like in the storage. DbContext will be placed in this folder too because it wires up the connections between C# classes and the actual DB tables. 



