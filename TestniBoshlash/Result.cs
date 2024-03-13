using System;
using System.Windows.Forms;

namespace QuizApp.TestniBoshlash
{
    public partial class Result : Form
    {
        private int Correct { get; }
        private int Incorrect { get; }

        public Result(int correctCount, int incorrectCount)
        {
            InitializeComponent();
            Correct = correctCount;
            Incorrect = incorrectCount;
            CorrectBtn();
            IncorrectBtn();
        }

        // Default constructor with default values
        public Result() : this(0, 0)
        {
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            // Display correct count in the button text and show a message box
            btnCorrect.Text = Correct.ToString();
        }

        private void btnInCorrect_Click(object sender, EventArgs e)
        {
            // Display incorrect count in the button text and show a message box
            btnInCorrect.Text = Incorrect.ToString();
        }

        private void CorrectBtn()
        {
            btnCorrect.Text = Correct.ToString();
            MessageBox.Show("Correct!");

            // file test count 
            if (Correct >= 3)
            {
                lbUserLevel.Text += " Advanced";
            }
            else
            {
                lbUserLevel.Text += " Beginner";
            }
        }

        private void IncorrectBtn()
        {
            btnInCorrect.Text = Incorrect.ToString();
            MessageBox.Show("Incorrect!");
        }
    }
}
