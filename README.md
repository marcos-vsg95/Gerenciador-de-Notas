# 🎓 Gerenciador de Notas — Processo Seletivo dti digital

Este projeto foi desenvolvido como parte do processo seletivo para a vaga de **Estágio em Desenvolvimento** na dti digital.  
O objetivo é criar um sistema simples que permita ao professor registrar notas e frequência de alunos, calcular estatísticas da turma e identificar estudantes que precisam de atenção especial.

O sistema foi implementado como um **Aplicativo de Console em C# (.NET Framework)**, com foco total na lógica e clareza do código.

---

## 🚀 Como executar o sistema

### ✔ Requisitos
- Windows
- Visual Studio (qualquer versão compatível com .NET Framework)
- Projeto configurado como **Console Application (.NET Framework)**

### ✔ Passo a passo para rodar

1. Clone o repositório:

   ```bash
   git clone https://github.com/marcos-vsg95/Gerenciador-de-Notas
   
2. Abra o projeto no Visual Studio.

3. Compile o projeto (atalho no Visual Studio):
ˋCtrl + Shift + B

4. Execute (atalho no Visual Studio):
ˋCtrl + F5

5. Siga as instruções no console:

- Digite os nomes das 5 disciplinas.
- Informe quantos alunos deseja cadastrar.
- Digite o nome de cada aluno.
- Digite as 5 notas (validadas entre 0 e 10).
- Digite a frequência (validada entre 0% e 100%).

## 📌 Premissas Assumidas
- O professor sempre cadastra 5 disciplinas, como descrito no enunciado.
- Cada aluno possui exatamente 5 notas, uma para cada disciplina inserida.
- O usuário sempre digita valores válidos (exceto onde o sistema faz validação).
- Há pelo menos 1 aluno cadastrado, evitando divisão por zero.
- Os dados são mantidos somente em memória — não há banco de dados.
- A aplicação é inteiramente executada e controlada via console.
- Não foram utilizados recursos avançados como APIs, JavaScript, React, etc, mantendo o foco nas estruturas básicas da linguagem.

## 🧠 Decisões de Projeto
- A lógica foi organizada em três classes principais:
  1. Student
  - Armazena nome, notas e frequência.
  - Contém o método CalculateAverage() para calcular a média manualmente.

  2. Discipline
  - Armazena os nomes das disciplinas digitadas pelo professor.

  3. StudentServices
  - Classe responsável pelas regras de negócio:
        - Cálculo da média da turma por disciplina.
        - Filtragem de alunos acima da média geral.
        - Alunos com frequência abaixo de 75%.
        - Armazenamento dos alunos e disciplinas.

  4. Program
  - Gerencia toda a interação com o usuário.
  - Lê entradas e exibe os resultados.

Todas as validações de entrada foram feitas manualmente usando laços do...while. Optei por manter as estruturas simples para clareza e alinhamento com o objetivo educacional do teste.

## 📊 Funcionalidades Implementadas
✔ Cadastro
- Inclusão dos nomes das 5 disciplinas.
- Cadastro de múltiplos alunos.
- Registro de 5 notas por aluno.
- Registro da frequência (0% a 100%).

✔ Cálculo Automático
- Média individual de cada aluno.
- Média da turma em cada disciplina.
- Média geral da turma.

✔ Identificação
- Alunos com média acima da média geral da turma.
- Alunos com frequência abaixo de 75%.

✔ Exibição
- Resultados organizados no console.
- Disciplinas exibidas com seus nomes reais.
- Valores de média formatados com duas casas decimais (F2).

## 📁 Estrutura do Projeto
```Bash

Sistema_de_Notas/
│
├── Student.cs              # Classe do aluno
├── Discipline.cs           # Classe das disciplinas
├── StudentServices.cs      # Regras e cálculos
└── Program.cs              # Fluxo principal e interação com o usuário
```

## 🛠 Tecnologias Utilizadas
- C#
- .NET Framework
- Visual Studio
