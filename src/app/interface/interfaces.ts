export interface Token{
  token : string
}

export interface Usuario{
  idTipoUsuario : number,
  nome : string,
  email : string
}

export interface UserAlterar{
  nmNome : string,
  dsSenha : string,
  dsEmail : string,
}

export interface Lote{
  id_Lote : number,
  nm_MetodologiaAnaliseGranumetrica : string,
  ds_observacoes : string,
  nomeProduto : string,
  nomeEmbalagem : string,
  nomeEmpresa : string,
  dt_Cadastro : string,
}
