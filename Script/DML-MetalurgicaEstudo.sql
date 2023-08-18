INSERT INTO Lm_TipoUsuario(Nm_Titulo, Dt_Cadastro, Fl_Ativo)
VALUES ('adm', '2023-01-01', 1), ('colaborador','2023-01-01', 1)

SELECT * FROM LM_TipoUsuario

SELECT * FROM LM_Elemento

SELECT * FROM LM_Produto

SELECT * FROM LM_Usuario

SELECT * FROM LM_Embalagem

SELECT * FROM LM_Empresa

SELECT * FROM LM_Lote

SELECT LM_Lote.Id_Lote,LM_Lote.Dt_Cadastro, LM_Lote.Nm_MetodologiaAnaliseGranumetrica, LM_Lote.Ds_observacoes, LM_Produto.Nm_Nome AS NomeProduto, LM_Embalagem.Nm_Nome AS NomeEmbalagem, LM_Empresa.Nm_Nome AS NomeEmpresa FROM LM_Lote 
INNER JOIN LM_Produto ON LM_Produto.Id_Produto = LM_Lote.Id_Produto
INNER JOIN LM_Embalagem ON LM_Embalagem.Id_Embalagem = LM_Lote.Id_Embalagem
INNER JOIN LM_Empresa ON LM_Empresa.Id_Empresa = LM_Lote.Id_Empresa
where LM_Lote.Id_Lote = 4


