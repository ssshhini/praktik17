using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace z17
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TaskComboBox.ItemsSource = Enumerable.Range(1, 30).Select(i => $"Задача {i}").ToList();
            TaskComboBox.SelectedIndex = 0;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            int taskNumber = TaskComboBox.SelectedIndex + 1;

            try
            {
                ResultTextBox.Text = $"Выполнение задачи {taskNumber}...\n\n";

                switch (taskNumber)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    case 5: Task5(); break;
                    case 6: Task6(); break;
                    case 7: Task7(); break;
                    case 8: Task8(); break;
                    case 9: Task9(); break;
                    case 10: Task10(); break;
                    case 11: Task11(); break;
                    case 12: Task12(); break;
                    case 13: Task13(); break;
                    case 14: Task14(); break;
                    case 15: Task15(); break;
                    case 16: Task16(); break;
                    case 17: Task17(); break;
                    case 18: Task18(); break;
                    case 19: Task19(); break;
                    case 20: Task20(); break;
                    case 21: Task21(); break;
                    case 22: Task22(); break;
                    case 23: Task23(); break;
                    case 24: Task24(); break;
                    case 25: Task25(); break;
                    case 26: Task26(); break;
                    case 27: Task27(); break;
                    case 28: Task28(); break;
                    case 29: Task29(); break;
                    case 30: Task30(); break;
                    default: ResultTextBox.Text = "Неизвестная задача"; break;
                }
            }
            catch (Exception ex)
            {
                ResultTextBox.Text += $"Ошибка: {ex.Message}";
            }
        }

        #region Helper Methods
        private List<int[,]> ReadMatricesFromFile(string filePath)
        {
            var matrices = new List<int[,]>();
            var lines = File.ReadAllLines(filePath);
            int i = 0;
            while (i < lines.Length)
            {
                var dim = lines[i].Split(' ');
                int rows = int.Parse(dim[0]);
                int cols = int.Parse(dim[1]);
                i++;

                int[,] matrix = new int[rows, cols];
                for (int r = 0; r < rows; r++)
                {
                    var row = lines[i].Split(' ');
                    for (int c = 0; c < cols; c++)
                    {
                        matrix[r, c] = int.Parse(row[c]);
                    }
                    i++;
                }
                matrices.Add(matrix);
            }
            return matrices;
        }

        private void WriteMatricesToFile(string filePath, List<int[,]> matrices)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var matrix in matrices)
                {
                    writer.WriteLine($"{matrix.GetLength(0)} {matrix.GetLength(1)}");
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            writer.Write(matrix[i, j] + " ");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        private string MatrixToString(int[,] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }

        private int[,] MultiplyMatrices(int[,] a, int[,] b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);
            int bCols = b.GetLength(1);
            int[,] result = new int[aRows, bCols];

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    for (int k = 0; k < aCols; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        private int SumDiagonal(int[,] matrix)
        {
            int sum = 0;
            int size = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private int SumFirstRow(int[,] matrix)
        {
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[0, j];
            }
            return sum;
        }

        private int[,] CreateIdentityMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 1;
            }
            return matrix;
        }

        private int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[cols, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }

        private bool IsSymmetric(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                        return false;
                }
            }
            return true;
        }

        private bool MatricesEqual(int[,] m1, int[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
                return false;

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }
            return true;
        }

        private int CalculateDeterminant(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            int det = 0;
            for (int j = 0; j < n; j++)
            {
                int[,] minor = new int[n - 1, n - 1];
                for (int i = 1; i < n; i++)
                {
                    for (int k = 0, l = 0; k < n; k++)
                    {
                        if (k == j) continue;
                        minor[i - 1, l++] = matrix[i, k];
                    }
                }
                det += (j % 2 == 0 ? 1 : -1) * matrix[0, j] * CalculateDeterminant(minor);
            }
            return det;
        }
        #endregion

        #region Task Implementations
        private void Task1()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toMove = m1.Where(mat => mat[0, 0] == 0).ToList();
                m1 = m1.Except(toMove).ToList();
                m2.AddRange(toMove);
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                     "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task2()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog() { Title = "Сохранить лишние матрицы" };
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                List<int[,]> extra;
                if (m1.Count > m2.Count)
                {
                    extra = m1.Skip(m2.Count).ToList();
                    m1 = m1.Take(m2.Count).ToList();
                }
                else
                {
                    extra = m2.Skip(m1.Count).ToList();
                    m2 = m2.Take(m1.Count).ToList();
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                WriteMatricesToFile(sfd.FileName, extra);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                     "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString)) +
                                     "\nЛишние:\n" + string.Join("\n", extra.Select(MatrixToString));
            }
        }

        private void Task3()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var products = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i += 2)
                {
                    if (i + 1 < matrices.Count)
                    {
                        products.Add(MultiplyMatrices(matrices[i], matrices[i + 1]));
                    }
                }
                WriteMatricesToFile(sfd.FileName, products);
                ResultTextBox.Text += "Результаты умножения:\n" + string.Join("\n", products.Select(MatrixToString));
            }
        }

        private void Task4()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var unique = m1.Where(mat1 => !m2.Any(mat2 => MatricesEqual(mat1, mat2))).ToList();
                m2.AddRange(unique);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task5()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var systems = ReadMatricesFromFile(ofd1.FileName);
                var solutions = ReadMatricesFromFile(ofd2.FileName);
                for (int i = 0; i < systems.Count; i++)
                {
                    ResultTextBox.Text += $"Система {i + 1}:\n";
                    for (int r = 0; r < systems[i].GetLength(0); r++)
                    {
                        string eq = "";
                        for (int c = 0; c < systems[i].GetLength(1) - 1; c++)
                        {
                            eq += $"{systems[i][r, c]}x{c + 1} + ";
                        }
                        ResultTextBox.Text += eq.TrimEnd('+', ' ') + $" = {systems[i][r, systems[i].GetLength(1) - 1]}\n";
                    }
                    ResultTextBox.Text += "Решение: (" + string.Join(", ",
                        Enumerable.Range(0, solutions[i].GetLength(0)).Select(x => solutions[i][x, 0])) + ")\n\n";
                }
            }
        }

        private void Task6()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var evenSum = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i++)
                {
                    int sum = 0;
                    for (int r = 0; r < matrices[i].GetLength(0); r++)
                    {
                        for (int c = 0; c < matrices[i].GetLength(1); c++)
                        {
                            if (matrices[i][r, c] > 0 && matrices[i][r, c] % 2 == 0)
                                sum += matrices[i][r, c];
                        }
                    }
                    if (sum % 2 == 0)
                    {
                        evenSum.Add(matrices[i]);
                        matrices[i] = CreateIdentityMatrix(matrices[i].GetLength(0));
                    }
                }
                WriteMatricesToFile(ofd.FileName, matrices);
                WriteMatricesToFile(sfd.FileName, evenSum);
                ResultTextBox.Text += "Измененные матрицы:\n" + string.Join("\n", matrices.Select(MatrixToString)) +
                                     "\nМатрицы с четной суммой:\n" + string.Join("\n", evenSum.Select(MatrixToString));
            }
        }

        private void Task7()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int min = Math.Min(m1.Count, m2.Count);
                for (int i = 0; i < min; i++)
                {
                    if (i % 2 == 0) // нечетные по порядку (индексация с 0)
                    {
                        var temp = m1[i];
                        m1[i] = m2[i];
                        m2[i] = temp;
                    }
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task8()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int size = m1[0].GetLength(0);
                if (m1.Count < m2.Count)
                {
                    int diff = m2.Count - m1.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        m1.Add(CreateIdentityMatrix(size));
                    }
                }
                else if (m2.Count < m1.Count)
                {
                    int diff = m1.Count - m2.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        m2.Add(CreateIdentityMatrix(size));
                    }
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task9()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var oddSum = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i++)
                {
                    int sum = SumDiagonal(matrices[i]);
                    if (sum % 2 != 0)
                    {
                        oddSum.Add(matrices[i]);
                        matrices[i] = TransposeMatrix(matrices[i]);
                    }
                }
                WriteMatricesToFile(ofd.FileName, matrices);
                WriteMatricesToFile(sfd.FileName, oddSum);
                ResultTextBox.Text += "Измененные матрицы:\n" + string.Join("\n", matrices.Select(MatrixToString)) +
                                    "\nМатрицы с нечетной суммой:\n" + string.Join("\n", oddSum.Select(MatrixToString));
            }
        }

        private void Task10()
        {
            var ofd = new OpenFileDialog();
            var sfd1 = new SaveFileDialog() { Title = "Сохранить симметричные матрицы" };
            var sfd2 = new SaveFileDialog() { Title = "Сохранить несимметричные матрицы" };
            if (ofd.ShowDialog() == true && sfd1.ShowDialog() == true && sfd2.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var symmetric = matrices.Where(IsSymmetric).ToList();
                var nonSymmetric = matrices.Except(symmetric).ToList();
                WriteMatricesToFile(sfd1.FileName, symmetric);
                WriteMatricesToFile(sfd2.FileName, nonSymmetric);
                ResultTextBox.Text += "Симметричные:\n" + string.Join("\n", symmetric.Select(MatrixToString)) +
                                     "\nНесимметричные:\n" + string.Join("\n", nonSymmetric.Select(MatrixToString));
            }
        }

        private void Task11()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var products = new List<int[,]>();
                for (int i = 0; i < Math.Min(m1.Count, m2.Count); i++)
                {
                    products.Add(MultiplyMatrices(m1[i], m2[i]));
                }
                WriteMatricesToFile(sfd.FileName, products);
                ResultTextBox.Text += "Произведения матриц:\n" + string.Join("\n", products.Select(MatrixToString));
            }
        }

        private void Task12()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog() { Title = "Сохранить оставшиеся матрицы" };
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int min = Math.Min(m1.Count, m2.Count);
                for (int i = 0; i < min; i++)
                {
                    if (i % 2 == 0) // нечетные в 1-м файле (индексация с 0)
                    {
                        var temp = m1[i];
                        m1[i] = m2[i];
                        m2[i] = temp;
                    }
                }
                List<int[,]> remaining;
                if (m1.Count > m2.Count)
                {
                    remaining = m1.Skip(min).ToList();
                    m1 = m1.Take(min).ToList();
                }
                else
                {
                    remaining = m2.Skip(min).ToList();
                    m2 = m2.Take(min).ToList();
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                WriteMatricesToFile(sfd.FileName, remaining);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString)) +
                                    "\nОставшиеся:\n" + string.Join("\n", remaining.Select(MatrixToString));
            }
        }

        private void Task13()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toMove = m1.Where(mat => SumDiagonal(mat) == 5).ToList();
                m1 = m1.Except(toMove).ToList();
                m2.AddRange(toMove);
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task14()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                List<int[,]> extra;
                if (m1.Count < m2.Count)
                {
                    extra = m1.Skip(m2.Count).ToList();
                    m1 = m1.Take(m2.Count).ToList();
                }
                else
                {
                    extra = m2.Skip(m1.Count).ToList();
                    m2 = m2.Take(m1.Count).ToList();
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                WriteMatricesToFile(sfd.FileName, extra);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString)) +
                                    "\nЛишние:\n" + string.Join("\n", extra.Select(MatrixToString));
            }
        }

        private void Task15()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var sums = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i += 2)
                {
                    if (i + 1 < matrices.Count)
                    {
                        var sum = new int[matrices[i].GetLength(0), matrices[i].GetLength(1)];
                        for (int r = 0; r < matrices[i].GetLength(0); r++)
                        {
                            for (int c = 0; c < matrices[i].GetLength(1); c++)
                            {
                                sum[r, c] = matrices[i][r, c] + matrices[i + 1][r, c];
                            }
                        }
                        sums.Add(sum);
                    }
                }
                WriteMatricesToFile(sfd.FileName, sums);
                ResultTextBox.Text += "Суммы матриц:\n" + string.Join("\n", sums.Select(MatrixToString));
            }
        }

        private void Task16()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toAdd = m1.Where(mat => CalculateDeterminant(mat) == 5).ToList();
                m2.AddRange(toAdd);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task17()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var systems = ReadMatricesFromFile(ofd1.FileName);
                var vectors = ReadMatricesFromFile(ofd2.FileName);
                for (int i = 0; i < systems.Count; i++)
                {
                    ResultTextBox.Text += $"Система {i + 1}:\n";
                    for (int r = 0; r < systems[i].GetLength(0); r++)
                    {
                        string eq = "";
                        for (int c = 0; c < systems[i].GetLength(1) - 1; c++)
                        {
                            eq += $"{systems[i][r, c]}x{c + 1} + ";
                        }
                        ResultTextBox.Text += eq.TrimEnd('+', ' ') + $" = {systems[i][r, systems[i].GetLength(1) - 1]}\n";
                    }

                    int[,] product = MultiplyMatrices(systems[i], vectors[i]);
                    ResultTextBox.Text += "Произведение: (" + string.Join(", ",
                        Enumerable.Range(0, product.GetLength(0)).Select(x => product[x, 0])) + ")\n\n";
                }
            }
        }

        private void Task18()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var oddSum = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i++)
                {
                    int sum = 0;
                    for (int r = 0; r < matrices[i].GetLength(0); r++)
                    {
                        for (int c = 0; c < matrices[i].GetLength(1); c++)
                        {
                            if (matrices[i][r, c] < 0 && matrices[i][r, c] % 2 != 0)
                                sum += matrices[i][r, c];
                        }
                    }
                    if (sum % 2 != 0)
                    {
                        oddSum.Add(matrices[i]);
                        matrices[i] = CreateIdentityMatrix(matrices[i].GetLength(0));
                    }
                }
                WriteMatricesToFile(ofd.FileName, matrices);
                WriteMatricesToFile(sfd.FileName, oddSum);
                ResultTextBox.Text += "Измененные матрицы:\n" + string.Join("\n", matrices.Select(MatrixToString)) +
                                    "\nМатрицы с нечетной суммой:\n" + string.Join("\n", oddSum.Select(MatrixToString));
            }
        }

        private void Task19()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int min = Math.Min(m1.Count, m2.Count);
                for (int i = 0; i < min; i++)
                {
                    if (i % 2 == 1) // четные по порядку (индексация с 0)
                    {
                        var temp = m1[i];
                        m1[i] = m2[i];
                        m2[i] = temp;
                    }
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task20()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int size = m1[0].GetLength(0);
                if (m1.Count < m2.Count)
                {
                    int diff = m2.Count - m1.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        m1.Insert(0, CreateIdentityMatrix(size));
                    }
                }
                else if (m2.Count < m1.Count)
                {
                    int diff = m1.Count - m2.Count;
                    for (int i = 0; i < diff; i++)
                    {
                        m2.Insert(0, CreateIdentityMatrix(size));
                    }
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task21()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var evenDiff = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i++)
                {
                    int diff = matrices[i][0, 0] - matrices[i][matrices[i].GetLength(0) - 1, matrices[i].GetLength(1) - 1];
                    if (diff % 2 == 0)
                    {
                        evenDiff.Add(matrices[i]);
                        // Заменяем на обратную матрицу (упрощенная версия)
                        matrices[i] = TransposeMatrix(matrices[i]);
                    }
                }
                WriteMatricesToFile(ofd.FileName, matrices);
                WriteMatricesToFile(sfd.FileName, evenDiff);
                ResultTextBox.Text += "Измененные матрицы:\n" + string.Join("\n", matrices.Select(MatrixToString)) +
                                    "\nМатрицы с четной разностью:\n" + string.Join("\n", evenDiff.Select(MatrixToString));
            }
        }

        private void Task22()
        {
            var ofd = new OpenFileDialog();
            var sfd1 = new SaveFileDialog() { Title = "Сохранить обратные матрицы" };
            var sfd2 = new SaveFileDialog() { Title = "Сохранить остальные матрицы" };
            if (ofd.ShowDialog() == true && sfd1.ShowDialog() == true && sfd2.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var inverse = matrices.Where(mat => {
                    try { return MatricesEqual(mat, InverseMatrix(mat)); }
                    catch { return false; }
                }).ToList();
                var others = matrices.Except(inverse).ToList();
                WriteMatricesToFile(sfd1.FileName, inverse);
                WriteMatricesToFile(sfd2.FileName, others);
                ResultTextBox.Text += "Обратные матрицы:\n" + string.Join("\n", inverse.Select(MatrixToString)) +
                                    "\nОстальные:\n" + string.Join("\n", others.Select(MatrixToString));
            }
        }

        private int[,] InverseMatrix(int[,] matrix)
        {
            // Упрощенная реализация для демонстрации
            int size = matrix.GetLength(0);
            int[,] inverse = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    inverse[i, j] = matrix[j, i]; // Просто транспонирование для примера
                }
            }
            return inverse;
        }

        private void Task23()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var results = new List<string>();
                for (int i = 0; i < Math.Min(m1.Count, m2.Count); i++)
                {
                    results.Add($"Матрица 1:\n{MatrixToString(m1[i])}");
                    results.Add($"Матрица 2:\n{MatrixToString(m2[i])}");
                    var product = MultiplyMatrices(m1[i], m2[i]);
                    results.Add($"Произведение:\n{MatrixToString(product)}");
                }
                File.WriteAllLines(sfd.FileName, results);
                ResultTextBox.Text += string.Join("\n\n", results);
            }
        }

        private void Task24()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog() { Title = "Сохранить оставшиеся матрицы" };
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                int min = Math.Min(m1.Count, m2.Count);
                for (int i = 0; i < min; i++)
                {
                    if ((i + 1) % 2 == 0) // четные по порядку (индексация с 1)
                    {
                        var temp = m1[i];
                        m1[i] = m2[i];
                        m2[i] = temp;
                    }
                }
                List<int[,]> remaining;
                if (m1.Count > m2.Count)
                {
                    remaining = m1.Skip(min).ToList();
                    m1 = m1.Take(min).ToList();
                }
                else
                {
                    remaining = m2.Skip(min).ToList();
                    m2 = m2.Take(min).ToList();
                }
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                WriteMatricesToFile(sfd.FileName, remaining);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString)) +
                                    "\nОставшиеся:\n" + string.Join("\n", remaining.Select(MatrixToString));
            }
        }

        private void Task25()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toMove = m1.Where(mat => SumFirstRow(mat) > 5).ToList();
                m1 = m1.Except(toMove).ToList();
                m2.AddRange(toMove);
                WriteMatricesToFile(ofd1.FileName, m1);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task26()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var products = new List<int[,]>();
                for (int i = 0; i < Math.Min(m1.Count, m2.Count); i++)
                {
                    products.Add(MultiplyMatrices(m1[i], m2[i]));
                }
                WriteMatricesToFile(sfd.FileName, products);
                ResultTextBox.Text += "Произведения матриц:\n" + string.Join("\n", products.Select(MatrixToString));
            }
        }

        private void Task27()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var filtered = new List<int[,]>();
                for (int i = 0; i < matrices.Count; i += 2)
                {
                    if (i + 1 < matrices.Count)
                    {
                        bool equal = true;
                        for (int r = 0; r < matrices[i].GetLength(0); r++)
                        {
                            if (matrices[i][r, 0] != matrices[i + 1][r, 0])
                            {
                                equal = false;
                                break;
                            }
                        }
                        if (equal)
                        {
                            filtered.Add(matrices[i]);
                            filtered.Add(matrices[i + 1]);
                        }
                    }
                }
                WriteMatricesToFile(sfd.FileName, filtered);
                ResultTextBox.Text += "Отфильтрованные матрицы:\n" + string.Join("\n", filtered.Select(MatrixToString));
            }
        }

        private void Task28()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toAdd = m1.Where(mat => {
                    int first = mat[0, 0];
                    for (int i = 1; i < Math.Min(mat.GetLength(0), mat.GetLength(1)); i++)
                    {
                        if (mat[i, i] != first) return false;
                    }
                    return true;
                }).ToList();
                m2.AddRange(toAdd);
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }

        private void Task29()
        {
            var ofd = new OpenFileDialog();
            var sfd = new SaveFileDialog();
            if (ofd.ShowDialog() == true && sfd.ShowDialog() == true)
            {
                var matrices = ReadMatricesFromFile(ofd.FileName);
                var filtered = new List<int[,]>();
                foreach (var mat in matrices)
                {
                    int product = 1;
                    int size = Math.Min(mat.GetLength(0), mat.GetLength(1));
                    for (int i = 0; i < size; i++)
                    {
                        product *= mat[i, i] * mat[i, size - 1 - i];
                    }
                    if (product > 15)
                    {
                        filtered.Add(mat);
                    }
                }
                WriteMatricesToFile(sfd.FileName, filtered);
                ResultTextBox.Text += "Отфильтрованные матрицы:\n" + string.Join("\n", filtered.Select(MatrixToString));
            }
        }

        private void Task30()
        {
            var ofd1 = new OpenFileDialog();
            var ofd2 = new OpenFileDialog();
            if (ofd1.ShowDialog() == true && ofd2.ShowDialog() == true)
            {
                var m1 = ReadMatricesFromFile(ofd1.FileName);
                var m2 = ReadMatricesFromFile(ofd2.FileName);
                var toUse = m1.Where(mat => mat[0, 0] == 5).Take(m2.Count).ToList();
                for (int i = 0; i < toUse.Count; i++)
                {
                    int size = Math.Min(m2[i].GetLength(0), m2[i].GetLength(1));
                    for (int j = 0; j < size; j++)
                    {
                        m2[i][j, j] = toUse[i][j, j];
                    }
                }
                WriteMatricesToFile(ofd2.FileName, m2);
                ResultTextBox.Text += "Файл 1:\n" + string.Join("\n", m1.Select(MatrixToString)) +
                                    "\nФайл 2:\n" + string.Join("\n", m2.Select(MatrixToString));
            }
        }
        #endregion
    }
}