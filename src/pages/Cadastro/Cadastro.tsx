import { Button } from "../../components/Button/Button";
import { Input } from "../../components/Input/Input";
import { Container } from "../../components/StructureHome/Container";
import { LeftBox } from "../../components/StructureHome/LeftBox";
import { RightBox } from "../../components/StructureHome/RightBox";
import { Text } from "../../components/Text/Text";

export function Cadastro() {

  const teste = (e:React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log('teste')
  }

  return (
    <Container>
        <LeftBox path='/' content='Login'>
            <Text>Nossa plataforma foi desenvolvida para simplificar e otimizar o processo de gerenciamento de lotes e geração de certificados. Com recursos intuitivos e eficientes, estamos aqui para facilitar o seu trabalho.</Text>
            <Text>
Caso não tenha uma conta clique no botão abaixo e crie uma para acessar todas as funcionalidades disponíveis. Nossa interface simples e objetiva proporcionará uma experiência fluida e agradável durante toda a sua jornada.</Text>
        </LeftBox>

        <RightBox api={teste}>
            <Input.InputDefault moreClassName='input-login' labelInput='Email' placeholder='Digite seu email' type='email' required/>
            <Input.InputDefault moreClassName='input-login' labelInput='Senha' placeholder='Digite sua senha' type='password' required/>
            <Input.InputDefault moreClassName='input-login' labelInput='Confirmar Senha' placeholder='Digite sua novamente sua senha' type='password' required/>

            <Button.ButtonDefault content='Cadastrar' type='submit'/>
        </RightBox>
    </Container>
  )
}
