
namespace LW8_DataBases
{
    partial class Illness
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFromProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.veterinary_ClinicDataSet = new LW8_DataBases.Veterinary_ClinicDataSet();
            this.illnessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.illnessTableAdapter = new LW8_DataBases.Veterinary_ClinicDataSetTableAdapters.IllnessTableAdapter();
            this.illnessIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.illnessNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veterinary_ClinicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.illnessBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesToolStripMenuItem,
            this.deleteCurrentNoteToolStripMenuItem,
            this.backToolStripMenuItem,
            this.exitFromProjectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.saveChangesToolStripMenuItem.Text = "Сохранить изменения";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
            // 
            // deleteCurrentNoteToolStripMenuItem
            // 
            this.deleteCurrentNoteToolStripMenuItem.Name = "deleteCurrentNoteToolStripMenuItem";
            this.deleteCurrentNoteToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.deleteCurrentNoteToolStripMenuItem.Text = "Удалить текущую запись";
            this.deleteCurrentNoteToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentNoteToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.backToolStripMenuItem.Text = "Вернуться назад";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // exitFromProjectToolStripMenuItem
            // 
            this.exitFromProjectToolStripMenuItem.Name = "exitFromProjectToolStripMenuItem";
            this.exitFromProjectToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.exitFromProjectToolStripMenuItem.Text = "Выйти из проекта";
            this.exitFromProjectToolStripMenuItem.Click += new System.EventHandler(this.exitFromProjectToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.illnessIDDataGridViewTextBoxColumn,
            this.illnessNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.illnessBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 1;
            // 
            // veterinary_ClinicDataSet
            // 
            this.veterinary_ClinicDataSet.DataSetName = "Veterinary_ClinicDataSet";
            this.veterinary_ClinicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // illnessBindingSource
            // 
            this.illnessBindingSource.DataMember = "Illness";
            this.illnessBindingSource.DataSource = this.veterinary_ClinicDataSet;
            // 
            // illnessTableAdapter
            // 
            this.illnessTableAdapter.ClearBeforeFill = true;
            // 
            // illnessIDDataGridViewTextBoxColumn
            // 
            this.illnessIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.illnessIDDataGridViewTextBoxColumn.DataPropertyName = "IllnessID";
            this.illnessIDDataGridViewTextBoxColumn.FillWeight = 15F;
            this.illnessIDDataGridViewTextBoxColumn.HeaderText = "IllnessID";
            this.illnessIDDataGridViewTextBoxColumn.Name = "illnessIDDataGridViewTextBoxColumn";
            this.illnessIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // illnessNameDataGridViewTextBoxColumn
            // 
            this.illnessNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.illnessNameDataGridViewTextBoxColumn.DataPropertyName = "IllnessName";
            this.illnessNameDataGridViewTextBoxColumn.HeaderText = "IllnessName";
            this.illnessNameDataGridViewTextBoxColumn.Name = "illnessNameDataGridViewTextBoxColumn";
            // 
            // Illness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Illness";
            this.Text = "Таблица \"Болезни\"";
            this.Load += new System.EventHandler(this.Illness_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veterinary_ClinicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.illnessBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitFromProjectToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Veterinary_ClinicDataSet veterinary_ClinicDataSet;
        private System.Windows.Forms.BindingSource illnessBindingSource;
        private Veterinary_ClinicDataSetTableAdapters.IllnessTableAdapter illnessTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn illnessIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn illnessNameDataGridViewTextBoxColumn;
    }
}