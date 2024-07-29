# Microservices solution - "NextChapter"

A .NET and React/Next.js based solution implementing a website for selling used books using a services-based architecture. 
Despite its size, this app demonstrates my ability to integrate different tools and present an easily scalable solution.

![NextChapter architecture diagram](resources/nextchapter_architecture.png)

![NextChapter homepage screenshot](resources/nextchapter_homepage.png)

## About the solution

Each service was designed based on the clean architecture philosophy with CQRS design pattern for the communication between the different projects.<br />
At the solution level, four different protocol communication types were used:
 - REST: For the endpoints access of each services;
 - AMQP: An event bus with RabbitMQ as message broker for a more frequently, non coupled and asynchronous communication between services;
 - RPC: It is present a small case for direct communication between two services;
 - Websockets: A full duplex connection for real-time communication.

## Running the solution

- Clone the NextChapter repository: 
- [Install & start Docker Desktop](https://docs.docker.com/engine/install/)
- Open the command line and change the directory to the docker-compose.yml file directory.
- Run the following command:
```powershell
docker compose up -d
```
The website will be reachable at your localhost:3000. 

## Author
Pedro Nuno Miranda
