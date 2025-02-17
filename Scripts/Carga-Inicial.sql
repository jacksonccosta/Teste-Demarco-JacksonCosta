-- Cria o banco de dados
CREATE DATABASE Logistics;
GO

-- Usa o banco de dados criado
USE Logistics;
GO

-- Cria a tabela de Usu�rios
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID �nico do usu�rio
    Name NVARCHAR(100) NOT NULL, -- Nome do usu�rio
    Email NVARCHAR(100) NOT NULL UNIQUE, -- E-mail do usu�rio (�nico)
    Password NVARCHAR(100) NOT NULL, -- Senha do usu�rio (deve ser armazenada como hash em produ��o)
    Role NVARCHAR(50) NOT NULL DEFAULT 'User' -- Papel do usu�rio (Admin, User, etc.)
);
GO

-- Cria a tabela de Pedidos (Orders)
CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID �nico do pedido
    Number INT NOT NULL UNIQUE, -- N�mero do pedido (�nico)
    Description NVARCHAR(255), -- Descri��o do pedido
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de cria��o do pedido
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de atualiza��o do pedido
    UserId UNIQUEIDENTIFIER NOT NULL, -- ID do usu�rio que criou o pedido
    FOREIGN KEY (UserId) REFERENCES Users(Id) -- Chave estrangeira para a tabela Users
);
GO

-- Cria a tabela de Entregas (OrderDeliveries)
CREATE TABLE OrderDeliveries (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID �nico da entrega
    OrderId UNIQUEIDENTIFIER NOT NULL, -- ID do pedido associado
    DeliveryDate DATETIME NOT NULL, -- Data de entrega
    Status NVARCHAR(50) NOT NULL, -- Status da entrega (Entregue, Pendente, etc.)
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) -- Chave estrangeira para a tabela Orders
);
GO

-- Insere um usu�rio administrador padr�o (login: admin, senha: admin)
INSERT INTO Users (Id, Name, Email, Password, Role)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    'Administrador', -- Nome do usu�rio
    'admin@logistics.com', -- E-mail do administrador
    'admin', -- Senha (em produ��o, use um hash seguro como BCrypt)
    'Admin' -- Papel do usu�rio
);
GO

-- Exemplo de inser��o de um pedido
INSERT INTO Orders (Id, Number, Description, UserId)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    1001, -- N�mero do pedido
    'Pedido de materiais de constru��o', -- Descri��o do pedido
    (SELECT Id FROM Users WHERE Email = 'admin@logistics.com') -- ID do usu�rio admin
);
GO

-- Exemplo de inser��o de uma entrega
INSERT INTO OrderDeliveries (Id, OrderId, DeliveryDate, Status)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    (SELECT Id FROM Orders WHERE Number = 1001), -- ID do pedido associado
    '2023-10-30 10:00:00', -- Data de entrega
    'Pendente' -- Status da entrega
);
GO