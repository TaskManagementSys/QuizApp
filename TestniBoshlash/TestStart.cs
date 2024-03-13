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

        public TestStart(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
            LoadNextQuestion();
            UpdateButtonLabels();
        }

        public string Question = "";
        public string A = "";
        public string B = "";
        public string C = "";
        public string currentAnswer = "";

        private void LoadNextQuestion()
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
                {
                    Table table = wordDocument.MainDocumentPart!.Document.Body!.Elements<Table>().FirstOrDefault()!;
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
                            A = $"A. {options[0]}";
                            B = $"B. {options[1]}";
                            C = $"C. {options[2]}";

                            currentIndex++;
                        }
                        else
                        {
                            MessageBox.Show("No more questions available.");
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
            // Extracting the selected option
            char selectedOption = selectedAnswer[0];

            // Extracting the correct option
            char correctOption = 'B'; // Default value
            if (currentAnswer.StartsWith("A"))
            {
                correctOption = 'A';
            }
            else if (currentAnswer.StartsWith("B"))
            {
                correctOption = 'B';
            }
            else if (currentAnswer.StartsWith("C"))
            {
                correctOption = 'C';
            }

            // Comparing the selected option with the correct one
            if (selectedOption == correctOption)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Wrong!");
            }

            // Load next question
            LoadNextQuestion();

            // Update button texts
            UpdateButtonLabels();
        }


        private void UpdateButtonLabels()
        {
            btnQuestion.Text = Question;
            btnA.Text = A;
            btnB.Text = B;
            btnC.Text = C;
        }
    }
}
