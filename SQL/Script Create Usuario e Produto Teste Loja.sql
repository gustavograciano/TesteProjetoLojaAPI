-- Script para criar as tabelas no banco de dados

-- Tabela Produto
CREATE TABLE Produto
(
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Preco DECIMAL(10, 2) NOT NULL,
    Quantidade INT NOT NULL
);

INSERT INTO Produto (Nome, Preco, Quantidade)
VALUES
    ('Camiseta', 29.99, 100),
    ('Calça Jeans', 59.99, 50),
    ('Tênis Esportivo', 79.99, 80),
    ('Mochila', 39.99, 30),
    ('Relógio', 99.99, 20);

-- Tabela Usuario
CREATE TABLE Usuario
(
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Senha NVARCHAR(100) NOT NULL,
    isAdmin BIT NOT NULL DEFAULT 0 -- 'isAdmin' será do tipo BIT (0 ou 1)
);

-- Tabela Pedido
CREATE TABLE Pedido (
    Id INT PRIMARY KEY IDENTITY,
    ProdutoId INT NOT NULL,
    Quantidade INT NOT NULL,
    UsuarioId NVARCHAR(100) NOT NULL,
    DataCompra DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);

