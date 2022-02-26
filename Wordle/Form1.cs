namespace Wordle
{
    public partial class Form1 : Form
    {
        List<string>? Words { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadWords();
        }

        private void LoadWords()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "words.csv");

                Words = new List<string>(File.ReadAllText(path).Split(','));

                btnGss.Enabled = true;
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message;
            }
            
        }

        private void btnGss_Click(object sender, EventArgs e)
        {
            List<string> quesses = new List<string>();
            Char[] badOnes;

            if (txtBad.Text.Length > 0)
                badOnes = txtBad.Text.ToCharArray();

            if (Words != null)
            {
                quesses = Words.Where(a => a.Length == 7).ToList();

                if (txtGrn1.Text.Length > 0)
                    quesses = quesses.Where(a => Char.ToUpper(a[1]) == txtGrn1.Text[0]).Select(a => a.ToString()).ToList();//First letter Green
                
                if (txtGrn2.Text.Length > 0)
                    quesses = quesses.Where(a => Char.ToUpper(a[2]) == txtGrn2.Text[0]).Select(a => a.ToString()).ToList();//Second letter Green
                
                if (txtGrn3.Text.Length > 0)
                    quesses = quesses.Where(a => Char.ToUpper(a[3]) == txtGrn3.Text[0]).Select(a => a.ToString()).ToList();//Third letter Green
                
                if (txtGrn4.Text.Length > 0)
                    quesses = quesses.Where(a => Char.ToUpper(a[4]) == txtGrn4.Text[0]).Select(a => a.ToString()).ToList();//Fourth letter Green
                
                if (txtGrn5.Text.Length > 0)
                    quesses = quesses.Where(a => Char.ToUpper(a[5]) == txtGrn5.Text[0]).Select(a => a.ToString()).ToList();//Fifth letter Green

                if (txtYlw1.Text.Length > 0)
                    quesses = quesses.Where(a => a.Contains(txtYlw1.Text[0])).Select(a => a.ToString()).ToList();
            }



            lstGss.Items.Clear();
            lstGss.Items.AddRange(quesses.ToArray());
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}