using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography;


namespace CrosswordPuzzle
{
    public partial class CrosswordForm : Form
    {
        HintForm hint_window;
        List<id_cells> idc = new List<id_cells>();
        public String puzzle_file = Application.StartupPath + "\\Puzzles\\puzzle_1.pzl";

        public CrosswordForm()
        {
            hint_window = new HintForm(this);
            hint_window.Visible = false; // Скрытие HintForm при старте
            buildWordList();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void ShowHintForm()
        {
            hint_window.Show();
        }

        public void HideHintForm()
        {
            hint_window.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данил Лущуков");
        }

        private void buildWordList()
        {
            String line = "";
            using (StreamReader s = new StreamReader(puzzle_file))
            {
                line = s.ReadLine();
                while ((line = s.ReadLine()) != null)
                {
                    String[] l = line.Split('|');
                    idc.Add(new id_cells(Int32.Parse(l[0]), Int32.Parse(l[1]), l[2], l[3], l[4], l[5]));
                    hint_window.hintsTable.Rows.Add(new String[] { l[3], l[2], l[5] });
                }
            }
        }

        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            InitializeBoard();
            hint_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            hint_window.StartPosition = FormStartPosition.Manual;

            hint_window.Show();
            hint_window.hintsTable.AutoResizeColumns();
        }

        private void InitializeBoard()
        {
            board.BackgroundColor = Color.Black;
            board.DefaultCellStyle.BackColor = Color.Black;

            for (int i = 0; i < 21; i++)
            {
                board.Rows.Add();
            }

            //Размер столбцов
            foreach (DataGridViewColumn c in board.Columns)
                c.Width = board.Width / board.Columns.Count;

            //Размер строк
            foreach (DataGridViewRow r in board.Rows)
                r.Height = board.Height / board.Rows.Count;

            //Все ячейки только для чтения
            for (int row = 0; row < board.Rows.Count; row++)
            {
                for (int col = 0; col < board.Columns.Count; col++)
                {
                    board[col, row].ReadOnly = true;
                }
            }

            foreach (id_cells i in idc)
            {
                int start_col = i.X;
                int start_row = i.Y;
                char[] word = i.word.ToCharArray();

                for (int j = 0; j < word.Length; j++)
                {
                    if (i.direction.ToUpper() == "ГОРИЗОНТАЛЬНО")
                        formatCell(start_row, start_col + j, word[j].ToString());
                    if (i.direction.ToUpper() == "ВЕРТИКАЛЬНО")
                        formatCell(start_row + j, start_col, word[j].ToString());
                }
            }

        }

        private void formatCell(int row, int col, String letter)
        {
            DataGridViewCell c = board[col, row];
            c.Style.BackColor = Color.White;
            c.ReadOnly = false;
            c.Style.SelectionBackColor = Color.Gray;
            c.Tag = letter;
        }

        private void CrosswordForm_LocationChanged(object sender, EventArgs e)
        {
            hint_window.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
        }

        private void board_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Сделать буквы заглавными
            try
            {
                board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
            }
            catch
            {
            }

            //Оставить первую введённую букву
            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().Length > 1)
                    board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(0, 1);
            }
            catch
            {
            }

            //Изменить цвет ячейки
            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper().Equals(board[e.ColumnIndex, e.RowIndex].Tag.ToString().ToUpper()))
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGreen;
                else
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
            }
            catch
            {
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Puzzle Files|*.pzl";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadPuzzle(openFileDialog.FileName); // Вызов метода на текущем экземпляре формы
            }
        }

        public void LoadPuzzle(string filePath)
        {
            // Очистка текущих данных
            puzzle_file = filePath;
            board.Rows.Clear();
            hint_window.hintsTable.Rows.Clear();
            idc.Clear();

            // Построение списка слов
            buildWordList();

            // Инициализация доски
            InitializeBoard();
        }


        private void board_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var number = "";
            var matchingCell = idc.FirstOrDefault(c => (number = c.number) != "" && c.X == e.ColumnIndex && c.Y == e.RowIndex);

            if (matchingCell != null)
            {
                e.Value = number + " " + e.Value;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                e.CellStyle.ForeColor = Color.Black;

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Проверяем, является ли причина закрытия стандартной (например, клик по крестику)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Закрытие всех окон приложения
                Application.Exit();
            }
        }


    }

    public class id_cells
    {
        public int X;
        public int Y;
        public String direction;
        public String number;
        public String word;
        public String hint;

        public id_cells(int x, int y, String d, String n, String w, String h)
        {
            this.X = x;
            this.Y = y;
            this.direction = d;
            this.number = n;
            this.word = w;
            this.hint = h;
        }

    }
}
