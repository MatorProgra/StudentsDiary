using StudentsDiary_Net6.Properties;

namespace StudentsDiary_Net6
{
	public partial class AddEditStudent : Form
	{
		private readonly FileSerializer<List<Student>> _fileSerializer = new(Environment.ExpandEnvironmentVariables(Settings.Default.PathToFile));
		private List<Group> _groups;
		private Student _student;

		public AddEditStudent()
		{
			InitializeComponent();
			FillGroups();
		}

		public AddEditStudent(Student student) : this()
		{
			_student = student;
			FillTextBoxes();
			Text = "Edytuj dane studenta";
		}

		private void FillGroups()
		{
			_groups = GroupHelper.GetGroups("Brak");
			cbGroup.DataSource = _groups;
			cbGroup.DisplayMember = "Name";
			cbGroup.ValueMember = "Id";
		}

		private void FillTextBoxes()
		{
			tbId.Text = _student.Id.ToString();
			tbFirstName.Text = _student.FirsName;
			tbLastName.Text = _student.LastName;
			tbMath.Text = _student.Math;
			tbTechnology.Text = _student.Technology;
			tbPhysics.Text = _student.Physics;
			tbPolishLang.Text = _student.PolishLang;
			tbForeignLang.Text = _student.ForeignLang;
			rtbComments.Text = _student.Comments;
			cbActivities.Checked = _student.Activities;
			cbGroup.SelectedItem = _groups.FirstOrDefault(x => x.Id == _student.GroupId);
		}

		private void ConfirmClick(object sender, EventArgs e)
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

		private bool IsProperlyFill()
		{
			if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text))
			{
				MessageBox.Show("Pola imię i nazwisko muszą być wypełnione!");
				return false;
			}

			if (cbGroup.SelectedIndex < 0)
			{
				MessageBox.Show("Wybierz poprawną grupę z listy!");
				return false;
			}

			return true;
		}

		private void SetStudentFields()
		{
			_student.FirsName = tbFirstName.Text.Trim();
			_student.LastName = tbLastName.Text.Trim();
			_student.Math = tbMath.Text;
			_student.Technology = tbTechnology.Text;
			_student.Physics = tbPhysics.Text;
			_student.PolishLang = tbPolishLang.Text;
			_student.ForeignLang = tbForeignLang.Text;
			_student.Comments = rtbComments.Text;
			_student.Activities = cbActivities.Checked;
			_student.GroupId = (cbGroup.SelectedItem as Group).Id;
		}

		private void CancelClick(object sender, EventArgs e) => Close();
	}
}
