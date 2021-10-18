using System;

namespace StudentsDiary
{
	public class Student : IComparable<Student>
	{
		public int Id { get; set; }
		public string FirsName { get; set; }
		public string LastName { get; set; }
		public string Math { get; set; }
		public string Technology { get; set; }
		public string Physics { get; set; }
		public string PolishLang { get; set; }
		public string ForeignLang { get; set; }

		//public string Group { get; set; }
		public int GroupId { get; set; }
		
		public string Comments { get; set; }
		public bool Activities { get; set; }

		public Student() { }

		public Student(int id) => Id = id;

		public int CompareTo(Student other) => this.Id > other.Id ? 1 : -1;
	}
}
