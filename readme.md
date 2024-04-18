SuperHeroAPI (.NET 8) - Simple Web API for Superheroes
This project is a basic Web API built with ASP.NET Core (.NET 8) that allows you to manage a collection of superheroes. It leverages SQL Server as the underlying database for data persistence.

Features:

Get a list of all superheroes
Get a single superhero by ID
Add a new superhero
Update an existing superhero
Delete a superhero
Getting Started

Clone or download the repository.
Install the required dependencies using dotnet restore.
Configure your connection string to SQL Server in the application settings.
Run the application using dotnet run.
API Endpoints

GET /api/SuperHero/GetAll: Retrieves a list of all superheroes.
GET /api/SuperHero/GetOne?id={id}: Retrieves a single superhero by ID.
POST /api/SuperHero/Add: Creates a new superhero. The request body should be a JSON object representing the SuperHeroAddDto class.
PUT /api/SuperHero/Update: Updates an existing superhero. The request body should be a JSON object representing the entire SuperHero class.
DELETE /api/SuperHero/Delete?id={id}: Deletes a superhero by ID.
Note: This is a basic example and doesn't include functionalities like authentication or error handling for brevity.


PORTUGUÊS:

SuperHeroAPI (.NET 8) - API Web Simples para Super-Heróis
Este projeto é uma API Web básica construída com ASP.NET Core (.NET 8) que permite gerenciar uma coleção de super-heróis. Ele utiliza o SQL Server como banco de dados subjacente para persistência de dados.

Recursos:

Obter uma lista de todos os super-heróis
Obter um único super-herói por ID
Adicionar um novo super-herói
Atualizar um super-herói existente
Excluir um super-herói
Introdução

Clone ou baixe o repositório.
Instale as dependências necessárias usando dotnet restore.
Configure sua string de conexão com o SQL Server nas configurações do aplicativo.
Execute a aplicação usando dotnet run.
Endpoints da API

GET /api/SuperHero/GetAll: Recupera uma lista de todos os super-heróis.
GET /api/SuperHero/GetOne?id={id}: Recupera um único super-herói por ID.
POST /api/SuperHero/Add: Cria um novo super-herói. O corpo da requisição deve ser um objeto JSON representando a classe SuperHeroAddDto.
PUT /api/SuperHero/Update: Atualiza um super-herói existente. O corpo da requisição deve ser um objeto JSON representando a classe SuperHero completa.
DELETE /api/SuperHero/Delete?id={id}: Exclui um super-herói por ID.
Observação: Este é um exemplo básico e não inclui funcionalidades como autenticação ou tratamento de erros para fins de brevidade.