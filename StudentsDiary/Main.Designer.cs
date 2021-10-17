
namespace StudentsDiary
{
	partial class Main
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.BtnAdd = new System.Windows.Forms.Button();
			this.BtnEdit = new System.Windows.Forms.Button();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.BtnRefresh = new System.Windows.Forms.Button();
			this.CBGroup = new System.Windows.Forms.ComboBox();
			this.DGVDiary = new System.Windows.Forms.DataGridView();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGVDiary)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.flowLayoutPanel1.Controls.Add(this.BtnAdd);
			this.flowLayoutPanel1.Controls.Add(this.BtnEdit);
			this.flowLayoutPanel1.Controls.Add(this.BtnDelete);
			this.flowLayoutPanel1.Controls.Add(this.BtnRefresh);
			this.flowLayoutPanel1.Controls.Add(this.CBGroup);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(984, 65);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// BtnAdd
			// 
			this.BtnAdd.BackColor = System.Drawing.Color.LimeGreen;
			this.BtnAdd.Location = new System.Drawing.Point(8, 13);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(75, 40);
			this.BtnAdd.TabIndex = 0;
			this.BtnAdd.Text = "Dodaj";
			this.BtnAdd.UseVisualStyleBackColor = false;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// BtnEdit
			// 
			this.BtnEdit.BackColor = System.Drawing.Color.Goldenrod;
			this.BtnEdit.Location = new System.Drawing.Point(89, 13);
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.Size = new System.Drawing.Size(75, 40);
			this.BtnEdit.TabIndex = 1;
			this.BtnEdit.Text = "Edytuj";
			this.BtnEdit.UseVisualStyleBackColor = false;
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			// 
			// BtnDelete
			// 
			this.BtnDelete.BackColor = System.Drawing.Color.Tomato;
			this.BtnDelete.Location = new System.Drawing.Point(170, 13);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(75, 40);
			this.BtnDelete.TabIndex = 2;
			this.BtnDelete.Text = "Usuń";
			this.BtnDelete.UseVisualStyleBackColor = false;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// BtnRefresh
			// 
			this.BtnRefresh.BackColor = System.Drawing.Color.CornflowerBlue;
			this.BtnRefresh.Location = new System.Drawing.Point(251, 13);
			this.BtnRefresh.Name = "BtnRefresh";
			this.BtnRefresh.Size = new System.Drawing.Size(75, 40);
			this.BtnRefresh.TabIndex = 3;
			this.BtnRefresh.Text = "Odśwież";
			this.BtnRefresh.UseVisualStyleBackColor = false;
			this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
			// 
			// CBGroup
			// 
			this.CBGroup.FormattingEnabled = true;
			this.CBGroup.Location = new System.Drawing.Point(338, 22);
			this.CBGroup.Margin = new System.Windows.Forms.Padding(9, 12, 3, 3);
			this.CBGroup.Name = "CBGroup";
			this.CBGroup.Size = new System.Drawing.Size(121, 21);
			this.CBGroup.TabIndex = 4;
			this.CBGroup.SelectedIndexChanged += new System.EventHandler(this.CBGroup_SelectedIndexChanged);
			// 
			// DGVDiary
			// 
			this.DGVDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DGVDiary.BackgroundColor = System.Drawing.Color.White;
			this.DGVDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DGVDiary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DGVDiary.Location = new System.Drawing.Point(0, 65);
			this.DGVDiary.MultiSelect = false;
			this.DGVDiary.Name = "DGVDiary";
			this.DGVDiary.ReadOnly = true;
			this.DGVDiary.RowHeadersVisible = false;
			this.DGVDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DGVDiary.Size = new System.Drawing.Size(984, 496);
			this.DGVDiary.TabIndex = 3;
			this.DGVDiary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDiary_CellDoubleClick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.DGVDiary);
			this.Controls.Add(this.flowLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(360, 240);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dziennik ucznia";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DGVDiary)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button BtnAdd;
		private System.Windows.Forms.Button BtnEdit;
		private System.Windows.Forms.Button BtnDelete;
		private System.Windows.Forms.Button BtnRefresh;
		private System.Windows.Forms.DataGridView DGVDiary;
		private System.Windows.Forms.ComboBox CBGroup;
	}
}

