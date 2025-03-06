using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiskMathDZGraphs11012020
{
    class Program
    {
        static void Main()
        {
            Tasks.Task7();   
            Console.ReadKey();
        }
    }

    public class Combinatorics
    {
        private int lengthAlphabet;
        private int lenghtObject;
        private bool repetitions;
        private int[] combObject;
        private string nameObject;

        //создает универсальный комбинаторный объект с повторениями или без
        public void Object(int lengthAlphabet, int lenghtObject, bool repetitions)
        {
            this.lengthAlphabet = lengthAlphabet;
            this.lenghtObject = lenghtObject;
            this.repetitions = repetitions;
            this.combObject = new int[this.lengthAlphabet];
            if (repetitions)
                for (int i = 0; i < this.lengthAlphabet; i++)
                    combObject[i] = 1;
            else
                for (int i = 0; i < this.lengthAlphabet; i++)
                    combObject[i] = i + 1;
        }

        //частный случай
        public void Object(int lengthAlphabet, bool repetitions)
        {
            Object(lengthAlphabet, lengthAlphabet, repetitions);
        }

        //возвращает объект в начальное состояние
        public void Reset()
        {
            if (repetitions)
                for (int i = 0; i < lengthAlphabet; i++)
                    combObject[i] = 1;
            else
                for (int i = 0; i < lengthAlphabet; i++)
                    combObject[i] = i + 1;
        }

        //вывод в файл всех перестановок
        public void Permutations(int lenghtObject)
        {
            this.lengthAlphabet = lenghtObject;
            this.lenghtObject = lenghtObject;
            this.combObject = new int[this.lenghtObject];
            this.nameObject = "Permutations.txt";
            StreamWriter streamWriter = new StreamWriter(nameObject);
            for (int i = 0; i < this.lenghtObject; i++)
                combObject[i] = i + 1;
            Print(streamWriter);
            while (NextPermutation())
                Print(streamWriter);
            streamWriter.Close();
        }

        //вывод в файл всех размещений
        public void Accommodations(int lengthAlphabet, int lenghtObject)
        {
            this.lengthAlphabet = lengthAlphabet;
            this.lenghtObject = lenghtObject;
            this.combObject = new int[this.lengthAlphabet];
            this.nameObject = "Accommodations.txt";
            StreamWriter streamWriter = new StreamWriter(nameObject);
            for (int i = 0; i < this.lengthAlphabet; i++)
                combObject[i] = i + 1;
            Print(streamWriter);
            while (NextAccommodation())
                Print(streamWriter);
            streamWriter.Close();
        }

        //вывод в файл всех сочетаний
        public void Combinations(int lengthAlphabet, int lenghtObject)
        {
            this.lengthAlphabet = lengthAlphabet;
            this.lenghtObject = lenghtObject;
            this.combObject = new int[this.lengthAlphabet];
            this.nameObject = "Combinations.txt";
            StreamWriter streamWriter = new StreamWriter(nameObject);
            for (int i = 0; i < this.lengthAlphabet; i++)
                combObject[i] = i + 1;
            Print(streamWriter);
            while (NextCombination())
                Print(streamWriter);
            streamWriter.Close();
        }

        //построение следующей перестановки по лексикографическому порядку
        public bool NextPermutation()
        {
            int j = lenghtObject - 2;
            while (j != -1 && combObject[j] >= combObject[j + 1]) j--;
            if (j == -1)
                return false;
            int elem = lenghtObject - 1;
            while (combObject[j] >= combObject[elem]) elem--;
            Swap(j, elem);
            int leftElem = j + 1, rightElem = lenghtObject - 1;
            while (leftElem < rightElem)
                Swap(leftElem++, rightElem--);
            return true;
        }

        //построение следующего размещения по лексикографическому порядку
        public bool NextAccommodation()
        {
            int j;
            do
            {
                j = lengthAlphabet - 2;
                while (j != -1 && combObject[j] >= combObject[j + 1]) j--;
                if (j == -1)
                    return false;
                int elem = lengthAlphabet - 1;
                while (combObject[j] >= combObject[elem]) elem--;
                Swap(j, elem);
                int leftElem = j + 1, rightElem = lengthAlphabet - 1;
                while (leftElem < rightElem)
                    Swap(leftElem++, rightElem--);
            } while (j > lenghtObject - 1);
            return true;
        }

        //построение следующего сочетания по лексикографическому порядку
        public bool NextCombination()
        {
            int k = lenghtObject;
            for (int i = k - 1; i >= 0; i--)
                if (combObject[i] < lengthAlphabet - k + i + 1)
                {
                    combObject[i]++;
                    for (int j = i + 1; j < k; j++)
                        combObject[j] = combObject[j - 1] + 1;
                    return true;
                }
            return false;
        }

        private void Swap(int firstElem, int secondElem)
        {
            int elem = combObject[firstElem];
            combObject[firstElem] = combObject[secondElem];
            combObject[secondElem] = elem;
        }

        private void Print(StreamWriter streamWriter)
        {
            for (int i = 0; i < lenghtObject; i++)
                streamWriter.Write($"{combObject[i]}");
            streamWriter.WriteLine();
        }

        public int[] CombObject
        {
            get
            {
                return combObject;
            }
        }
    }

    public class Tasks
    {
        public static void Task1()  //для неориентированного
        {
            int p, q, countGraphs = 0;   // кол-во вершины, ребра, графов
            Console.WriteLine("Хар-ки графа (p,q): ");
            p = Convert.ToInt32(Console.ReadLine());
            q = Convert.ToInt32(Console.ReadLine());

            bool[,] adjMatrix = new bool[p, p];
            int[,] allEdges = new int[2, (p - 1) * p / 2];
            Combinatorics combObj = new Combinatorics();
            combObj.Object(p, 2, false);    // создаем сочетание для ребер
            // заполняем матрицу со всеми ребрами графа
            for (int i = 0; i < (p - 1) * p / 2; i++)
            {
                allEdges[0, i] = combObj.CombObject[0];
                allEdges[1, i] = combObj.CombObject[1];
                combObj.NextCombination();
            }
            combObj.Object((p - 1) * p / 2, q, false);  // создаем сочетание для выбора ребер в матрицу
            StreamWriter fsw = new StreamWriter("Task1.txt");
            do
            {
                ResetMatrix(adjMatrix, p);  // обнуляем матр чтобы не было старых данных
                for (int i = 0; i < q; i++) // идем по всем ребрам в сочетании
                {
                    adjMatrix[allEdges[0, combObj.CombObject[i] - 1] - 1, allEdges[1, combObj.CombObject[i] - 1] - 1] = true;
                    adjMatrix[allEdges[1, combObj.CombObject[i] - 1] - 1, allEdges[0, combObj.CombObject[i] - 1] - 1] = true;
                }
                countGraphs++;
                PrintF(fsw, adjMatrix, p);  // запись матр в файл
            } while (combObj.NextCombination());
            fsw.WriteLine("Кол-во графов:" + countGraphs);
            // закрываем поток и открываем файл
            fsw.Close();
            System.Diagnostics.Process.Start("Task1.txt");
        }

        private static void PrintF(StreamWriter fsw, bool[,] matrix, int p)
        {
            for (int i = 0; i < p; i++)
            {
                for (int j = 0; j < p; j++)
                    fsw.Write(Convert.ToInt32(matrix[i, j]) + " ");
                fsw.WriteLine();
            }
            fsw.WriteLine();
        }

        private static void ResetMatrix(bool[,] matrix, int p)
        {
            for (int i = 0; i < p; i++)
                for (int j = 0; j < p; j++)
                    matrix[i, j] = false;
        }

        private static void ReadMatrixF(StreamReader fsr, bool[,] adjMatrix, int countVert)
        {
            string[] str;
            for (int i = 0; i < countVert; i++)
            {
                str = fsr.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                    if (str[j] != "0")
                        adjMatrix[i, j] = true;
            }
        }

        private static bool IsEqualMatrixes(bool[,] m1, bool[,] m2, int p)
        {
            for (int i = 0; i < p; i++)
                for (int j = 0; j < p; j++)
                    if (m1[i, j] != m2[i, j])
                        return false;
            return true;
        }

        public static void Task2()
        {
            int p, countGraphs = 0;   // кол-во вершины, ребра, графов
            Console.WriteLine("Хар-ки графа (p): ");
            p = Convert.ToInt32(Console.ReadLine());

            bool[,] adjMatrix = new bool[p, p];
            int[,] allEdges = new int[2, (p - 1) * p / 2];
            Combinatorics combObj = new Combinatorics();
            combObj.Object(p, 2, false);    // создаем сочетание для ребер
            // заполняем матрицу со всеми ребрами графа
            for (int i = 0; i < (p - 1) * p / 2; i++)
            {
                allEdges[0, i] = combObj.CombObject[0];
                allEdges[1, i] = combObj.CombObject[1];
                combObj.NextCombination();
            }
            StreamWriter fsw = new StreamWriter("Task2.txt");
            for (int j = 0; j <= (p - 1) * p / 2; j++)
            {
                combObj.Object((p - 1) * p / 2, j, false);  // создаем сочетание для выбора ребер в матрицу
                do
                {
                    ResetMatrix(adjMatrix, p);  // обнуляем матр чтобы не было старых данных
                    for (int i = 0; i < j; i++) // идем по всем ребрам в сочетании
                    {
                        adjMatrix[allEdges[0, combObj.CombObject[i] - 1] - 1, allEdges[1, combObj.CombObject[i] - 1] - 1] = true;
                        adjMatrix[allEdges[1, combObj.CombObject[i] - 1] - 1, allEdges[0, combObj.CombObject[i] - 1] - 1] = true;
                    }
                    countGraphs++;
                    PrintF(fsw, adjMatrix, p);  // запись матр в файл
                } while (combObj.NextCombination());
            }
            fsw.WriteLine("Кол-во графов:" + countGraphs);
            // закрываем поток и открываем файл
            fsw.Close();
            System.Diagnostics.Process.Start("Task2.txt");
        }

        public static void Task3()
        {
            StreamReader fsr = new StreamReader("InputGraph1.txt");
            int countVert = Convert.ToInt32(fsr.ReadLine());    // из 1 стр считываем кол-во вершин
            bool[,] adjMatrix1 = new bool[countVert, countVert];
            bool[,] adjMatrix2 = new bool[countVert, countVert];
            ResetMatrix(adjMatrix1, countVert);
            ResetMatrix(adjMatrix2, countVert);
            // считываем матрицы из файлов
            ReadMatrixF(fsr, adjMatrix1, countVert);
            fsr = new StreamReader("InputGraph2.txt");
            ReadMatrixF(fsr, adjMatrix2, countVert);
            fsr.Close();
            bool flag = true;
            for (int i = 0; i < countVert; i++)
                for (int j = 0; j < countVert; j++)
                    if (adjMatrix1[i, j] != adjMatrix2[i, j])
                        flag = false;
            Console.WriteLine("Is automotphism? - " + flag);
        }

        public static void Task4()
        {
            StreamReader fsr = new StreamReader("InputGraph1.txt");
            int countVert = Convert.ToInt32(fsr.ReadLine());    // из 1 стр считываем кол-во вершин
            bool[,] adjMatrix1 = new bool[countVert, countVert];
            ResetMatrix(adjMatrix1, countVert);
            ReadMatrixF(fsr, adjMatrix1, countVert);
            fsr.Close();
            Combinatorics combObj = new Combinatorics();
            combObj.Object(countVert, false);
            StreamWriter fsw = new StreamWriter("Task4.txt");
            do
            {
                bool[,] adjMatrix2 = new bool[countVert, countVert];
                // идем по перестановке
                for (int i = 0; i < countVert;  i++)
                {
                    // заполняем матрицу новую
                    for (int j = 0; j < countVert; j++)
                    {
                        adjMatrix2[i, j] = adjMatrix1[combObj.CombObject[i] - 1, combObj.CombObject[j] - 1];
                    }
                }
                bool flag = IsEqualMatrixes(adjMatrix1, adjMatrix2, countVert);

                if (flag)
                {
                    for (int i = 0; i < countVert; i++)
                        fsw.Write(combObj.CombObject[i] + " ");
                    fsw.WriteLine();
                    PrintF(fsw, adjMatrix2, countVert);
                }
            } while (combObj.NextPermutation());
            fsw.Close();
            System.Diagnostics.Process.Start("Task4.txt");
        }

        public static void Task5()
        {
            StreamReader fsr = new StreamReader("InputGraph1.txt");
            int countVert = Convert.ToInt32(fsr.ReadLine());    // из 1 стр считываем кол-во вершин
            bool[,] adjMatrix1 = new bool[countVert, countVert];
            ResetMatrix(adjMatrix1, countVert);
            ReadMatrixF(fsr, adjMatrix1, countVert);
            fsr.Close();
            // считали граф, он уже помечен 1-м способом
            // создаем перестановку
            Combinatorics combObj = new Combinatorics();
            combObj.Object(countVert, false);
            StreamWriter fsw = new StreamWriter("Task5.txt");
            // создаем место для хранения матриц смежности
            List<bool[,]> graphs = new List<bool[,]>();
            do
            {
                bool[,] adjMatrix2 = new bool[countVert, countVert];
                // идем по перестановке
                for (int i = 0; i < countVert; i++)
                {
                    // заполняем матрицу новую
                    for (int j = 0; j < countVert; j++)
                    {
                        adjMatrix2[i, j] = adjMatrix1[combObj.CombObject[i] - 1, combObj.CombObject[j] - 1];
                    }
                }
                bool flag = true;
                for (int i = 0; i < graphs.Count; i++)
                    if (IsEqualMatrixes(graphs[i], adjMatrix2, countVert))
                        flag = false;
                if (flag)
                {
                    graphs.Add(adjMatrix2);
                    PrintF(fsw, graphs[graphs.Count - 1], countVert);
                }

            } while (combObj.NextPermutation());
            fsw.Close();
            System.Diagnostics.Process.Start("Task5.txt");
        }

        public static void Task6()
        {
            int p, q, countGraphs = 0;   // кол-во вершины, ребра, графов
            Console.WriteLine("Хар-ки графа (p,q): ");
            p = Convert.ToInt32(Console.ReadLine());
            q = Convert.ToInt32(Console.ReadLine());

            bool[,] adjMatrix = new bool[p, p];
            int[,] allEdges = new int[2, (p - 1) * p];
            Combinatorics combObj = new Combinatorics();
            combObj.Object(p, 2, false);    // создаем сочетание для ребер
            // заполняем матрицу со всеми ребрами графа
            for (int i = 0; i < (p - 1) * p; i++)
            {
                allEdges[0, i] = combObj.CombObject[0];
                allEdges[1, i] = combObj.CombObject[1];
                combObj.NextAccommodation();
            }
            combObj.Object((p - 1) * p, q, false);  // создаем сочетание для выбора ребер в матрицу
            StreamWriter fsw = new StreamWriter("Task6.txt");
            do
            {
                ResetMatrix(adjMatrix, p);  // обнуляем матр чтобы не было старых данных
                for (int i = 0; i < q; i++) // идем по всем ребрам в сочетании
                {
                    adjMatrix[allEdges[0, combObj.CombObject[i] - 1] - 1, allEdges[1, combObj.CombObject[i] - 1] - 1] = true;
                }
                countGraphs++;
                PrintF(fsw, adjMatrix, p);  // запись матр в файл
            } while (combObj.NextCombination());
            fsw.WriteLine("Кол-во графов:" + countGraphs);
            // закрываем поток и открываем файл
            fsw.Close();
            System.Diagnostics.Process.Start("Task6.txt");
        }

        public static void Task7()
        {
            int p, countGraphs = 0;   // кол-во вершины, ребра, графов
            Console.WriteLine("Хар-ки графа (p): ");
            p = Convert.ToInt32(Console.ReadLine());

            bool[,] adjMatrix = new bool[p, p];
            int[,] allEdges = new int[2, (p - 1) * p];
            Combinatorics combObj = new Combinatorics();
            combObj.Object(p, 2, false);    // создаем сочетание для ребер
            // заполняем матрицу со всеми ребрами графа
            for (int i = 0; i < (p - 1) * p; i++)
            {
                allEdges[0, i] = combObj.CombObject[0];
                allEdges[1, i] = combObj.CombObject[1];
                combObj.NextAccommodation();
            }
            
            StreamWriter fsw = new StreamWriter("Task7.txt");
            for (int q = 0; q <= (p - 1) * p; q++)
            {
                combObj.Object((p - 1) * p, q, false);  // создаем сочетание для выбора ребер в матрицу
                do
                {
                    ResetMatrix(adjMatrix, p);  // обнуляем матр чтобы не было старых данных
                    for (int i = 0; i < q; i++) // идем по всем ребрам в сочетании
                    {
                        adjMatrix[allEdges[0, combObj.CombObject[i] - 1] - 1, allEdges[1, combObj.CombObject[i] - 1] - 1] = true;
                    }
                    countGraphs++;
                    PrintF(fsw, adjMatrix, p);  // запись матр в файл
                } while (combObj.NextCombination());
            }
            fsw.WriteLine("Кол-во графов:" + countGraphs);
            // закрываем поток и открываем файл
            fsw.Close();
            System.Diagnostics.Process.Start("Task7.txt");
        }
    }
}
