using StudentsDiary_Net6.Properties;

namespace StudentsDiary_Net6
{
	public partial class Main : Form
	{
		private readonly FileSerializer<List<Student>> _fileSerializer = new(Environment.ExpandEnvironmentVariables(Settings.Default.PathToFile));
		private List<Group> _groups;
		private List<Student> _students;

		public Main()
		{
			InitializeComponent();
			SetWindowState();
			FillGroups();
			RefreshDiary();
			SetColumnsHeader();
		}

		private void SetWindowState()
		{
			WindowState = Settings.Default.IsMaximize ? FormWindowState.Maximized : FormWindowState.Normal;
			Width = Settings.Default.MainWindowWidth;
			Height = Settings.Default.MainWindowHeight;
		}

		private void FillGroups()
		{
			_groups = GroupHelper.GetGroups("Wszyscy");
			cbGroup.DataSource = _groups;
			cbGroup.SelectedIndexChanged += CbGroup_SelectedIndexChanged;
			cbGroup.DisplayMember = "Name";
			cbGroup.ValueMember = "Id";
		}

		private void RefreshDiary()
		{
			_students = _fileSerializer.DeserializeFromFile();

			int selectedGroupId = (cbGroup.SelectedItem as Group)!.Id;

			if (selectedGroupId != 0)
				_students = _students.Where(x => x.GroupId == selectedGroupId).ToList();

			_students.Sort();
			dgvDiary.DataSource = _students;
		}

		private void SetColumnsHeader()
		{
			dgvDiary.Columns[nameof(Student.Id)].HeaderText = "Id";
			dgvDiary.Columns[nameof(Student.FirsName)].HeaderText = "Imiê";
			dgvDiary.Columns[nameof(Student.LastName)].HeaderText = "Nazwisko";
			dgvDiary.Columns[nameof(Student.Math)].HeaderText = "Matematyka";
			dgvDiary.Columns[nameof(Student.Technology)].HeaderText = "Technologia";
			dgvDiary.Columns[nameof(Student.Physics)].HeaderText = "Fizyka";
			dgvDiary.Columns[nameof(Student.PolishLang)].HeaderText = "Jêzyk polski";
			dgvDiary.Columns[nameof(Student.ForeignLang)].HeaderText = "Jêzyk obcy";
			//dgvDiary.Columns[nameof(Student.GroupId)].HeaderText = "Grupa";
			dgvDiary.Columns[nameof(Student.Comments)].HeaderText = "Uwagi";
			dgvDiary.Columns[nameof(Student.Activities)].HeaderText = "Zaj. dodatkowe";
			dgvDiary.Columns[nameof(Student.GroupId)].Visible = false;
		}

		private void AddClick(object sender, EventArgs e)
		{
			var addEditStudent = new AddEditStudent();
			addEditStudent.ShowDialog();
			RefreshDiary();
		}

		private void EditClick(object sender, EventArgs e) => EditStudent();

		private void CellDoubleClick(object sender, DataGridViewCellEventArgs e) => EditStudent();

		private void EditStudent()
		{
			if (!CheckRowSelection("Proszê zaznacz ucznia, którego dane chcesz edytowaæ."))
				return;

			int selectedIndex = dgvDiary.SelectedRows[0].Index;
			var selectedStudent = (Student)dgvDiary.SelectedRows[0].DataBoundItem;
			var addEditStudent = new AddEditStudent(selectedStudent);
			addEditStudent.ShowDialog();
			RefreshDiary();
			dgvDiary.Rows[selectedIndex].Selected = true;
		}

		private void DeleteClick(object sender, EventArgs e)
		{
			if (!CheckRowSelection("Proszê zaznacz ucznia, którego dane chcesz usun¹æ."))
				return;

			var selectedStudent = (Student)dgvDiary.SelectedRows[0].DataBoundItem;
			var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usun¹æ ucznia {selectedStudent.FirsName} {selectedStudent.LastName}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);
			if (confirmDelete == DialogResult.OK)
			{
				_students = _fileSerializer.DeserializeFromFile();
				_students.RemoveAll(x => x.Id == selectedStudent.Id);
				_fileSerializer.SerializeToFile(_students);
				RefreshDiary();
			}
		}

		private bool CheckRowSelection(string message)
		{
			if (dgvDiary.SelectedRows.Count == 0)
			{
				MessageBox.Show(message);
				return false;
			}
			return true;
		}

		private void RefreshClick(object sender, EventArgs e) => RefreshDiary();

		private void CbGroup_SelectedIndexChanged(object sender, EventArgs e) => RefreshDiary();

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Settings.Default.IsMaximize = WindowState == FormWindowState.Maximized;
			Settings.Default.MainWindowWidth = Width;
			Settings.Default.MainWindowHeight = Height;
			Settings.Default.Save();
		}
	}
}