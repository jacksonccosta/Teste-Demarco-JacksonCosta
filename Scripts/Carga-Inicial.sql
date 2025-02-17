-- Cria o banco de dados
CREATE DATABASE Logistics;
GO

-- Usa o banco de dados criado
USE Logistics;
GO

-- Cria a tabela de Usuários
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID único do usuário
    Name NVARCHAR(100) NOT NULL, -- Nome do usuário
    Email NVARCHAR(100) NOT NULL UNIQUE, -- E-mail do usuário (único)
    Password NVARCHAR(100) NOT NULL, -- Senha do usuário (deve ser armazenada como hash em produção)
    Role NVARCHAR(50) NOT NULL DEFAULT 'User' -- Papel do usuário (Admin, User, etc.)
);
GO

-- Cria a tabela de Pedidos (Orders)
CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID único do pedido
    Number INT NOT NULL UNIQUE, -- Número do pedido (único)
    Description NVARCHAR(255), -- Descrição do pedido
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de criação do pedido
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Data de atualização do pedido
    UserId UNIQUEIDENTIFIER NOT NULL, -- ID do usuário que criou o pedido
    FOREIGN KEY (UserId) REFERENCES Users(Id) -- Chave estrangeira para a tabela Users
);
GO

-- Cria a tabela de Entregas (OrderDeliveries)
CREATE TABLE OrderDeliveries (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- ID único da entrega
    OrderId UNIQUEIDENTIFIER NOT NULL, -- ID do pedido associado
    DeliveryDate DATETIME NOT NULL, -- Data de entrega
    Status NVARCHAR(50) NOT NULL, -- Status da entrega (Entregue, Pendente, etc.)
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) -- Chave estrangeira para a tabela Orders
);
GO

-- Insere um usuário administrador padrão (login: admin, senha: admin)
INSERT INTO Users (Id, Name, Email, Password, Role)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    'Administrador', -- Nome do usuário
    'admin@logistics.com', -- E-mail do administrador
    'admin', -- Senha (em produção, use um hash seguro como BCrypt)
    'Admin' -- Papel do usuário
);
GO

-- Exemplo de inserção de um pedido
INSERT INTO Orders (Id, Number, Description, UserId)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    1001, -- Número do pedido
    'Pedido de materiais de construção', -- Descrição do pedido
    (SELECT Id FROM Users WHERE Email = 'admin@logistics.com') -- ID do usuário admin
);
GO

-- Exemplo de inserção de uma entrega
INSERT INTO OrderDeliveries (Id, OrderId, DeliveryDate, Status)
VALUES (
    NEWID(), -- Gera um novo GUID para o ID
    (SELECT Id FROM Orders WHERE Number = 1001), -- ID do pedido associado
    '2023-10-30 10:00:00', -- Data de entrega
    'Pendente' -- Status da entrega
);
GO