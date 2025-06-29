namespace WinAutoprefs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Program.GurlYouAdminDoe())
            {
                label1.Text = "I'm an admin bitch, BOW TO ME YOU PEASANTS";
                button1.Enabled = false;
            }
            else
            {
                Program.AppendUACShield(button1);
                label1.Text = "This makes me SO inferor";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.RelaunchThatAppAsAdmin();
        }
    }
}
