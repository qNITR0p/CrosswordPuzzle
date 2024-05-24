using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosswordPuzzle
{
    public partial class MainForm : Form
    {
        private CrosswordForm crosswordFormInstance; // Экземпляр CrosswordForm
        private HintForm hintFormInstance; // Экземпляр HintForm
        public MainForm()
        {
            InitializeComponent();
            crosswordFormInstance = new CrosswordForm(); // Инициализация экземпляра при создании MainForm
            crosswordFormInstance.Show(); // Отображение формы при запуске приложения
            crosswordFormInstance.Visible = false; // Скрытие формы при старте
            crosswordFormInstance.HideHintForm(); // Показ HintForm при загрузке кроссворда
            hintFormInstance = new HintForm(crosswordFormInstance);
            hintFormInstance.Visible = false; // Скрытие HintForm при старте
        }

        private void Genbtn_Click(object sender, EventArgs e)
        {
            NewCrosswordForm newGenForm = new NewCrosswordForm();
            newGenForm.ShowDialog();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Puzzle Files|*.pzl";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                crosswordFormInstance.LoadPuzzle(openFileDialog.FileName); // Использование существующего экземпляра
                crosswordFormInstance.Visible = true; // Показывание формы
                crosswordFormInstance.ShowHintForm(); // Показ HintForm при загрузке кроссворда
                this.Hide();
            }
        }
    }
}
