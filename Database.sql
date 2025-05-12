IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Metalurgica')
BEGIN
    CREATE DATABASE Metalurgica;
END;

USE Metalurgica;

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
		'$2a$11$RV3BWR1u7HlM/FbL8zr5u.KHgGwniHpZoCgByjgk/zsOaOUhv/D4K', 
		'lucas.m3dina@gmail.com', 
		1, 
		GETDATE(), 
		NULL, 
		NULL
	);

END;

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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quesito]') AND type in (N'U'))
BEGIN
    CREATE TABLE Quesito(
        Id_Quesito				INT				PRIMARY KEY IDENTITY(1,1),
		Nr_Codigo				INT				NOT NULL,
   		Ds_Descricao			VARCHAR(200)	NOT NULL,
   		Ds_Metodo  				VARCHAR(200)	NOT NULL,
   		Ds_Unidade 				VARCHAR(200)	NOT NULL,
   		Ds_TipoQuesito			VARCHAR(200)	NOT NULL,

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
    );
        
        INSERT INTO dbo.Quesito
    (Nr_Codigo, Ds_Descricao, Ds_Metodo, Ds_Unidade, Ds_TipoQuesito, Fl_Ativo, Dt_Criacao, Dt_Alteracao, Ds_Alteracao)
		VALUES
		    (10,  'ALUMÍNIO (AL)',                               'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (100, 'MANGANÊS (MN)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (101, 'MANGANÊS (MN)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (102, 'MANGANÊS (MN)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (11,  'ALUMÍNIO (AL)',                               'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (110, 'COBALTO (CO)',                                 'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (120, 'NÍQUEL (NI)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (121, 'NÍQUEL (NI)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (130, 'CHUMBO (PB)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (140, 'MOLIBDÊNIO (MO)',                             'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (150, 'CROMO (CR)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (151, 'CROMO (CR)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (160, 'H2 LOSS (O)',                                 'I.S.O 15351:1999 E','%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (161, 'OXIGENIO',                                     'I.S.O 15351:1999 E','%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (170, 'DENSIDADE APARENTE',                          'ASTM B 329-90',     'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (171, 'DENSIDADE APARENTE',                          'I.S.O3923-1:1979',  'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (172, 'DENSIDADE APARENTE',                          'MF 80.004 REV. 2',  'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (173, 'DENSIDADE APARENTE',                          'I.S.O3923-1:1979',  'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (180, 'ESCOAMENTO',                                   'I.S.O 4490:2001',   'S/50G','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (181, 'ESCOAMENTO',                                   'I.S.O 4490:2001',   'S/50G','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (190, 'COMPRESSIBILIDADE À 500 MPA',                 'ASTM E 331-85',     'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (195, 'COMPRESSIBILIDADE À 600 MPA',                 'I.SO 3927:2001',    'G/CM3','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (20,  'FERRO (FE)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (200, 'RESISTÊNCIA À VERDE À 6G/CM3',               'ASTM B 312-82',     'MPA',  'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (21,  'FERRO (FE)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (210, 'FE2O3',                                       'ASTM E 415-85',     '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (22,  'FERRO (FE)',                                  'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (220, 'ÁCIDO GRAXO',                                 'ISO/DIS 4495-78',   '%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (230, 'ÁCIDO ESTEÁRICO',                            'ISO/DIS 4495-78',   '%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (240, 'ÁCIDO ISOESTEÁRICO',                         'ISO/DIS 4495-78',   '%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (250, 'COBERTURA EM ÁGUA',                          'ASTM D 480-70',     'CM2/G','PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (260, 'REATIVIDADE',                                 'M.62.L004 REV. 2',  'MINUTOS','PROPRIEDADES FISICAS',1, GETDATE(), NULL, NULL),
		    (270, 'ENSAIO DE EXPANSÃO (NORMA INTERNA)',         'HOGANAS IO 046/121','%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (280, 'ALCALINIDADE COMO MG (OH) 2',                'HOGANAS IO 046/121','%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (290, 'MATERIAL NÃO VOLÁTIL',                       'HOGANAS IO 046/121','%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (30,  'CARBONO (C)',                                'I.S.O 15350:2000',  '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (300, 'MATERIAL GRAXO EXTRAÍVEL',                   'HOGANAS IO 046/121','%',    'PROPRIEDADES FISICAS', 1, GETDATE(), NULL, NULL),
		    (31,  'CARBONO (C)',                                'I.S.O 15350:2000',  '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (310, '+  MALHA    5 (4,000 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (320, '+ MALHA   10 (2,000 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (326, '+MALHA  20 (0,840 MM)',                      'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (330, '+ MALHA   14 (1,400 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (340, '+ MALHA   25 (0,710 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (350, '+ MALHA   35 (0,500 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (360, '+ MALHA   40 (0,425 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (365, '+ MALHA   50 (0,300 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (370, '+ MALHA   60 (0,250 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (380, '+ MALHA   70 (0,212 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (381, '+MALHA 70 (0,212MM)',                        'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (390, '+ MALHA   80 (0,180 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (395, '- MALHA   80 (0,180 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (397, '+MALHA 80 (0,180MM) - MALHA 70 (0,212 MM)',  'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (399, '+MALHA 100 (0,150 MM) - MALHA 80 (0,180 MM)','I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (40,  'ENXOFRE (S)',                               'I.S.O 15350:2000',  '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (400, '+ MALHA 100 (0,150 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (401, '+MALHA 100 (0,150 MM) - MALHA 70 (0,212 MM)','I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (403, '+ MALHA 120 (0,125 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (405, '+MALHA 140 (0,106 MM) - MALHA 100 (0,150 MM)','I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (406, '+ MALHA 140 (0,106 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (408, '+ MALHA 230 (0,063 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (409, '+MALHA 200 (0,075 MM) - MALHA 140 (0,106 MM)','I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (410, '+ MALHA 200 (0,075 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (415, '+MALHA 325 (0,045 MM) - MALHA 200 (0,075 MM)','I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (420, '+ MALHA 325 (0,045 MM)',                    'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (470, '- MALHA   10 (2,000 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (480, '- MALHA   14 (1,400 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (490, '- MALHA   50 (0,300 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (50,  'SILÍCIO (SI)',                              'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (500, '- MALHA  100 (0,150 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (51,  'SILÍCIO (SI)',                              'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (510, '- MALHA  200 (0,075 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (52,  'SILÍCIO (SI)',                              'ASTM E 350-90',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (520, '- MALHA  325 (0,045 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (521, '-MALHA 325 (0,045MM)',                      'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (530, '- MALHA   80 (0,180 MM)',                   'I.S.O 4497:1983',   '%',    'GRANULOMETRIA',       1, GETDATE(), NULL, NULL),
		    (60,  'COBRE (CU)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (61,  'COBRE (CU)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (62,  'COBRE (CU)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (70,  'FÓSFORO (P)',                               'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (701, 'FERRO',                                     'ASTM E 415-85',     '<nulo>','COMPOSIÇÃO QUÍMICA',1, GETDATE(), NULL, NULL),
		    (71,  'FÓSFORO (P)',                               'ASTM E 1070-85',    '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (80,  'ZINCO (ZN)',                                'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (90,  'MAGNÉSIO (MG)',                             'ASTM E 415-85',     '%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL),
		    (950, 'O-TOT',                                     'I.S.O 15351:1999 E','%',    'COMPOSIÇÃO QUÍMICA', 1, GETDATE(), NULL, NULL);
END;

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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lote]') AND type in (N'U'))
BEGIN
    CREATE TABLE Lote(
        Id_Lote					INT				PRIMARY KEY IDENTITY(1,1),
		Id_Produto				INT				NOT NULL,
   		Ds_Identificador		VARCHAR(200)	NULL,
		Dt_Fabricacao			DATETIME		NULL,
		Ds_Nome					VARCHAR(200)	NULL,
		Ds_Validador			VARCHAR(200)	NULL,
		Dt_Validade				DATETIME		NULL,

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
		CONSTRAINT FK_Lote_Produto	FOREIGN KEY (Id_Produto)	REFERENCES Produto(Id_Produto),
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Certificado]') AND type in (N'U'))
BEGIN
    CREATE TABLE Certificado(
        Id_Certificado			INT				PRIMARY KEY IDENTITY(1,1),
		Id_Lote					INT				NOT NULL,
   		Ds_NotaFiscal			VARCHAR(200)	NULL,
   		Ds_Cliente				VARCHAR(200)	NULL,
   		Vl_Peso					DECIMAL			NULL,
   		

        Fl_Ativo				BIT				NOT NULL,
        Dt_Criacao				DATETIME		NOT NULL,
        Dt_Alteracao			DATETIME		NULL,
		Ds_Alteracao			VARCHAR(200)	NULL,
		CONSTRAINT FK_Certificado_Lote	FOREIGN KEY (Id_Lote) REFERENCES Lote(Id_Lote)
    );
END;


select * from embalagem