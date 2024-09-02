# Microservices solution - "NextChapter"

A .NET and React/Next.js based solution implementing a website for selling used books using a services-based architecture. 
Despite its size, this app demonstrates my ability to integrate different tools and present an easily scalable solution.

Goal:
![NextChapter architecture diagram](resources/nextchapter_architecture-goal.png)

Currently:
![NextChapter architecture diagram](resources/nextchapter_architecture-currently.png)

Home page:
![NextChapter homepage screenshot](resources/nextchapter_homepage.png)

## About the solution

Each service was designed based on the clean architecture philosophy with CQRS design pattern for the communication between the different projects.<br />
At the solution level, four different API protocol types were used:
 - REST: For the endpoints access of each services;
 - AMQP: An event bus with RabbitMQ as message broker for a more frequently, non coupled and asynchronous communication between services;
 - gRPC: For direct communication between two services;
 - Websockets: For a full duplex connection to achieve real-time communication.

### Services description



### Tools used



#### .NET tools



## Running the solution

- Clone the NextChapter repository: 
- [Install & start Docker Desktop](https://docs.docker.com/engine/install/)
- Open the command line and change the directory to the docker-compose.yml file directory.
- Run the following command:
```powershell
docker compose up -d
```
The website will be reachable at your localhost:3000. 

\* This solution is designed by default to integrate with my Cloudinary account so that it can store the uploaded photos by the users, but for obvious reasons I have set the solution to store the photos in the project's file system path. 

## About this repository

This is a repository where I try to put into practice all the new knowledge I gain. Much of the motivation for developing this training project came from online courses where I acquired knowledge, which, in one way or another—some more than others—helped me in different parts of this project. The courses were the following:
 - Build a Microservices app with .Net and Nexjs from scratch - Udemy, Neil Cummings (Completed on August 2024)
 - Complete guide to building an app with .Net Core and React - Udemy, Neil Cummings
 - React - The Complete Guide 2023 (incl. Next.js, Redux) - Udemy, Maximilian Schwarzmüller
 - Docker and Kubernetes: The Complete Guide - Udemy, Stephen Grider
 - C# COMPLETO Programação Orientada a Objectos + Projetos - Udemy, Nelio Alves (Completed on September 2021)
 - The Complete JavaScript Course 2021: From Zero to Expert! - Udemy, Jonas Schmedtmann (Completed on September 2021)

## Author
Pedro Nuno Miranda
