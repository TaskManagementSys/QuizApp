using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuizApp.TestniBoshlash
{
    public partial class TestStart : Form
    {
        private string fileName;
        private int currentIndex = 0;
        private int correctCount = 0;
        private int incorrectCount = 0;

        public TestStart(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
            LoadNextQuestion();
            UpdateButtonLabels();
        }

        private string Question = "";
        private string A = "";
        private string B = "";
        private string C = "";
        private string currentAnswer = "";

        private void LoadNextQuestion()
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
                {
                    Table table = wordDocument.MainDocumentPart.Document.Body.Elements<Table>().FirstOrDefault();
                    if (table != null)
                    {
                        if (currentIndex < table.Elements<TableRow>().Count())
                        {
                            TableRow row = table.Elements<TableRow>().ElementAt(currentIndex);
                            string question = "";
                            string wrongAnswersB = "";
                            string wrongAnswersC = "";

                            int columnIndex = 0;
                            foreach (TableCell cell in row.Elements<TableCell>())
                            {
                                string cellText = cell.InnerText.Trim();

                                if (columnIndex == 0)
                                {
                                    question = cellText;
                                }
                                else if (columnIndex == 1)
                                {
                                    currentAnswer = cellText;
                                }
                                else if (columnIndex == 2)
                                {
                                    wrongAnswersB = cellText;
                                }
                                else if (columnIndex == 3 || columnIndex == 4)
                                {
                                    wrongAnswersC = cellText;
                                }
                                columnIndex++;
                            }

                            // Shuffle the options
                            var options = new string[] { currentAnswer, wrongAnswersB, wrongAnswersC };
                            Shuffles.Shuffle(options);

                            // Update button texts
                            Question = $"Question: {question}";
                            A = $"{options[0]}";
                            B = $"{options[1]}";
                            C = $"{options[2]}";

                            currentIndex++;
                        }
                        else
                        {
                            MessageBox.Show("No more questions available.");
                            ShowResultForm(); // Show the result form when all questions are answered
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tables found in the Word document.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading question: {ex.Message}");
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnA.Text);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnB.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnC.Text);
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            btnQuestion.Text = Question;
            MessageBox.Show(Question);
        }

        private void CheckAnswer(string selectedAnswer)
        {
            string selectedOption = selectedAnswer.Trim(); // Extract the selected option (removing the prefix)

            if (string.Equals(selectedOption, currentAnswer, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Correct! You chose the right answer.");
                Current(); // Increment correct count
            }
            else
            {
                MessageBox.Show($"Incorrect. The correct answer was {currentAnswer}.");
                Incorrect(); // Increment incorrect count
            }

            // Load next question and update button labels
            LoadNextQuestion();
            UpdateButtonLabels();
        }

        public void Current()
        {
            // Increment the count for correct answers
            correctCount++;
        }

        public void Incorrect()
        {
            // Increment the count for incorrect answers
            incorrectCount++;
        }

        private void UpdateButtonLabels()
        {
            btnQuestion.Text = Question;
            btnA.Text = A;
            btnB.Text = B;
            btnC.Text = C;
        }

        private void ShowResultForm()
        {
            Result resultForm = new Result(correctCount, incorrectCount);
            resultForm.Show();
            this.Hide();
        }
    }
}
