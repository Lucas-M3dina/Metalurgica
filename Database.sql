IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Metalurgica')
BEGIN
    CREATE DATABASE Metalurgica;
END;
GO

USE Metalurgica;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cargo]') AND type in (N'U'))
BEGIN
    CREATE TABLE Cargo(
        Id_Cargo			INT				PRIMARY KEY IDENTITY(1,1),
        Ds_Cargo			VARCHAR(200)	NOT NULL,
        Fl_Ativo			BIT				NOT NULL,
        Dt_Criacao			DATETIME		NOT NULL,
        Dt_Alteracao		DATETIME		NULL,
        Ds_Alteracao		VARCHAR(200)	NULL
    );

	INSERT INTO Cargo (Ds_Cargo, Fl_Ativo, Dt_Criacao, Dt_Alteracao, Ds_Alteracao)
	VALUES 
		('Administrador', 1, GETDATE(), NULL, NULL),
		('Analista', 1, GETDATE(), NULL, NULL);

END;
GO 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE Usuario(
        Id_Usuario		INT PRIMARY KEY IDENTITY(1,1),
        Id_Cargo		INT				NOT NULL,
        Ds_Nome			VARCHAR(200)	NOT NULL,
        Ds_Senha		VARCHAR(200)	NOT NULL,
        Ds_Email		VARCHAR(200)	NOT NULL,
        Fl_Ativo		BIT				NOT NULL,
        Dt_Criacao		DATETIME		NOT NULL,
        Dt_Alteracao	DATETIME		NULL,
		Ds_Alteracao	VARCHAR(200)	NULL,

		CONSTRAINT FK_Usuario_Cargo FOREIGN KEY (Id_Cargo) REFERENCES Cargo(Id_Cargo)
    );

	INSERT INTO Usuario (Id_Cargo, Ds_Nome, Ds_Senha, Ds_Email, Fl_Ativo, Dt_Criacao, Dt_Alteracao, Ds_Alteracao) 
	VALUES (
		1, 
		'Lucas Medina', 
		'$2a$11$pk3lC6XodTzjhmminoCyXOAYIlEG7ekyzpty04POvb56j/J0ce1je', 
		'lucas.m3dina@gmail.com', 
		1, 
		GETDATE(), 
		NULL, 
		NULL
	);

END;
GO 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Produto]') AND type in (N'U'))
BEGIN
    CREATE TABLE Produto(
        Id_Produto			INT PRIMARY KEY IDENTITY(1,1),
        Ds_Nome				VARCHAR(200)	NOT NULL,
        Ds_Descricao		VARCHAR(200)	NOT NULL,
        Ds_Especificacao	VARCHAR(MAX)	NOT NULL,
        Dt_Emissao			DATETIME		NULL,
        Nr_Validade			INT				NULL,
        Nr_Versao			INT				NULL,
        Ds_Io				VARCHAR(200)	NULL,
        Ds_Setor			VARCHAR(200)	NULL,
        Ds_Especie			VARCHAR(200)	NULL,

        Fl_Ativo			BIT				NOT NULL,
        Dt_Criacao			DATETIME		NOT NULL,
        Dt_Alteracao		DATETIME		NULL,
		Ds_Alteracao		VARCHAR(200)	NULL,
    );
END;
GO 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Embalagem]') AND type in (N'U'))
BEGIN
    CREATE TABLE Embalagem(
        Id_Embalagem			INT				PRIMARY KEY IDENTITY(1,1),
   		Ds_Nome					VARCHAR(200)	NOT NULL,

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
    );
END;
GO 


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProdutoEmbalagem]') AND type in (N'U'))
BEGIN
    CREATE TABLE ProdutoEmbalagem(
		Id_ProdutoEmbalagem	INT PRIMARY KEY IDENTITY(1,1),
        Id_Embalagem		INT				NOT NULL,
        Id_Produto			INT				NOT NULL,
        Nr_Quantidade		INT				NOT NULL,

        Fl_Ativo			BIT				NOT NULL,
        Dt_Criacao			DATETIME		NOT NULL,
        Dt_Alteracao		DATETIME		NULL,
		Ds_Alteracao		VARCHAR(200)	NULL,

		CONSTRAINT FK_ProdutoEmbalagem_Produto	 FOREIGN KEY (Id_Produto)	REFERENCES Produto(Id_Produto),
		CONSTRAINT FK_ProdutoEmbalagem_Embalagem FOREIGN KEY (Id_Embalagem) REFERENCES Embalagem(Id_Embalagem)

    );
END;
GO 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quesito]') AND type in (N'U'))
BEGIN
    CREATE TABLE Quesito(
        Id_Quesito				INT				PRIMARY KEY IDENTITY(1,1),
		Nr_Codigo				INT				NOT NULL,
   		Ds_Descricao			VARCHAR(200)	NOT NULL,

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
    );
END;
GO 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProdutoQuesito]') AND type in (N'U'))
BEGIN
    CREATE TABLE ProdutoQuesito(
        Id_ProdutoQuesito		INT				PRIMARY KEY IDENTITY(1,1),
        Id_Quesito				INT				NOT NULL,
		Id_Produto				INT				NOT NULL,
   		Vl_Ideal				DECIMAL			NOT NULL,
		Vl_Minimo				DECIMAL			NOT NULL,
		Vl_Maximo				DECIMAL			NOT NULL,

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
		CONSTRAINT FK_ProdutoQuesito_Produto	FOREIGN KEY (Id_Produto)	REFERENCES Produto(Id_Produto),
		CONSTRAINT FK_ProdutoQuesito_Quesito	FOREIGN KEY (Id_Quesito)	REFERENCES Quesito(Id_Quesito)
    );
END;
GO 



select * from Produto
ALTER TABLE ProdutoQuesito ADD Ds_Ideal DECIMAL NULL;
UPDATE ProdutoQuesito SET Ds_Ideal = 0.00 WHERE Ds_Ideal IS NULL;
ALTER TABLE ProdutoQuesito ALTER COLUMN Ds_Ideal DECIMAL NOT NULL;

