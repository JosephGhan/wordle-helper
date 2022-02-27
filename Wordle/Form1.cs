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
            List<string> guesses = new List<string>();

            //Take all the yellow boxes values and add them to a char array
            char[] yellows = (txtYlw1.Text + txtYlw2.Text + txtYlw3.Text + txtYlw4.Text + txtYlw5.Text).ToCharArray();
            

            if (Words != null)
            {
                guesses = Words.Where(a => a.Length == 7).Distinct().ToList(); //Filter to just 5 letter words
                //If the first letter is known
                if (txtGrn1.Text.Length > 0)
                    guesses = guesses.Where(a => Char.ToUpper(a[1]) == txtGrn1.Text[0]).Select(a => a.ToString()).ToList();//First letter Green
                //If the second letter is know
                if (txtGrn2.Text.Length > 0)
                    guesses = guesses.Where(a => Char.ToUpper(a[2]) == txtGrn2.Text[0]).Select(a => a.ToString()).ToList();//Second letter Green
                //If the third letter is know
                if (txtGrn3.Text.Length > 0)
                    guesses = guesses.Where(a => Char.ToUpper(a[3]) == txtGrn3.Text[0]).Select(a => a.ToString()).ToList();//Third letter Green
                //If the fourth letter is know
                if (txtGrn4.Text.Length > 0)
                    guesses = guesses.Where(a => Char.ToUpper(a[4]) == txtGrn4.Text[0]).Select(a => a.ToString()).ToList();//Fourth letter Green
                //If the fifth letter is know
                if (txtGrn5.Text.Length > 0)
                    guesses = guesses.Where(a => Char.ToUpper(a[5]) == txtGrn5.Text[0]).Select(a => a.ToString()).ToList();//Fifth letter Green
                //If there are any yellow letters
                if (yellows.Length > 0)
                {
                    //Get only words that contain the yellow letters
                    guesses = guesses.Where(a => yellows.All(a.ToUpper().Contains)).Select(a => a.ToString()).ToList();

                    if (txtYlw1.Text.Length > 0)
                    {
                        foreach (char x in txtYlw1.Text)
                            guesses = guesses.Where(a => Char.ToUpper(a[1]) != x).Select(a => a.ToString()).ToList();
                    }

                    if (txtYlw2.Text.Length > 0)
                    {
                        foreach (char x in txtYlw2.Text)
                            guesses = guesses.Where(a => Char.ToUpper(a[2]) != x).Select(a => a.ToString()).ToList();
                    }

                    if (txtYlw3.Text.Length > 0)
                    {
                        foreach (char x in txtYlw3.Text)
                            guesses = guesses.Where(a => Char.ToUpper(a[3]) != x).Select(a => a.ToString()).ToList();
                    }

                    if (txtYlw4.Text.Length > 0)
                    {
                        foreach (char x in txtYlw4.Text)
                            guesses = guesses.Where(a => Char.ToUpper(a[4]) != x).Select(a => a.ToString()).ToList();
                    }

                    if (txtYlw5.Text.Length > 0)
                    {
                        foreach (char x in txtYlw5.Text)
                            guesses = guesses.Where(a => Char.ToUpper(a[5]) != x).Select(a => a.ToString()).ToList();
                    }


                }
                    
                //Filter out words with the incorrect letters
                if (txtBad.Text.Length > 0)
                    foreach (char x in txtBad.Text)
                    {
                        guesses = guesses.Where(a => Char.ToUpper(a[1]) != x)
                                         .Where(a => Char.ToUpper(a[2]) != x)
                                         .Where(a => Char.ToUpper(a[3]) != x)
                                         .Where(a => Char.ToUpper(a[4]) != x)
                                         .Where(a => Char.ToUpper(a[5]) != x)
                                         .Select(a => a.ToString()).ToList();                     
                    }
                    
                
                
            }


            txtNmbr.Text = guesses.Count.ToString();
            lstGss.Items.Clear();
            lstGss.Items.AddRange(guesses.ToArray());
        }

        private void btnRst_Click(object sender, EventArgs e)
        {
            foreach (Control tx in ActiveForm.Controls)
            {
                if (tx is TextBox)
                    tx.Text = "";
            }

            lstGss.Items.Clear();
        }
    }
}