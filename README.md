# 🛠️ Desafio Anéis do Poder - Full Stack Application

Esta é a conclusão do **Desafio Anéis do Poder**, uma aplicação Full Stack desenvolvida com **.NET Core e Razor Pages** no frontend e no backend e **SQLServer** como banco de dados. Este projeto é encapsulado e pode ser executado localmente com **Docker Compose**.

---

## 🚀 Funcionalidades

1. **CRUD de Anéis**:
   - Criação, leitura, edição e exclusão de anéis do poder.
   - Restrições específicas para criação baseadas no "forjador".
2. **Frontend**:
   - Interface moderna desenvolvida com Razor Pages e BootStrap.
   - Design responsivo e interativo.
3. **Backend**:
   - API REST desenvolvida com .NET Core 8.0.
   - Documentação Swagger integrada.
4. **Banco de Dados**:
   - Configuração com SQL Server.

---

## 📦 Estrutura do Projeto

```plaintext
.
├── Backend/                  # Backend da aplicação
│   ├── Backend.sln           # Solução .NET
│   ├── Backend.csproj        # Projeto .NET
│   ├── Dockerfile            # Dockerfile do backend
│   ├── Controllers/          # Lógica de APIs
│   ├── Models/               # Modelos de dados
│   ├── Data/                 # Configuração do banco de dados
│   └── Program.cs            # Configuração inicial do projeto
│
├── Frontend/                 # Frontend da aplicação
│   ├── Dockerfile            # Dockerfile do frontend
│   ├── Pages/                # Páginas Razor
│   └── Program.cs            # Configuração inicial do frontend
│
└── docker-compose.yml        # Orquestração dos containers

```
## 🖥️ Tecnologias Utilizadas
### Frontend
- Razor Pages
- Bootstrap
### Backend
- .NET CORE 8.0
- Swagger
### Banco de Dados
- SQL SERVER
### Containerização
- Docker
- Docker-compose
## 🖥️ Pré-requisitos
1. Instalar o Docker e Docker Compose

2. Clone o Repositório
```plaintext
git clone https://github.com/Alvarezpro87/Desafio-aneis-do-Poder.git
```
## 🛠️ Como Executar o Projeto Localmente

1. Subir os containers

```plaintext
docker-compose up -d --build

```
2. Acessar os serviços

- Frontend: http://localhost:8082
- Backend (API): http://localhost:8081/api/Aneis

## 🧪 Testes
1. Teste manual de criação, edição e remoção de anéis.
2. Teste de conectividade entre os containers usando docker-compose.
   
