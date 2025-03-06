using System;
using System.Windows.Forms;

namespace SummerPractice2021Csharp
{
    public partial class TaskCauchy : Form
    {
        public TaskCauchy()
        {
            InitializeComponent();
        }

        private void DrawGraphics_Click(object sender, EventArgs e)
        {
            int N;
            if (Int32.TryParse(textBoxN.Text, out N))   // проверка введенного N на корректность
            {
                // очищаем график и лэйбл со значением макс невязки
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                MaxNevyazka.Text = "";

                // задаем все начальные значения, что нам даны в условии задачи
                double x0 = 0, y0 = 1, xN = 1, step = (xN - x0) / N;

                // выставляем границы отображения оси абсцисс на графике [0;1]
                chart1.ChartAreas[0].AxisX.Minimum = x0;
                chart1.ChartAreas[0].AxisX.Maximum = xN;

                // считаем массивы Х и У решения методом Эйлера
                EulerMethod task = new EulerMethod(x0, y0, step);
                task.Euler(N);

                // рисуем график полученного методом Эйлера решения 
                chart1.Series[1].Points.DataBindXY(task.X, task.Y);

                // строим график аналитически полученной функции
                double[] xFunc = new double[N + 1];
                double[] yFunc = new double[N + 1];
                xFunc = task.X;
                for (int i = 0; i <= N; i++)
                    yFunc[i] = AnalyticsFunc(xFunc[i]);
                chart1.Series[0].Points.DataBindXY(xFunc, yFunc);
                maximalNev(yFunc, task.Y, N);
            }
            else
            {
                MessageBox.Show("Некорректный ввод!!!");
                MaxNevyazka.Text = "";
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
            }

        }

        // вывод массива double в messageBox
        /*
        public void outArrToMBox(double[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
                str += Convert.ToString(arr[i]) + " ";
            MessageBox.Show(str);
        }
        */

        // функция, полученная при аналитическом решении
        public double AnalyticsFunc (double pointX)
        {
            return Math.Cos(pointX) / (3 * Math.Sin(pointX) + 1);
        }

        // максимальная невязка
        public void maximalNev (double[] AnalyticY, double[] EulerY, int N)
        {
            double maxNev = Math.Abs(AnalyticY[0] - EulerY[0]);
            for (int i = 1; i < N + 1; i++)
            {
                double t = Math.Abs(AnalyticY[i] - EulerY[i]);
                if (t > maxNev)
                    maxNev = t;
            }
            MaxNevyazka.Text = " Максимальная невязка: " + Convert.ToString(maxNev);
        }
    }

    public class EulerMethod
    {
        public double X0 { get; private set; }  // начальные условия
        public double Y0 { get; private set; }  // начальные условия
        public double Step { get; private set; }    // шаг (h)
        public double[] X { get; private set; }     // итоговый массив иксов 
        public double[] Y { get; private set; }     // итоговый массив игреков

        public void Euler(int N)
        {
            X = new double[N+1];
            Y = new double[N+1];

            X[0] = X0;
            Y[0] = Y0;

            for (int i = 1; i <= N; i++)
            {
                X[i] = X[i - 1] + Step;
                Y[i] = Y[i - 1] + Step * DUFunc(X[i - 1], Y[i - 1]);
            }
        }

        // функция из исходного уравнения dy/dx = f(x,y)
        public double DUFunc(double pointX, double pointY)
        {
            return -((pointY * Math.Sin(pointX) + 3 * pointY * pointY * Math.Cos(pointX)) / Math.Cos(pointX));
        }

        // конструктор
        public EulerMethod(double x0, double y0, double step)
        {
            this.X0 = x0;
            this.Y0 = y0;
            this.Step = step;
        }
    }
}

