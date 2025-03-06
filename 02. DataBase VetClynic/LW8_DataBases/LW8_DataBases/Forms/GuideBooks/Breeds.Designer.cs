
namespace LW8_DataBases
{
    partial class Breeds
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
            this.veterinary_ClinicDataSet = new LW8_DataBases.Veterinary_ClinicDataSet();
            this.breedsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.breedsTableAdapter = new LW8_DataBases.Veterinary_ClinicDataSetTableAdapters.BreedsTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.breedsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.breedIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIDFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veterinary_ClinicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breedsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breedsBindingSource1)).BeginInit();
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
            this.menuStrip1.TabIndex = 1;
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
            // veterinary_ClinicDataSet
            // 
            this.veterinary_ClinicDataSet.DataSetName = "Veterinary_ClinicDataSet";
            this.veterinary_ClinicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // breedsBindingSource
            // 
            this.breedsBindingSource.DataMember = "Breeds";
            this.breedsBindingSource.DataSource = this.veterinary_ClinicDataSet;
            // 
            // breedsTableAdapter
            // 
            this.breedsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.breedIDDataGridViewTextBoxColumn,
            this.typeIDFKDataGridViewTextBoxColumn,
            this.breedNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.breedsBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 426);
            this.dataGridView1.TabIndex = 2;
            // 
            // breedsBindingSource1
            // 
            this.breedsBindingSource1.DataMember = "Breeds";
            this.breedsBindingSource1.DataSource = this.veterinary_ClinicDataSet;
            // 
            // breedIDDataGridViewTextBoxColumn
            // 
            this.breedIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.breedIDDataGridViewTextBoxColumn.DataPropertyName = "BreedID";
            this.breedIDDataGridViewTextBoxColumn.FillWeight = 15F;
            this.breedIDDataGridViewTextBoxColumn.HeaderText = "BreedID";
            this.breedIDDataGridViewTextBoxColumn.Name = "breedIDDataGridViewTextBoxColumn";
            this.breedIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeIDFKDataGridViewTextBoxColumn
            // 
            this.typeIDFKDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeIDFKDataGridViewTextBoxColumn.DataPropertyName = "TypeID_FK";
            this.typeIDFKDataGridViewTextBoxColumn.FillWeight = 15F;
            this.typeIDFKDataGridViewTextBoxColumn.HeaderText = "TypeID_FK";
            this.typeIDFKDataGridViewTextBoxColumn.Name = "typeIDFKDataGridViewTextBoxColumn";
            // 
            // breedNameDataGridViewTextBoxColumn
            // 
            this.breedNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.breedNameDataGridViewTextBoxColumn.DataPropertyName = "BreedName";
            this.breedNameDataGridViewTextBoxColumn.HeaderText = "BreedName";
            this.breedNameDataGridViewTextBoxColumn.Name = "breedNameDataGridViewTextBoxColumn";
            // 
            // Breeds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Breeds";
            this.Text = "Breeds";
            this.Load += new System.EventHandler(this.Breeds_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veterinary_ClinicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breedsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breedsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitFromProjectToolStripMenuItem;
        private Veterinary_ClinicDataSet veterinary_ClinicDataSet;
        private System.Windows.Forms.BindingSource breedsBindingSource;
        private Veterinary_ClinicDataSetTableAdapters.BreedsTableAdapter breedsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIDFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource breedsBindingSource1;
    }
}