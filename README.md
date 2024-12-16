# Desafio Fullstack: A Forja dos Anéis de Poder
_One Challenge to rule them all, One Challenge to find them, One Challenge to bring them all, and in the darkness bind them_

## 💍 Contexto do Desafio

O grande mago J.R.R. Tolkien nos deixou a famosa frase:

> **Three Rings for the Elven-kings under the sky,  
> Seven for the Dwarf-lords in their halls of stone,  
> Nine for Mortal Men doomed to die,  
> One for the Dark Lord on his dark throne  
> In the Land of Mordor where the Shadows lie.  
> One Ring to rule them all, One Ring to find them,  
> One Ring to bring them all, and in the darkness bind them  
> In the Land of Mordor where the Shadows lie.**

Sua missão será criar um CRUD (Create, Read, Update, Delete) para gerenciar os anéis e desenvolver um frontend para visualizar e manipular essas informações.

---

## 🎯 Objetivo

Você irá construir:
1. **Backend** em **.Net Core** para fornecer APIs REST.
2. **Frontend** com **Razor Pages** para a interface do usuário.

---

## ⚙️ Funcionalidades

### Backend

1. **Criar um Anel**  
   API para registrar um novo anel com as propriedades:
   - `Nome`: Nome do anel.
   - `Poder`: Breve descrição do poder do anel.
   - `Portador`: Nome do portador atual.
   - `ForjadoPor`: Quem forjou o anel.
   - `Imagem`: URL de uma imagem representando o anel.

2. **Validações**  
   - Máximo de 3 anéis para Elfos.
   - Máximo de 7 anéis para Anões.
   - Máximo de 9 anéis para Homens.
   - Apenas 1 anel para Sauron.

3. **Listar os Anéis**  
   Retorna uma lista de todos os anéis cadastrados.

4. **Atualizar um Anel**  
   Permite modificar as propriedades de um anel existente.

5. **Deletar um Anel**  
   Remove um anel pelo seu identificador.

---

### Frontend

1. **Tela de Criação/Atualização de Anel**  
   - Um formulário com os seguintes campos:
     - `nome`: Campo de texto para o nome do anel.
     - `poder`: Campo de texto para a descrição do poder do anel.
     - `portador`: Campo de texto para o nome do portador.
     - `forjadoPor`: Campo de texto para indicar quem forjou o anel.
     - `imagem`: Como a imagem vai ser genérica você pode tanto deixar o uauário escolher entre as imagens que o próprio sistema fornece ou remover esse campo e deixar uma imagem default.
   - Botões para:
     - **Criar**: Submeter o formulário para criar um novo anel.
     - **Atualizar**: Alterar as informações de um anel existente.

2. **Tela de Visualização dos Anéis**
   - Exibir todos os anéis em um **carrossel** (ou grid), mostrando:
     - Nome, poder, portador, forjadoPor, e a imagem do anel.
   - O carrossel deve ser responsivo e permitir rolar entre os anéis cadastrados.
   - Adicionar a possibilidade de **excluir** ou **editar** um anel diretamente dessa tela.

---

## 🚀 Tecnologias Recomendadas

- **Backend**:
  - **.Net Core 6+**
  - **Entity Framework** (para acesso ao banco de dados)
  - **SQL Server** ou **MongoDb** (para banco de dados)

- **Frontend**:
  - **Razor Pages** para construção de interfaces dinâmicas.
  - **Bootstrap** (ou outra biblioteca CSS) para estilização.

---

## 🛠️ Instruções

1. **Configuração do Backend**:
   - Crie um projeto **.Net Core** para API.
   - Configure o Entity Framework e migrações para gerenciar o banco de dados.
   - Crie os endpoints para gerenciar os anéis.

2. **Configuração do Frontend**:
   - Crie um projeto com **Razor Pages**.
   - Implemente a comunicação com a API.
   - Configure o layout e navegação entre as telas.

3. **Execução**:
   - Configure o banco de dados.
   - Execute o backend e frontend simultaneamente.
   - Acesse o sistema pelo navegador.

---

## 📝 Critérios de Avaliação

1. **Código Limpo e Bem Estruturado**.
2. **Funcionalidades Completas** (CRUD).
3. **Validação das Regras de Negócio**.
4. **Interface Intuitiva e Responsiva**.

Boa sorte, aventureiro! Que o poder esteja com você!
