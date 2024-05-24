using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CrosswordPuzzle
{
    public partial class NewCrosswordForm : Form
    {
        public NewCrosswordForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("География");
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            GenerateAndSavePuzzleFromDatabase();
        }

        public static string GenerateUniquePuzzleFileName(string baseName, string folderPath)
        {
            int fileNumber = 1;
            string fileName = $"{baseName}_{fileNumber}.pzl";
            string fullPath = Path.Combine(folderPath, fileName);

            while (File.Exists(fullPath))
            {
                fileNumber++;
                fileName = $"{baseName}_{fileNumber}.pzl";
                fullPath = Path.Combine(folderPath, fileName);
            }

            return fullPath;
        }

        private Dictionary<string, string> wordToHintMap = new Dictionary<string, string>();

        private Dictionary<string, List<(int, int)>> usedCoordinates = new Dictionary<string, List<(int, int)>>(); // Используемые координаты для каждого слова

        private void GenerateAndSavePuzzleFromDatabase()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database\CrosswordBD.accdb;Persist Security Info=False;";
            string selectedCategory = comboBox1.SelectedItem.ToString();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT Код, Тематика, Слово, Подсказка FROM CrossWord WHERE Тематика =? ORDER BY RND()*1000000";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", selectedCategory);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        List<string> wordsList = new List<string>();
                        while (reader.Read())
                        {
                            string word = reader["Слово"].ToString();
                            string hint = reader["Подсказка"].ToString();
                            wordsList.Add(word);
                            wordToHintMap[word] = hint;
                            if (!usedCoordinates.ContainsKey(word))
                            {
                                usedCoordinates[word] = new List<(int, int)>();
                            }
                        }

                        Random random = new Random();
                        Shuffle(wordsList, random);

                        wordsList = wordsList.Take(10).ToList();

                        string puzzlesFolderPath = Path.Combine(Application.StartupPath, "Puzzles");
                        if (!Directory.Exists(puzzlesFolderPath)) Directory.CreateDirectory(puzzlesFolderPath);

                        string puzzleFileName = GenerateUniquePuzzleFileName("puzzle", puzzlesFolderPath);
                        using (StreamWriter writer = new StreamWriter(puzzleFileName))
                        {
                            writer.WriteLine("x|y|направление|номер|слово|подсказка");

                            int currentX = 0;
                            int currentY = 0;
                            bool horizontal = true;


                            foreach (string word in wordsList)
                            {
                                string hint = wordToHintMap[word];
                                string number = (wordsList.IndexOf(word) + 1).ToString();

                                // Определяем буферную зону в зависимости от направления слова
                                int bufferZoneSizeX = horizontal ? word.Length : 1;
                                int bufferZoneSizeY = !horizontal ? word.Length : 1;

                                for (int dx = -bufferZoneSizeX; dx <= bufferZoneSizeX; dx++)
                                {
                                    for (int dy = -bufferZoneSizeY; dy <= bufferZoneSizeY; dy++)
                                    {
                                        int newX = currentX + dx;
                                        int newY = currentY + dy;

                                        // Проверяем, не пересекает ли буферная зона существующую координату
                                        if (usedCoordinates.ContainsKey(word) && usedCoordinates[word].Any(coord => coord.Item1 == newX && coord.Item2 == newY))
                                        {
                                            // Если буферная зона пересекает существующую координату, пропускаем текущее слово
                                            continue;
                                        }
                                    }
                                }

                                if (horizontal)
                                {
                                    writer.WriteLine($"{currentX}|{currentY}|горизонтально|{number}|{word}|{hint}");
                                    currentX += word.Length + 1;
                                    currentY = 0;
                                    horizontal = false;
                                }
                                else
                                {
                                    writer.WriteLine($"{currentX}|{currentY}|вертикально|{number}|{word}|{hint}");
                                    currentY += word.Length + 1;
                                    currentX = 0;
                                    horizontal = true;
                                }
                            }
                        }

                        MessageBox.Show($"Файл '{puzzleFileName}' успешно создан.");

                        // Очистка словаря после использования
                        usedCoordinates.Clear();
                    }
                }
            }
        }

        // Метод для перемешивания списка
        void Shuffle<T>(IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
