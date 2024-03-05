using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Linq;

namespace SudokuGenerator
{
    public partial class Form1 : Form
    {
        Color[,] blockColors = {
            { Color.LightBlue, Color.LightCoral, Color.LightGreen },
            { Color.LightGoldenrodYellow, Color.LightPink, Color.LightSalmon },
            { Color.LightSkyBlue, Color.LightGray, Color.LightSeaGreen }
        };

        private TextBox[,] textBoxes;

        public Form1()
        {
            InitializeComponent();
            InitializeTextBoxes();
            ColorAllBlocks();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Button btnGenerate = new Button();
            btnGenerate.Text = "Сгенерировать судоку";
            btnGenerate.Size = new Size(150, 30);
            btnGenerate.Location = new Point(10, 300);
            btnGenerate.Click += new EventHandler(btnGenerateSudoku_Click);
            this.Controls.Add(btnGenerate);

            Button btnClear = new Button();
            btnClear.Text = "Очистить поля";
            btnClear.Size = new Size(150, 30);
            btnClear.Location = new Point(180, 300);
            btnClear.Click += new EventHandler(btnClearFields_Click);
            this.Controls.Add(btnClear);

            Button btnSaveToFile = new Button();
            btnSaveToFile.Text = "Сохранить в файл";
            btnSaveToFile.Size = new Size(150, 30);
            btnSaveToFile.Location = new Point(10, 340);
            btnSaveToFile.Click += new EventHandler(btnSaveToFile_Click);
            this.Controls.Add(btnSaveToFile);

            Button btnPrint = new Button();
            btnPrint.Text = "Распечатать";
            btnPrint.Size = new Size(150, 30);
            btnPrint.Location = new Point(180, 340);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            this.Controls.Add(btnPrint);
        }

        private void InitializeTextBoxes()
        {
            textBoxes = new TextBox[9, 9];
            int textBoxSize = 30;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Size = new System.Drawing.Size(textBoxSize, textBoxSize);
                    textBox.Location = new System.Drawing.Point(j * (textBoxSize + 3), i * (textBoxSize + 3));
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.ReadOnly = true;
                    textBox.Multiline = true;
                    textBox.Font = new Font(textBox.Font.FontFamily, 16);
                    this.Controls.Add(textBox);
                    textBoxes[i, j] = textBox;
                }
            }
        }

        private void ColorBlock(int blockRow, int blockCol)
        {
            for (int i = blockRow * 3; i < (blockRow + 1) * 3; i++)
            {
                for (int j = blockCol * 3; j < (blockCol + 1) * 3; j++)
                {
                    textBoxes[i, j].BackColor = blockColors[blockRow, blockCol];
                    textBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void ColorAllBlocks()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ColorBlock(i, j);
                }
            }
        }

        private void GenerateSudoku()
        {
            int[,] sudoku = new int[9, 9];
            GenerateSudokuRecursively(sudoku);
            DisplaySudoku(sudoku);
        }

        private bool GenerateSudokuRecursively(int[,] sudoku)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudoku[row, col] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsSafe(sudoku, row, col, num))
                            {
                                sudoku[row, col] = num;
                                if (GenerateSudokuRecursively(sudoku))
                                    return true;
                                sudoku[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsSafe(int[,] sudoku, int row, int col, int num)
        {
            return !UsedInRow(sudoku, row, num) && !UsedInCol(sudoku, col, num) && !UsedInBox(sudoku, row - row % 3, col - col % 3, num);
        }

        private bool UsedInRow(int[,] sudoku, int row, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInCol(int[,] sudoku, int col, int num)
        {
            for (int row = 0; row < 9; row++)
            {
                if (sudoku[row, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInBox(int[,] sudoku, int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (sudoku[row + boxStartRow, col + boxStartCol] == num)
                        return true;
                }
            }
            return false;
        }

        private void DisplaySudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Text = sudoku[i, j].ToString();
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FileName = "sudoku.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSudokuToFile(saveFileDialog.FileName);
            }
        }

        private void SaveSudokuToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            string value = textBoxes[i, j].Text;
                            if (string.IsNullOrEmpty(value))
                            {
                                writer.Write("0 ");
                            }
                            else
                            {
                                writer.Write(value + " ");
                            }
                        }
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Судоку успешно сохранено в файл " + filePath, "Сохранение завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении судоку: " + ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintSudoku();
            }
        }

        private void PrintSudoku()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);

            float x = 50, y = 50;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    graphics.DrawString(textBoxes[i, j].Text, font, Brushes.Black, x, y);
                    x += 30;
                }
                x = 50;
                y += 30;
            }
        }

        private void btnGenerateSudoku_Click(object sender, EventArgs e)
        {
            GenerateSudoku();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
