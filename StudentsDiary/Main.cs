using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
	public partial class Main : Form
	{
		private readonly FileSerializer<List<Student>> _fileSerializer = new FileSerializer<List<Student>>(Environment.ExpandEnvironmentVariables(Settings.Default.PathToFile));

		//private List<string> _groups;
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

		//private void RefreshDiary(string selectedGroup = "")
		//{
		//	_students = _fileSerializer.DeserializeFromFile();

		//	SetGroups(selectedGroup);

		//	if (!selectedGroup.Equals("Wszyscy") && _groups.Contains(selectedGroup))
		//		_students = _students.Where(x => x.GroupId == selectedGroup).ToList();

		//	_students.Sort();
		//	DGVDiary.DataSource = _students;
		//}

		//private void SetGroups(string selectedGroup)
		//{
		//	_groups = new List<string>() { "Wszyscy" };
		//	_groups.AddRange(_students.Where(x => x.GroupId != null).Select(x => x.Group).Distinct().OrderBy(x => x));

		//	CBGroup.BeginUpdate();
		//	CBGroup.SelectedIndexChanged -= CBGroup_SelectedIndexChanged;
		//	CBGroup.DataSource = _groups;
		//	if (_groups.Contains(selectedGroup))
		//		CBGroup.SelectedItem = selectedGroup;
		//	CBGroup.SelectedIndexChanged += CBGroup_SelectedIndexChanged;
		//	CBGroup.EndUpdate();
		//}

		private void FillGroups()
		{
			_groups = GroupsHelper.GetGroups("Wszyscy");

			CBGroup.SelectedIndexChanged -= CBGroup_SelectedIndexChanged;
			CBGroup.DataSource = _groups;
			CBGroup.SelectedIndexChanged += CBGroup_SelectedIndexChanged;
			CBGroup.DisplayMember = "Name";
			CBGroup.ValueMember = "Id";
		}

		private void RefreshDiary()
		{
			_students = _fileSerializer.DeserializeFromFile();

			int selectedGroupId = (CBGroup.SelectedItem as Group).Id;

			if (selectedGroupId != 0)
				_students = _students.Where(x => x.GroupId == selectedGroupId).ToList();

			_students.Sort();
			DGVDiary.DataSource = _students;
		}

		private void SetColumnsHeader()
		{
			//string[] labels = { "Id", "Imię", "Nazwisko", "Matematyka", "Technologia", "Fizyka", "Język polski", "Język obcy", "Grupa", "Uwagi", "Zaj. dodatkowe" };

			//for (int i = 0; i < labels.Length; i++)
			//	DGVDiary.Columns[i].HeaderText = labels[i];

			DGVDiary.Columns[nameof(Student.Id)].HeaderText = "Id";
			DGVDiary.Columns[nameof(Student.FirsName)].HeaderText = "Imię";
			DGVDiary.Columns[nameof(Student.LastName)].HeaderText = "Nazwisko";
			DGVDiary.Columns[nameof(Student.Math)].HeaderText = "Matematyka";
			DGVDiary.Columns[nameof(Student.Technology)].HeaderText = "Technologia";
			DGVDiary.Columns[nameof(Student.Physics)].HeaderText = "Fizyka";
			DGVDiary.Columns[nameof(Student.PolishLang)].HeaderText = "Język polski";
			DGVDiary.Columns[nameof(Student.ForeignLang)].HeaderText = "Język obcy";
			DGVDiary.Columns[nameof(Student.GroupId)].HeaderText = "Grupa";
			DGVDiary.Columns[nameof(Student.Comments)].HeaderText = "Uwagi";
			DGVDiary.Columns[nameof(Student.Activities)].HeaderText = "Zaj. dodatkowe";
		}

		private void EditStudent()
		{
			if (!CheckRowSelection("Proszę zaznacz ucznia, którego dane chcesz edytować."))
				return;

			int selectedIndex = DGVDiary.SelectedRows[0].Index;
			var selectedStudent = (Student)DGVDiary.SelectedRows[0].DataBoundItem;
			AddEditStudent addEditStudent = new AddEditStudent(selectedStudent);
			addEditStudent.ShowDialog();
			
			//RefreshDiary(CBGroup.SelectedItem.ToString());
			RefreshDiary();

			DGVDiary.Rows[selectedIndex].Selected = true;
		}

		private bool CheckRowSelection(string message)
		{
			if (DGVDiary.SelectedRows.Count == 0)
			{
				MessageBox.Show(message);
				return false;
			}
			return true;
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			AddEditStudent addEditStudent = new AddEditStudent();
			addEditStudent.ShowDialog();
			
			//RefreshDiary(CBGroup.SelectedItem.ToString());
			RefreshDiary();
		}

		private void BtnEdit_Click(object sender, EventArgs e) => EditStudent();

		private void DGVDiary_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => EditStudent();

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			if (!CheckRowSelection("Proszę zaznacz ucznia, którego dane chcesz usunąć."))
				return;

			var selectedStudent = (Student)DGVDiary.SelectedRows[0].DataBoundItem;
			var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia {selectedStudent.FirsName} {selectedStudent.LastName}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);
			if (confirmDelete == DialogResult.OK)
			{
				_students = _fileSerializer.DeserializeFromFile();
				_students.RemoveAll(x => x.Id == selectedStudent.Id);
				_fileSerializer.SerializeToFile(_students);
				
				//RefreshDiary(CBGroup.SelectedItem.ToString());
				RefreshDiary();
			}
		}

		private void BtnRefresh_Click(object sender, EventArgs e) => RefreshDiary();

		//private void CBGroup_SelectedIndexChanged(object sender, EventArgs e) => RefreshDiary(CBGroup.SelectedItem.ToString());
		private void CBGroup_SelectedIndexChanged(object sender, EventArgs e) => RefreshDiary();

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Settings.Default.IsMaximize = WindowState == FormWindowState.Maximized;
			Settings.Default.MainWindowWidth = Width;
			Settings.Default.MainWindowHeight = Height;
			Settings.Default.Save();
		}
	}
}
