# 💊 Controle de Medicamentos - Biblioteca C#

Biblioteca em *C# (.NET Class Library)* para gerenciamento de *medicamentos, pacientes, fornecedores, prescrições, estoque e funcionários*.  
Ela fornece classes, regras de negócio e serviços que podem ser integrados em sistemas hospitalares, clínicas e farmácias.

---

## 📖 Sumário
- [Sobre a Biblioteca](#-sobre-a-biblioteca)
- [Módulos e Requisitos](#-módulos-e-requisitos)
  - [Fornecedores](#1-módulo-de-fornecedores)
  - [Pacientes](#2-módulo-de-pacientes)
  - [Medicamentos](#3-módulo-de-medicamentos)
  - [Funcionários](#4-módulo-de-funcionários)
  - [Prescrições Médicas](#5-módulo-de-prescrições-médicas)
  - [Estoque](#6-módulo-de-estoque)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Instalação](#-instalação)
- [Exemplo de Uso](#-exemplo-de-uso)
- [Testes](#-testes)
- [Contribuição](#-contribuição)
- [Licença](#-licença)

---

## 📌 Sobre a Biblioteca
O *Controle de Medicamentos* foi desenvolvido para atender cenários de *gestão hospitalar* e *controle farmacêutico*, garantindo que pacientes, fornecedores, medicamentos e prescrições sejam devidamente registrados e controlados.

Inclui:
- Validações de regras de negócio
- Serviços para manipulação de entidades
- Operações de estoque (entrada e saída de medicamentos)

---

## 🧩 Módulos e Requisitos

### 1. Módulo de Fornecedores
*Funcionalidades*
- Registrar, visualizar, editar e excluir fornecedores.  

*Regras de Negócio*
- Nome obrigatório (3–100 caracteres)  
- Telefone válido  
- CNPJ (14 dígitos, único)  

---

### 2. Módulo de Pacientes
*Funcionalidades*
- Registrar, visualizar, editar e excluir pacientes.  

*Regras de Negócio*
- Nome obrigatório (3–100 caracteres)  
- Telefone válido: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX  
- Cartão SUS (15 dígitos, único)  
- CPF (11 dígitos)  

---

### 3. Módulo de Medicamentos
*Funcionalidades*
- Registrar, visualizar, editar e excluir medicamentos.  

*Regras de Negócio*
- Nome obrigatório (3–100 caracteres)  
- Descrição (5–255 caracteres)  
- Quantidade em estoque (número positivo)  
- Associação obrigatória com fornecedor  
- Medicamentos com menos de 20 unidades = *"em falta"*  
- Atualização automática do estoque em caso de novo registro existente  

---

### 4. Módulo de Funcionários
*Funcionalidades*
- Registrar, visualizar, editar e excluir funcionários.  

*Regras de Negócio*
- Nome obrigatório (3–100 caracteres)  
- Telefone válido  
- CPF (11 dígitos, único)  

---

### 5. Módulo de Prescrições Médicas
*Funcionalidades*
- Registrar novas prescrições médicas  
- Gerar relatórios de prescrições  

*Regras de Negócio*
- CRM do médico (6 dígitos)  
- Paciente obrigatório  
- Data válida  
- Lista de medicamentos (dosagem e período)  
- Requisições de saída exigem prescrição válida  

---

### 6. Módulo de Estoque
#### Requisições de Entrada
- Registrar e visualizar requisições de entrada  

*Regras*
- Data válida  
- Medicamento obrigatório  
- Funcionário obrigatório  
- Quantidade positiva  
- Atualização de estoque automática  

#### Requisições de Saída
- Registrar e visualizar requisições de saída  

*Regras*
- Data válida  
- Paciente obrigatório  
- Prescrição médica obrigatória  
- Não permitir requisições acima do estoque disponível  
- Subtração automática do estoque
