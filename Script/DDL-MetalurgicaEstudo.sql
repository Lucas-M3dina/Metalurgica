CREATE DATABASE metalurgica_estudo;
GO

USE metalurgica_estudo;
GO

CREATE TABLE LM_TipoUsuario(
	Id_TipoUsuario INT PRIMARY KEY IDENTITY,
	Nm_Titulo VARCHAR(12),

	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO

CREATE TABLE LM_Usuario(
	Id_Usuario INT PRIMARY KEY IDENTITY,
	Id_TipoUsuario INT FOREIGN KEY REFERENCES LM_TipoUsuario(Id_TipoUsuario),
	Nm_Nome VARCHAR(50) NOT NULL,
	Ds_Email VARCHAR(80) NOT NULL UNIQUE,
	Ds_Senha VARCHAR(60) NOT NULL,

	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO

CREATE TABLE LM_Elemento(
	Id_Elemento INT PRIMARY KEY IDENTITY,
	Nm_Nome VARCHAR(50) NOT NULL,
	Ds_Especificacao VARCHAR(50) NOT NULL,
	Ds_ASTM VARCHAR(30) NOT NULL,

	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO

CREATE TABLE LM_Produto(
	Id_Produto INT PRIMARY KEY IDENTITY,
	Id_Elemento INT FOREIGN KEY REFERENCES LM_Elemento(Id_Elemento),
	Nm_Nome VARCHAR(50) NOT NULL,

	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO

CREATE TABLE LM_Embalagem(
	Id_Embalagem INT PRIMARY KEY IDENTITY,
	Nm_Nome VARCHAR(50) NOT NULL,

	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO


CREATE TABLE LM_Lote(
	Id_Lote INT PRIMARY KEY IDENTITY,
	Id_Produto INT FOREIGN KEY REFERENCES LM_Produto(Id_Produto),
	Id_Embalagem INT FOREIGN KEY REFERENCES LM_Embalagem(Id_Embalagem),


	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
GO

CREATE TABLE LM_Empresa(
	Id_Empresa INT PRIMARY KEY IDENTITY,
	Ds_Segmento VARCHAR(60) NOT NULL,
	Nm_Nome VARCHAR(50) NOT NULL,


	Dt_Cadastro	DATETIME NOT NULL,
	Dt_Alteracao DATETIME ,
	Fl_Ativo BIT NOT NULL,
	Ds_UltAlteracao VARCHAR(100)
);
