
namespace SummerPractice2021Csharp
{
    partial class TaskCauchy
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.DrawGraphics = new System.Windows.Forms.Button();
            this.MaxNevyazka = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Аналитическое решение";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Решение методом Эйлера";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(930, 497);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Графики решений";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(11, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(746, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Рассматриваем задачу Коши: y\' * cosx + y * sinx + 3 * y^2 * cosx = 0, y(0) = 1. П" +
    "ри х принадлежащем отрезку [0;1]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(11, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите количество отрезков (N):";
            // 
            // textBoxN
            // 
            this.textBoxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxN.Location = new System.Drawing.Point(252, 547);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(120, 23);
            this.textBoxN.TabIndex = 3;
            // 
            // DrawGraphics
            // 
            this.DrawGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DrawGraphics.Location = new System.Drawing.Point(406, 545);
            this.DrawGraphics.Name = "DrawGraphics";
            this.DrawGraphics.Size = new System.Drawing.Size(154, 27);
            this.DrawGraphics.TabIndex = 4;
            this.DrawGraphics.Text = "Построить графики!";
            this.DrawGraphics.UseVisualStyleBackColor = true;
            this.DrawGraphics.Click += new System.EventHandler(this.DrawGraphics_Click);
            // 
            // MaxNevyazka
            // 
            this.MaxNevyazka.AutoSize = true;
            this.MaxNevyazka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MaxNevyazka.Location = new System.Drawing.Point(578, 550);
            this.MaxNevyazka.Name = "MaxNevyazka";
            this.MaxNevyazka.Size = new System.Drawing.Size(166, 17);
            this.MaxNevyazka.TabIndex = 5;
            this.MaxNevyazka.Text = "Максимальная невязка:";
            // 
            // TaskCauchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 581);
            this.Controls.Add(this.MaxNevyazka);
            this.Controls.Add(this.DrawGraphics);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.MaximumSize = new System.Drawing.Size(976, 620);
            this.MinimumSize = new System.Drawing.Size(976, 620);
            this.Name = "TaskCauchy";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Button DrawGraphics;
        private System.Windows.Forms.Label MaxNevyazka;
    }
}

