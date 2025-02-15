# Teste Demarco - Desenvolvedor(a) Full Stack - .NET Framework Sênior | Jackson C. Costa
## TechsysLog - Controle de Pedidos e Entregas

Sistena desenvolvido em forma de teste, de uma aplicação para simular o controle de pedidos e entregas. A aplicação está dividida em uma API (Back-End) construída com uma arquitetura que simula um cenário comum, de um sistema escalável e com um código robusto que segue alguns Design Patterns de boas práticas de programação. 
O Front-End conta com uma aplicação simples desenvolvida em Angular, com dois módulos básicos: Lista de Pedidos e Cadastro de Pedido, estando ela preparada para implementações de novas funcionalidades de forma fácil. Isso porque todo código foi desenvolvido de forma simples para uma fácil compreensão de outros programadores.

## FRONT-END
- Angular 14
- SignalR
- Gestão de token JWT

## BACK-END
- .NET 8
- Padrão CQRS
- FluentValidation
- RestSharp
- Aplicado os conceitos de DDD e SOLID.
- Integração com api da ViaCEP para consulta de logradouros

#BANCO DE DADOS
- SQL Server

## COMO EXECUTAR

### BANCO DE DADOS
- Executar o Script: Carga-Inicial.sql que consta na pasta Script do repositório.

### BACK-END
- Configurar Instância, usuário e senha do SQL na ConnectionString do arquivo appsettings.json.
- Executar a aplicação no VS.

### FRONT-END
- Navegar até a pasta fron-tend.
- Executar no terminal o comando `npm install`.
- Referenciar seu backend no arquivo `environment.ts`.
- Executar o comando `ng serve` para iniciar a aplicação.
