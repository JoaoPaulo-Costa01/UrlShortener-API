# 🔗 Encurtador de URL (URL Shortener API)

Este projeto é uma API para encurtamento de URLs, criada com o objetivo de dominar o uso de **Docker** e **Docker Compose** para gerenciar múltiplos containers (API e Banco) de forma integrada.

A aplicação permite gerar URLs curtas a partir de links originais, redirecionar usuários e listar todos os endereços cadastrados. Diferente de projetos tradicionais, este ambiente foi totalmente configurado para rodar via **Docker Compose**, eliminando a necessidade de instalar dependências locais como o SQL Server.

## 🚀 Tecnologias Utilizadas
![C#](https://img.shields.io/badge/C%23-12-purple.svg)
![ASP.NET](https://img.shields.io/badge/ASP.NET%20Core%20-8.0-orange.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet.svg)
![Docker](https://img.shields.io/badge/Docker-blue.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red.svg)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-green.svg)

* **C# 12**: Linguagem de programação moderna e fortemente tipada utilizada no projeto.
* **.NET 8**: Plataforma de desenvolvimento (Runtime) que oferece alta performance e suporte cross-platform.
* **ASP.NET Core**: Framework Web utilizado especificamente para construir a API RESTful e gerenciar as requisições HTTP.
* **Docker & Docker Compose**: Para containerização da API e do Banco de Dados, garantindo portabilidade.
* **SQL Server**: Banco de dados relacional (rodando em container Linux).
* **Entity Framework Core**: ORM utilizado para facilitar a manipulação de dados.
* **Nanoid**: Biblioteca para geração de identificadores únicos, curtos e seguros para as URLs.
* **Swagger (OpenAPI)**: Documentação interativa e testes dos endpoints.

## ✨ Funcionalidades (Endpoints da API)

A API expõe os seguintes métodos para manipulação das URLs:

### `[POST] /api/Url`
* **Descrição:** Recebe uma URL longa e gera um código encurtado único.
* **Corpo da Requisição:**
    ```json
    {
      "url_original": "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
    }
    ```
* **Retorno:** A URL completa encurtada (ex: `http://localhost:5000/api/Url/Ab3d9`).

### `[GET] /api/Url`
* **Descrição:** Retorna a lista de todas as URLs cadastradas no banco de dados.
* **Retorno:** Lista JSON contendo ID, URL Original e Código Curto.

### `[GET] /api/Url/{codigo}`
* **Descrição:** Recebe o código curto e **redireciona** o usuário para o site original.
* **Parâmetro:** `codigo` (string) - O identificador gerado (ex: `Ab3d9`).
* **Comportamento:** Retorna status `302 Found` e o navegador abre o site de destino.

## 🐳 Como rodar este projeto (Docker)

Você não precisa ter o .NET nem o SQL Server instalados. Basta ter o Docker instalado!

### Opção 1: Rodar compilando o código (Recomendado para Devs)
Clone o repositório e rode o comando:
```bash
docker-compose up
```
A API estará disponível em: http://localhost:5000/swagger

### Opção 2: Rodar apenas a API (Modo Visualização)
Se quiser apenas ver a interface (Swagger) sem baixar o código, use minha imagem pública.

Obs: Como este comando não sobe o banco de dados SQL Server junto, os endpoints retornarão erro de conexão. Para testar as funcionalidades, use a Opção 1.

``` bash
docker run -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development joaocosta19902/urlshortener-api:latest
```

### ⚙️ Desenvolvimento Local (Opcional)
Caso queira rodar pelo Visual Studio sem Docker:

* **Configuração:** Ajuste a Connection String no arquivo appsettings.json para apontar para o seu banco local (localhost).
* **Migrations:** Abra o terminal, navegue até a pasta do projeto (cd UrlShortener\UrlShortener) e rode o comando:
``` bash
dotnet ef database update
```

* **Play:** Inicie o projeto pelo Visual Studio.

# 👨🏾‍💻 Autor
João Paulo Estudante de Análise e Desenvolvimento de Sistemas focado em Backend com C# e .NET.
