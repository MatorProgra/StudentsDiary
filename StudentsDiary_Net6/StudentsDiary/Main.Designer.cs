namespace StudentsDiary_Net6
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cbGroup = new System.Windows.Forms.ComboBox();
			this.dgvDiary = new System.Windows.Forms.DataGridView();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.flowLayoutPanel1.Controls.Add(this.btnAdd);
			this.flowLayoutPanel1.Controls.Add(this.btnEdit);
			this.flowLayoutPanel1.Controls.Add(this.btnDelete);
			this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
			this.flowLayoutPanel1.Controls.Add(this.cbGroup);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 66);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
			this.btnAdd.Location = new System.Drawing.Point(8, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 40);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Dodaj";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.AddClick);
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
			this.btnEdit.Location = new System.Drawing.Point(89, 13);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 40);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Edytuj";
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.EditClick);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Tomato;
			this.btnDelete.Location = new System.Drawing.Point(170, 13);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 40);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Usuń";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.DeleteClick);
			// 
			// btnRefresh
			// 
			this.btnRefresh.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnRefresh.Location = new System.Drawing.Point(251, 13);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 40);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Odśwież";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.RefreshClick);
			// 
			// cbGroup
			// 
			this.cbGroup.FormattingEnabled = true;
			this.cbGroup.Location = new System.Drawing.Point(332, 22);
			this.cbGroup.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.cbGroup.Name = "cbGroup";
			this.cbGroup.Size = new System.Drawing.Size(121, 23);
			this.cbGroup.TabIndex = 4;
			this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.CbGroup_SelectedIndexChanged);
			// 
			// dgvDiary
			// 
			this.dgvDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDiary.BackgroundColor = System.Drawing.Color.White;
			this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDiary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDiary.Location = new System.Drawing.Point(0, 66);
			this.dgvDiary.MultiSelect = false;
			this.dgvDiary.Name = "dgvDiary";
			this.dgvDiary.RowHeadersVisible = false;
			this.dgvDiary.RowTemplate.Height = 25;
			this.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDiary.Size = new System.Drawing.Size(784, 395);
			this.dgvDiary.TabIndex = 1;
			this.dgvDiary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellDoubleClick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.dgvDiary);
			this.Controls.Add(this.flowLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(350, 350);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dziennik ucznia";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
		private Button btnAdd;
		private Button btnEdit;
		private Button btnDelete;
		private Button btnRefresh;
		private DataGridView dgvDiary;
		private ComboBox cbGroup;
	}
}