using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
	public partial class AddEditStudent : Form
	{
		private readonly FileSerializer<List<Student>> _fileSerializer = new FileSerializer<List<Student>>(Environment.ExpandEnvironmentVariables(Settings.Default.PathToFile));

		//private readonly List<string> _groups = new List<string>() { "1A", "1B", "2A", "2B", "3A", "3B" };
		private List<Group> _groups;
		
		private Student _student;

		public AddEditStudent()
		{
			InitializeComponent();

			//CBGroup.DataSource = _groups;
			FillGroups();
		}

		public AddEditStudent(Student student) : this()
		{
			_student = student;
			FillTextBoxes();			
		}

		private void FillGroups()
		{
			_groups = GroupsHelper.GetGroups("Brak");

			CBGroup.DataSource = _groups;
			CBGroup.DisplayMember = "Name";
			CBGroup.ValueMember = "Id";
		}

		private void FillTextBoxes()
		{
			TBId.Text = _student.Id.ToString();
			TBFirstName.Text = _student.FirsName;
			TBLastName.Text = _student.LastName;
			TBMath.Text = _student.Math;
			TBTechnology.Text = _student.Technology;
			TBPhysics.Text = _student.Physics;
			TBPolishLang.Text = _student.PolishLang;
			TBForeignLang.Text = _student.ForeignLang;

			//CBGroup.SelectedItem = _student.Group;
			CBGroup.SelectedItem = _groups.FirstOrDefault(x => x.Id == _student.GroupId);

			RTBComments.Text = _student.Comments;
			CBActivities.Checked = _student.Activities;
		}

		private void SetStudentFields()
		{
			_student.FirsName = TBFirstName.Text.Trim();
			_student.LastName = TBLastName.Text.Trim();
			_student.Math = TBMath.Text;
			_student.Technology = TBTechnology.Text;
			_student.Physics = TBPhysics.Text;
			_student.PolishLang = TBPolishLang.Text;
			_student.ForeignLang = TBForeignLang.Text;

			//_student.Group = CBGroup.SelectedItem.ToString();
			_student.GroupId = (CBGroup.SelectedItem as Group).Id;

			_student.Comments = RTBComments.Text;
			_student.Activities = CBActivities.Checked;
		}

		private bool IsProperlyFill()
		{
			if (string.IsNullOrWhiteSpace(TBFirstName.Text) || string.IsNullOrWhiteSpace(TBLastName.Text))
			{
				MessageBox.Show("Pola imię i nazwisko muszą być wypełnione!");
				return false;
			}

			if (CBGroup.SelectedIndex < 0)
			{
				MessageBox.Show("Wybierz poprawną grupę z listy!");
				return false;
			}

			return true;
		}

		private void BtnConfirm_Click(object sender, EventArgs e)
		{
			if (!IsProperlyFill())
				return;

			var students = _fileSerializer.DeserializeFromFile();

			if (_student == null)
			{
				int id = students.Count == 0 ? 1 : students.Max(x => x.Id) + 1;
				_student = new Student(id);
			}

			SetStudentFields();

			students.RemoveAll(x => x.Id == _student.Id);
			students.Add(_student);

			_fileSerializer.SerializeToFile(students);

			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e) => Close();
	}
}
