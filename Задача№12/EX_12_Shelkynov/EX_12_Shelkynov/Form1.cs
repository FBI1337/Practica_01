using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace EX_12_Shelkynov
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

        private void InitializeUI() //обозначение кнопок
        {
            Button btnGenerate = new Button();
            btnGenerate.Text = "Сгенерировать судоку";
            btnGenerate.Size = new Size(150, 30);
            btnGenerate.Location = new Point(10, 300);
            btnGenerate.Click += new EventHandler(btnGenerateSudoku_Click);
            this.Controls.Add(btnGenerate);

            Button btnSaveToFile = new Button();
            btnSaveToFile.Text = "Сохранить в файл";
            btnSaveToFile.Size = new Size(150, 30);
            btnSaveToFile.Location = new Point(10, 340);
            btnSaveToFile.Click += new EventHandler(btnSaveToFile_Click);
            this.Controls.Add(btnSaveToFile);

            Button btnCheckSudoku = new Button();
            btnCheckSudoku.Text = "Проверить судоку";
            btnCheckSudoku.Size = new Size(150, 30);
            btnCheckSudoku.Location = new Point(10, 380);
            btnCheckSudoku.Click += new EventHandler(btnCheckSudoku_Click);
            this.Controls.Add(btnCheckSudoku);

            Button btnClear = new Button();
            btnClear.Text = "Очистить поля";
            btnClear.Size = new Size(150, 30);
            btnClear.Location = new Point(180, 300);
            btnClear.Click += new EventHandler(btnClearFields_Click);
            this.Controls.Add(btnClear);


            Button btnPrint = new Button();
            btnPrint.Text = "Распечатать";
            btnPrint.Size = new Size(150, 30);
            btnPrint.Location = new Point(180, 340);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            this.Controls.Add(btnPrint);


            /*Button btnViseble = new Button();
            btnViseble.Text = "Показать";
            btnViseble.Size = new Size(150, 30);
            btnViseble.Location = new Point(10, 340);
            btnViseble.Click += new EventHandler(btnDisplaySudoku);
            this.Controls.Add(btnViseble);*/
        }

        private void InitializeTextBoxes()//ячейки для ввода или отобржения чисел
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
                    textBox.Multiline = true;
                    textBox.Font = new Font(textBox.Font.FontFamily, 16);
                    textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
                    this.Controls.Add(textBox);
                    textBoxes[i, j] = textBox;
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)//ввод с клавиатуры
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                HighlightCell(textBox, Color.Red);
            }
            else
            {
                HighlightCell(textBox, SystemColors.Window);
            }

            if (char.IsDigit(e.KeyChar))
            {
                int num = int.Parse(e.KeyChar.ToString());
                if (num < 1 || num > 9)
                {
                    e.Handled = true;
                    HighlightCell(textBox, Color.Red);
                }
            }
        }

        private void HighlightCell(TextBox textBox, Color color)
        {
            textBox.BackColor = color;
        }



        private void ColorBlock(int blockRow, int blockCol)//цвета ячеек
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

        private void GenerateSudoku()//функция по генерации судоку
        {
            int[,] sudoku = new int[9, 9];
            GenerateSudokuRecursively(sudoku);
            DisplaySudoku(sudoku);
            //ClearAllFields();
        }

        private bool GenerateSudokuRecursively(int[,] sudoku) //генерация судоку
        {
            Random random = new Random();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int num = random.Next(1, 10);
                    if (IsSafe(sudoku, row, col, num))
                    {
                        sudoku[row, col] = num;
                        if (GenerateSudokuRecursively(sudoku))
                            return true;
                        sudoku[row, col] = 0;
                    }
                }
            }
            return true;
        }

        private bool IsSafe(int[,] sudoku, int row, int col, int num)//проверка числа
        {
            return !UsedInRow(sudoku, row, num) && !UsedInCol(sudoku, col, num) && !UsedInBox(sudoku, row - row % 3, col - col % 3, num);
        }

        private bool UsedInRow(int[,] sudoku, int row, int num)//проверка встречается ли число в строке
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInCol(int[,] sudoku, int col, int num)//проверка встречается ли число в столбце
        {
            for (int row = 0; row < 9; row++)
            {
                if (sudoku[row, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInBox(int[,] sudoku, int boxStartRow, int boxStartCol, int num)//проверка встречается ли число в квадрате 3x3
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

        private void DisplaySudoku(int[,] sudoku)//вывод сгенерированых чисел в текст боксе
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Text = sudoku[i, j] == 0 ? "" : sudoku[i, j].ToString();

                }
            }
        }


        private void SaveSudokuToFile(string filePath) //сохранение судоку
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


        private void PrintSudoku()//распечатать судоку
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)//распечатать судоку
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



        /*
         * 
         * 
         * 
         * 
         * 
         * Класс кнопок
         * 
         * 
         * 
         * 
         */
        private void btnSaveToFile_Click(object sender, EventArgs e)//кнопка сохранения судоку
        {

            if (!CheckSudokuValidity())
            {
                MessageBox.Show("Судоку заполнено неправильно.Пожалуйста, исправьте ошибки перед сохранением.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ColorInvalidSquares();
                return;
            }

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

        private void btnGenerateSudoku_Click(object sender, EventArgs e)//генерирование судоку
        {
            GenerateSudoku();
        }

        private void btnClearFields_Click(object sender, EventArgs e)//поле очистки поля
        {
            ClearAllFields();
        }
        private void btnCheckSudoku_Click(object sender, EventArgs e)//проверка судоку
        {
            if (CheckSudokuValidity())
            {
                MessageBox.Show("Судоку корректно заполнено!", "Проверка судоку", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HighlightInvalidCells();
                MessageBox.Show("Судоку заполнено некорректно!", "Проверка судоку", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)//распечатать судоку 
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintSudoku();
            }
        }

        /*private void btnDisplaySudoku (object sender, EventArgs e)
        {
            DisplaySudoku();
        }*/


        /* 
         * 
         * 
         * 
         *
         * 
         * 
         * 
         * 
         * 
         * 
         */


        private void HighlightInvalidCells()
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.BackColor == Color.Red)
                {
                    HighlightCell(textBox, SystemColors.Window);
                }
            }
        }

        private void ClearAllFields() //очистка полей
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        private void ColorInvalidSquares()//если ячейка не так заполнена
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.BackColor != Color.Red)
                {
                    textBox.BackColor = Color.Red;
                    textBox.ForeColor = Color.White;
                }

            }
        }

        private bool CheckSudokuValidity()//проверка судоку
        {
            // Проверка строк
            for (int row = 0; row < 9; row++)
            {
                bool[] used = new bool[10]; // массив для отметки использованных чисел (от 1 до 9)
                for (int col = 0; col < 9; col++)
                {
                    int num = GetCellValue(row, col);
                    if (num != 0 && used[num])
                        return false;

                    // Проверка, что num находится в допустимом диапазоне (от 1 до 9)
                    if (num >= 1 && num <= 9)
                    {
                        used[num] = true;
                    }
                    else
                    {
                        // Обработка ошибки, например, вывод сообщения об ошибке
                        MessageBox.Show($"Некорректное значение в ячейке ({row + 1}, {col + 1}): {num}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            // Проверка столбцов
            for (int col = 0; col < 9; col++)
            {
                bool[] used = new bool[10]; // массив для отметки использованных чисел (от 1 до 9)
                for (int row = 0; row < 9; row++)
                {
                    int num = GetCellValue(row, col);
                    if (num != 0 && used[num]) // если число уже использовалось в столбце
                        return false;
                    used[num] = true;
                }
            }

            // Проверка блоков 3x3
            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    bool[] used = new bool[10]; // массив для отметки использованных чисел (от 1 до 9)
                    for (int row = blockRow * 3; row < (blockRow + 1) * 3; row++)
                    {
                        for (int col = blockCol * 3; col < (blockCol + 1) * 3; col++)
                        {
                            int num = GetCellValue(row, col);
                            if (num != 0 && used[num]) // если число уже использовалось в блоке 3x3
                                return false;
                            used[num] = true;
                        }
                    }
                }
            }

            return true; // судоку заполнено корректно
        }

        private int[,] GetCurrentSudokuState()//не используется
        {
            int[,] sudoku = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (int.TryParse(textBoxes[i, j].Text, out int value))
                    {
                        sudoku[i, j] = value;
                    }
                    else
                    {
                        sudoku[i, j] = 0; // Если поле не заполнено, ставим 0
                    }
                }
            }
            return sudoku;
        }

        private int GetCellValue(int row, int col)
        {
            if (textBoxes[row, col].Text == " ")
                return 0;

            int value;
            if (int.TryParse(textBoxes[row, col].Text, out value))
            {
                return value;
            }
            else
            {
                // Обработка ошибки, например, возврат значения по умолчанию
                return 0; // или другое значение, которое соответствует вашей логике
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}