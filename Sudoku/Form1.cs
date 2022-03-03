using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Text = "Sudoku";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new(900,600);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            pictureBox1.Location = new(this.Width / 2 - 225, 50);
            pictureBox1.Size = new(450, 450);
            pictureBox1.BackColor = Color.White;

            label1.Text = "Текущая клетка \r\nпо горизонтали:";
            label2.Text = "Текущая клетка \r\nпо вертикали:";
            label1.Location = new(700, 100);
            label2.Location = new(700, 150);
            label1.Visible = false;
            label2.Visible = false;

            button1.Location = new(385, 515);

            DebugMenu1Item.Visible = false;

            StartGameMenu1Item.Click += StartGame_Click;
            RestartMenu1Item.Click += RestartGame_Click;
            AboutMenu1Item.Click += AboutBox_Click;
            DebugMenu1Item.Click += Debug_Click;

            EasyDiffSubMenu1Item.Click += EasyDiff_Click;
            MediumDiffSubMenu1Item.Click += MediumDiff_Click;
            HardDiffSubMenu1Item.Click += HardDiff_Click;
            SetupDiffSubMenu1Item.Click += SetupDiff_Click;
        }

        Grid NumbArr = new();

        private int[] grid1;
        private int[] grid2;
        private int[,] checkArr;
        private int Difficulty;

        private void StartGame_Click(object sender, EventArgs e)
        {
            if (Difficulty == 0) Difficulty = 10;
            GeneratingGrid();
        }

        private void RestartGame_Click(object sender, EventArgs e)
        {
            NumbArr.NeedCleanUp = true;
        }

        private void AboutBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sudoku v1.1","О программе");
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
            {
                label1.Visible = false;
                label2.Visible = false;
                label1.Text = "Текущая клетка \r\nпо горизонтали: ";
                label2.Text = "Текущая клетка \r\nпо вертикали: ";
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void EasyDiff_Click(object sender, EventArgs e)
        {
            Random rnd = new();

            Difficulty = rnd.Next(36, 42);
        }

        private void MediumDiff_Click(object sender, EventArgs e)
        {
            Random rnd = new();

            Difficulty = rnd.Next(41, 47);
        }

        private void HardDiff_Click(object sender, EventArgs e)
        {
            Random rnd = new();

            Difficulty = rnd.Next(46, 52);
        }

        private void SetupDiff_Click(object sender, EventArgs e)
        {
            try
            {
                Difficulty = 81 - Convert.ToInt32(Interaction.InputBox("Введите количество оставшихся цифр", "Сложность", "1"));
            }
            catch (Exception ex)
            {
                throw;
            }           
        }

        //Создание решения игры
        private void GeneratingGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NumbArr.NumbGridSolution[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }

            Random rnd = new();

            for (int i = 0; i < 100; i++)
            {
                int val = rnd.Next(0, 6);
                int area = rnd.Next(0, 3);
                int y1 = rnd.Next(0, 3);
                int y2 = rnd.Next(0, 3);

                while (y2 == y1)
                {
                    y2 = rnd.Next(0, 3);
                }

                switch (val)
                {
                    case 0:
                        ChangeColumnPlace(NumbArr.NumbGridSolution, area*3 + y1, area * 3 + y2);
                        break;

                    case 1:
                        RotateClockwise(NumbArr.NumbGridSolution);
                        ChangeColumnPlace(NumbArr.NumbGridSolution, area * 3 + y1, area * 3 + y2);
                        RotateCounterClockwise(NumbArr.NumbGridSolution);
                        break;

                    case 2:
                        RotateClockwise(NumbArr.NumbGridSolution);
                        break;

                    case 3:
                        RotateCounterClockwise(NumbArr.NumbGridSolution);
                        break;

                    case 4:
                        MirrorHorizontal(NumbArr.NumbGridSolution);
                        break;

                    case 5:
                        MirrorVertical(NumbArr.NumbGridSolution);
                        break;

                    default:
                        break;
                }
            }

            int pos = 0;
            grid1 = new int[81];
            grid2 = new int[81];

            // Создание стартового поля
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NumbArr.NumbGridStart[i, j] = NumbArr.NumbGridSolution[i, j];
                    grid1[pos] = NumbArr.NumbGridStart[i, j];
                    grid2[pos] = NumbArr.NumbGridStart[i, j];
                    pos++;
                }
            }
            
            int y = rnd.Next(0, 9);
            int x = rnd.Next(0, 9);
            checkArr = new int[2, Difficulty];
            bool solvable = true;

            for (int i = 0; i < Difficulty; i++)
            {
                do
                {
                    bool uniqueCell = false;

                    while (!uniqueCell & i != 0)
                    {
                        if (!CellChecked(y, x, i + 1, checkArr))
                        {
                            y = rnd.Next(0, 9);
                            x = rnd.Next(0, 9);
                        }
                        else uniqueCell = true;
                    }

                    solvable = true;
                    NumbArr.NumbGridStart[y, x] = 0;
                    grid1[y * 9 + x] = 0;
                    grid2[y * 9 + x] = 0;

                    checkArr[0, i] = y;
                    checkArr[1, i] = x;

                    solve(1);
                    solve(2);

                    for (int t = 0; t <= i; t++)
                    {
                        if (grid1[checkArr[0, t] * 9 + checkArr[1, t]] != grid2[checkArr[0, t] * 9 + checkArr[1, t]])
                        {
                            solvable = false;
                            NumbArr.NumbGridStart[y, x] = NumbArr.NumbGridSolution[y, x];
                            y = rnd.Next(0, 9);
                            x = rnd.Next(0, 9);

                            for (int j = 0; j < i; j++)
                            {
                                grid1[checkArr[0, j] * 9 + checkArr[1, j]] = 0;
                                grid2[checkArr[0, j] * 9 + checkArr[1, j]] = 0;
                            }
                            break;
                        }
                    }                   
                } while (!solvable);
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    NumbArr.NumbGridCurrent[i, j] = NumbArr.NumbGridStart[i, j];
                }
            }

            NumbArr.IsStarted = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //Отрисовка линий поля
            using Graphics g = Graphics.FromImage(pictureBox1.Image);
            {
                g.Clear(Color.White);

                // Отрисовка нажатой клетки
                if (NumbArr.IsStarted)
                {
                    Rectangle rect = new(pictureBox1.Width * NumbArr.ClickedCellX / 9, pictureBox1.Height * NumbArr.ClickedCellY / 9, pictureBox1.Width / 9, pictureBox1.Height / 9);
                    if (NumbArr.IsClicked) g.FillRectangle(new SolidBrush(Color.LightSkyBlue), rect);
                    
                    // Отрисовка цифр на поле                    
                    if (NumbArr.NeedCleanUp)
                    {
                        DrawCycle(g, NumbArr.NeedCleanUp);
                        NumbArr.NeedCleanUp = false;
                    }
                    else DrawCycle(g, NumbArr.NeedCleanUp);
                }

                // Отрисовка линий поля
                for (int i = 0; i < 9; i++)
                {
                    if (i % 3 != 0)
                    {
                        g.DrawLine(new Pen(Color.Black, 1), pictureBox1.Width * i / 9, 0, pictureBox1.Width * i / 9, pictureBox1.Height);
                        g.DrawLine(new Pen(Color.Black, 1), 0, pictureBox1.Height * i / 9, pictureBox1.Width, pictureBox1.Height * i / 9);
                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Black, 3), pictureBox1.Width * i / 9 - 1, 0, pictureBox1.Width * i / 9 - 1, pictureBox1.Height);
                        g.DrawLine(new Pen(Color.Black, 3), 0, pictureBox1.Height * i / 9 - 1, pictureBox1.Width, pictureBox1.Height * i / 9 - 1);
                    }                       
                }

                g.Flush();
                g.Dispose();
            }
        }

        private void DrawCycle(Graphics g1, bool CleanUp)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (CleanUp) NumbArr.NumbGridCurrent[i, j] = NumbArr.NumbGridStart[i, j];

                    if (NumbArr.NumbGridCurrent[i, j] != 0) g1.DrawString(NumbArr.NumbGridCurrent[i, j].ToString(), new Font("Segoi UI", 28), new SolidBrush(Color.Black), new Point(8 + pictureBox1.Width * j / 9, 3 + pictureBox1.Height * i / 9));
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            NumbArr.ClickedCellX = Convert.ToInt32(e.X) / (pictureBox1.Width / 9);
            NumbArr.ClickedCellY = Convert.ToInt32(e.Y) / (pictureBox1.Height / 9);
            NumbArr.IsClicked = false;

            for (int i = 0; i < Difficulty; i++)
            {
                if (NumbArr.ClickedCellY == checkArr[0, i] && NumbArr.ClickedCellX == checkArr[1, i])
                {
                    label1.Text = "Текущая клетка \r\nпо горизонтали: " + NumbArr.ClickedCellX.ToString();
                    label2.Text = "Текущая клетка \r\nпо вертикали: " + NumbArr.ClickedCellY.ToString();

                    NumbArr.IsClicked = true;
                    break;
                }
            }
        }

        //Обработка нажатой клавиши и изменение информации в массиве текущего поля
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            NumbArr.NonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        NumbArr.NonNumberEntered = true;
                    }
                }
            }

            if (Control.ModifierKeys == Keys.Shift)
            {
                NumbArr.NonNumberEntered = true;
            }
            
            if (NumbArr.IsClicked & !NumbArr.NonNumberEntered)
            {
                if (e.KeyCode >= Keys.D0 & e.KeyCode <= Keys.D9)
                {
                    KeysConverter kc = new();
                    NumbArr.NumbGridCurrent[NumbArr.ClickedCellY, NumbArr.ClickedCellX] = Convert.ToInt32(kc.ConvertToString(e.KeyCode));
                }
                else if (e.KeyCode >= Keys.NumPad0 & e.KeyCode <= Keys.NumPad9)
                {
                    KeysConverter kc = new();
                    NumbArr.NumbGridCurrent[NumbArr.ClickedCellY, NumbArr.ClickedCellX] = Convert.ToInt32(kc.ConvertToString(e.KeyCode - 48));
                }

                NumbArr.IsClicked = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumbArr.NonNumberEntered)
            {
                e.Handled = true;
            }
        }

        //Операции с массивом цифр
        //Перенос столбца в другое место
        private void ChangeColumnPlace(int[,] Arr, int m, int n)
        {
            int buf;
            for (int i = 0; i < 9; i++)
            {
                buf = Arr[i, m];
                Arr[i, m] = Arr[i, n];
                Arr[i, n] = buf;
            }
        }

        //Поворот поля на 90 градусов по часовой стрелке
        private void RotateClockwise(int[,] Arr)
        {
            int[,] buf = new int[9,9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buf[i, j] = Arr[8 - j,i];
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Arr[i, j] = buf[i, j];
                }
            }
        }

        //Поворот поля на 90 градусов против часовой стрелке
        private void RotateCounterClockwise(int[,] Arr)
        {
            int[,] buf = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buf[i, j] = Arr[j, 8 - i];
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Arr[i, j] = buf[i, j];
                }
            }
        }

        //Отразить поле относительно горизонтальной оси симметрии
        private void MirrorHorizontal(int[,] Arr)
        {
            int buf;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buf = Arr[i,j];
                    Arr[i, j] = Arr[8 - i, j];
                    Arr[8 - i, j] = buf;
                }
            }
        }

        //Отразить поле относительно вертикальной оси симметрии
        private void MirrorVertical(int[,] Arr)
        {
            int buf;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buf = Arr[j, i];
                    Arr[j, i] = Arr[j, 8 - i];
                    Arr[j, 8 - i] = buf;
                }
            }
        }

        //Проверка: была ли уже эта ячейка
        private bool CellChecked(int posY, int posX, int count, int[,] Arr)
        {
            for (int i = 0; i < count; i++)
            {
                if (posY == Arr[0, i] & posX == Arr[1, i]) return false;
            }
            return true;
        }

        //Запуск решателя
        private void solve(int dir) // 1 - поиск решения сверху вниз 2 - снизу вверх
        {
            try
            {
                if (dir == 1) SolverDown(0);
                else if (dir == 2) SolverUp(0);
            }
            catch (Exception ex)
            {
                throw;
            }  
        }

        //Решение задачи (проверка от 1 до 9)
        private void SolverDown(int pos)
        {
            if (pos == 81)
            {
                return;
            }

            if (grid1[pos] > 0)
            {
                SolverDown(pos + 1);
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (CheckNumber(i, pos / 9, pos % 9, grid1))
                {
                    grid1[pos] = i;
                    SolverDown(pos + 1);
                    grid1[pos] = 0;
                }
            }

        }

        //Решение задачи (проверка от 9 до 1)
        private void SolverUp(int pos)
        {
            if (pos == 81)
            {
                return;
            }

            if (grid2[pos] > 0)
            {
                SolverUp(pos + 1);
                return;
            }

            for (int i = 9; i >= 1; i--)
            {
                if (CheckNumber(i, pos / 9, pos % 9, grid2))
                {
                    grid2[pos] = i;
                    SolverUp(pos + 1);
                    grid2[pos] = 0;
                }
            }

        }

        //Проверка уникального решения
        private bool UniqueSolution()
        {
            int size = 80;
            for (int i = 0; i < size; i++)
            {
                if (grid1[i] != grid2[i]) return false; 
            }
            return true;
        }

        //Проверка является ли цифра подходящей
        private bool CheckNumber(int numb, int y, int x, int[] grid)
        {
            int boxY = (y / 3) * 3;
            int boxX = (x / 3) * 3;

            for (int i = 0; i < 9; i++)
            {
                if (grid[i * 9 + x] == numb || grid[y * 9 + i] == numb) return false;
                if (grid[(boxY + (i / 3)) * 9 + (boxX + i % 3)] == numb) return false;
            }
            
            return true;
        }

        //Проверка решения
        private void button1_Click(object sender, EventArgs e)
        {
            int mistakes = 0;

            for (int i = 0; i < Difficulty; i++)
            {
                if (NumbArr.NumbGridCurrent[checkArr[0, i], checkArr[1, i]] != NumbArr.NumbGridSolution[checkArr[0, i], checkArr[1, i]])
                {
                    mistakes++;
                }
            }

            if (mistakes == 0) MessageBox.Show("Решено верно", "Ответ");
            else MessageBox.Show("Решено неверно. Количество ошибок: " + mistakes.ToString(), "Ответ");
        }
    }
}
