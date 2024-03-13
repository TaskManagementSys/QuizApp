using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
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
        }

        public string Question = "";
        public string A = "";
        public string B = "";
        public string C = "";

        private void LoadNextQuestion()
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
                        string currentAnswer = "";
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
                            else if (columnIndex == 4 || columnIndex == 5)
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
                        A = $"A {options[0]}";
                        B = $"B {options[1]}";
                        C = $"C {options[2]}";

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
        private void btnA_Click(object sender, EventArgs e)
        {
            btnA.Text = A;
            // For example, check if btnA.Text contains the correct answer
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            btnB.Text = B;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            btnC.Text = C;
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            btnQuestion.Text = Question;
        }
    }
}
