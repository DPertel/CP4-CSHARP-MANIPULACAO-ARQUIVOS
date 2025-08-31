# Contador de Linhas e Palavras em Arquivos TXT

# 👥 Integrantes

- Deivison Pertel - RM 550803

- Eduardo Akira - RM 98713

- Wesley Souza - RM 97874

## 📌 Descrição
Aplicação Console em **C# (.NET 8)** que permite ao usuário selecionar uma pasta contendo arquivos `.txt` e processá-los de forma **assíncrona**, calculando a quantidade de **linhas** e **palavras** de cada arquivo.

O resultado consolidado é salvo em um arquivo `relatorio.txt` dentro da pasta `./export` no diretório da aplicação.

---

## 🚀 Funcionalidades
- Solicita ao usuário um diretório com arquivos `.txt`.
- Lista os arquivos encontrados na tela.
- Processa cada arquivo de forma **paralela** usando `async/await`.
- Exibe mensagens de andamento:

        Processando arquivo arquivo1.txt...

- Gera um relatório consolidado no formato:

        arquivo1.txt - 100 linhas - 560 palavras
        arquivo2.txt - 230 linhas - 1500 palavras

- Salva o relatório em:  

        ./export/relatorio.txt


---

## 🛠️ Tecnologias
- **.NET 8**
- **C#**
- Manipulação de arquivos com `System.IO`
- Programação assíncrona com `async/await`

---

## 📂 Estrutura do Projeto

/CPCSHARP

├── Program.cs

├── /export

│ └── relatorio.txt (gerado automaticamente)

└── README.md


---

## ▶️ Como Executar
1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git


## 📂 Acesse a pasta do projeto:

- cd cp4-csharp-manipulacao-arquivos

### Compile e execute:

- **dotnet run**

- Informe o diretório contendo os arquivos .txt.

- Aguarde o processamento e consulte o relatório em:

        ./export/relatorio.txt
    
## ✅ Exemplo de Saída no Console
=== Contador de Linhas e Palavras ===
Informe o caminho da pasta com arquivos .txt: C:\arquivos

Arquivos encontrados:
 - texto1.txt
 - texto2.txt
 - texto3.txt

Pressione ENTER para iniciar o processamento...

Processando arquivo texto1.txt...
Processando arquivo texto2.txt...
Processando arquivo texto3.txt...

✅ Relatório gerado em: C:\...\export\relatorio.txt
