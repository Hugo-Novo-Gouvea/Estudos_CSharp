# 🚀 Jornada de Estudos .NET / C#

Este repositório documenta minha trajetória completa de aprendizado em **C# e .NET**, partindo da lógica de programação básica até a construção de um sistema bancário funcional com persistência de dados e Orientação a Objetos.

## 🛠️ Tecnologias e Ferramentas
* **Linguagem:** C# (C-Sharp)
* **Framework:** .NET 9.0
* **IDE:** Visual Studio Code
* **Formatos:** JSON (Persistência de Dados)

---

## 📚 Estrutura do Curso

O repositório está organizado em módulos progressivos:

### 🔹 Módulo 1: Fundamentos da Lógica
* **Aula 0-2:** Configuração de ambiente (`dotnet new`), Variáveis e Tipos primitivos (`int`, `string`, `bool`).
* **Aula 3:** Estruturas de Repetição (`while`, `for`) e Condicionais (`if/else`).
* **Aula 4:** Arrays e Listas (Gerenciando coleções de dados).

### 🔹 Módulo 2: Orientação a Objetos (POO)
* **Aula 5:** Introdução a Classes e Objetos (Moldes e Instâncias).
* **Aula 6:** Métodos, Atributos e Encapsulamento (`private`, `public`, `Properties`).
* **Aula 7:** Herança (Reaproveitamento de código e `base`).
* **Aula 8:** Polimorfismo, Classes Abstratas (`abstract`) e Interfaces (`Contracts`).

### 🔹 Módulo 3: C# Profissional
* **Aula 9:** Tratamento de Erros e Exceções (`Try/Catch/Finally`).
* **Aula 10:** Manipulação de Arquivos e Serialização **JSON** (`System.IO`, `System.Text.Json`).

---

## 🏆 Projeto Final: ByteBank

Nas **Aulas 11 e 12**, consolidei todo o conhecimento criando um sistema bancário completo.

### 📂 Estrutura do Projeto
O projeto utiliza uma arquitetura separada em camadas:
* `ByteBank/Modelos`: Contém as regras de negócio (`ContaBancaria`, `Cliente`, `ContaCorrente`).
* `ByteBank/Program.cs`: Contém a lógica de interação (Frontend no Console).

### ✨ Funcionalidades
1.  **Menu Interativo:** Navegação por opções numéricas.
2.  **Sistema de Login:** Validação de usuário via CPF.
3.  **Operações Bancárias:** Depósito, Saque (com taxas) e Transferências entre contas.
4.  **Persistência de Dados:** O sistema salva e lê as contas automaticamente em um arquivo `banco_dados.json`.
5.  **Tratamento de Erros:** O sistema não "crasha" se o usuário digitar dados inválidos.

---

## 🚀 Como Rodar
Para executar qualquer um dos projetos (ex: ByteBank), abra o terminal na pasta correspondente e rode:

```bash
cd ByteBank
dotnet run