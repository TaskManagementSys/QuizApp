using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using QuizApp.TestniBoshlash;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string? fileName;

        private void docxYuklash_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx";
            openFileDialog.Title = "Fayl ochish";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Tanlangan faylning to'liq nomini olish
                fileName = openFileDialog.FileName;

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Fayl nomi bo'sh!", "Xato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Fayl nomi bo'sh bo'lsa metodni to'xtatamiz
                }

                try
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
                    {
                        Body body = wordDocument.MainDocumentPart!.Document.Body!;
                        MessageBox.Show($"Tanlangan fayl: {fileName}");
                    }

                    docxYuklash.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TestStart testStart = new(fileName!);
            this.Hide();

            testStart.Show();
        }
    }
}
