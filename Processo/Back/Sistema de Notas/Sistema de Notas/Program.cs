using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sistema_de_Notas
{
	class Student
	{
		public string name {  get; set; }
		public double[] grade {  get; set; }
		public double frequency { get; set; }

		public double CalculateAverage()
		{
			double total = 0;

			for (int i = 0; i < grade.Length; i++)
			{
				total += grade[i];
			}

			return total / grade.Length;
		}
	}

	class Discipline
	{
		public string name { get; set; }

	}

	class StudentServices
	{
		private List<Student> studentsList = new List<Student>();
		private List<Discipline> disciplinesList = new List<Discipline>();

		public void AddDiscipline(Discipline discipline)
		{
			disciplinesList.Add(discipline);
		}
		public List<Discipline> GetDisciplines()
		{
			return disciplinesList;
		}

		public void AddStudent(Student student)
		{
			studentsList.Add(student);
		}

		public void RemoveStudent(Student student)
		{
			studentsList.Remove(student);
		}

		public Student GetStudentByName(string name)
		{
			foreach (Student student in studentsList)
			{
				if(student.name == name)
				{
					return student;
				}
			}
			return null;
		}

		public List<Student> GetStudents()
		{
			return studentsList;
		}

		public double[] GetClassAverages()
		{
			double[] averages = new double[5];

			for (int i = 0; i < 5; i++)
			{
				double sum = 0;
				for(int j = 0; j < studentsList.Count; j++)
				{
					sum += studentsList[j].grade[i];
				}
				averages[i] = sum / studentsList.Count;
			}

			return averages;
		}

		public List<Student> StudentsAboveClassAverage()
		{
			List<Student> aprovedStudents = new List<Student>();

			double totalAverages = 0;
			
			for( int i = 0; i< studentsList.Count; i++)
			{
				totalAverages += studentsList[i].CalculateAverage();
			}

			double classAverage = totalAverages / studentsList.Count;

			for (int i = 0; i < studentsList.Count; i++) 
			{
				if (studentsList[i].CalculateAverage() > classAverage)
				{
					aprovedStudents.Add(studentsList[i]);
				}
			}

			return aprovedStudents;
		}

		public List<Student> StudentsLowAttendance()
		{
			List<Student> studentsLowAttendance = new List<Student>();
			
			for(int i = 0; i< studentsList.Count; i++)
			{
				if (studentsList[i].frequency < 75)
				{
					studentsLowAttendance.Add(studentsList[i]);
				}
			}

			return studentsLowAttendance;
		}
	}



	internal class Program
	{
		static void Main(string[] args)
		{
			StudentServices service = new StudentServices();

			Console.WriteLine("Insira o Nome das 5 Disciplinas:");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"Nome da {i + 1}º disciplina:");
				string disciplineName = Console.ReadLine();

				service.AddDiscipline(new Discipline
				{
					name = disciplineName
				});
			}


			Console.WriteLine("Informe quantos alunos deseja Adicionar");
			int totalStudents = int.Parse(Console.ReadLine());

			for (int i = 0; i < totalStudents; i++)
			{
				Console.WriteLine($"\nInsira o Nome do(a) {i + 1}º Estudante");
				string studentName = Console.ReadLine();

				double[] studentGrade = new double[5];

				for (int j = 0; j < studentGrade.Length; j++)
				{
					do
					{
						Console.WriteLine($"Insira a {j + 1}º Nota do(a) " + studentName);
						studentGrade[j] = double.Parse(Console.ReadLine());
					} while (studentGrade[j] < 0 || studentGrade[j] > 10) ;

				}

				Console.WriteLine($"Insira a Frequência em Porcentagem (%) do(a) " + studentName);
				int studentFrequency = int.Parse(Console.ReadLine());

				while (studentFrequency < 0 || studentFrequency > 100)
				{
					Console.WriteLine("Resposta Inválida!! Insira a Frequência entre 0% e 100%");
					studentFrequency = int.Parse(Console.ReadLine());

				}

				service.AddStudent(new Student
				{
					name = studentName,
					grade = studentGrade,
					frequency = studentFrequency
				});

			}

			Console.WriteLine("\nResultados dos Alunos");
			foreach (var student in service.GetStudents())
			{
				Console.WriteLine($"{student.name} - Média: {student.CalculateAverage():F2} - Frequência: {student.frequency}%");
			}


			Console.WriteLine("\nMédia da Turma por Disciplina");
			double[] averages = service.GetClassAverages();
			for (int i = 0; i < averages.Length; i++)
			{
				Console.WriteLine($"{service.GetDisciplines()[i].name}: {averages[i]:F2}");
			}

			Console.WriteLine("\nAlunos com média acima da média da turma:");
			var above = service.StudentsAboveClassAverage();
			if (above.Count == 0)
			{
				Console.WriteLine("(nenhum)");
			}
			else
			{
				foreach(var student in above)
				{
					Console.WriteLine(student.name);
				}
			}

			Console.WriteLine("\nAlunos com frequência abaixo de 75%:");
			var lowFreq = service.StudentsLowAttendance();
			if (lowFreq.Count == 0)
			{
				Console.WriteLine("(nenhum)");
			}
			else
			{
				lowFreq.ForEach(a => Console.WriteLine(a.name));
			}

			Console.ReadLine();
		}
	}
}
