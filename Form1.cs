using System.Drawing.Text;

namespace KrestikiNoliki
{
    public partial class Form1 : Form
    {
        private int player;
        Dictionary<int,string> values = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            this.player = 1;
            label1.Text = "Turn: Player 1";
            this.Height = 600;
            this.Width = 800;
            InitValues();
        }

        private void InitValues()
        {
            for (int i = 0; i < 9; i++) 
            {
                values[i] = "";
            }
            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = "";
         
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = true;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.GetType().GetProperty("Name").GetValue(sender).ToString());
            if (player == 1)
            {
                sender.GetType().GetProperty("Text").SetValue(sender, "X");
                int boxNumber = (int)sender.GetType().GetProperty("TabIndex").GetValue(sender);               
               // MessageBox.Show(boxNumber.ToString());
                values[boxNumber] = "X";
                player = 0;
                label1.Text = "Turn: Player 2";
            }
            else
            {
                sender.GetType().GetProperty("Text").SetValue(sender, "O");
                int boxNumber = (int)sender.GetType().GetProperty("TabIndex").GetValue(sender);
                // MessageBox.Show(sender.GetType().GetProperty("TabIndex").GetValue(sender).ToString());
                //MessageBox.Show(boxNumber.ToString());
                values[boxNumber] = "O";
                player = 1;
                label1.Text = "Turn: Player 1";
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            checkWin();
        }
        private void checkWin()
        {
            for (int i = 0; i < 9; i+=3)
            {
                if (values[i] == values[i+1] && values[i] == values[i+2] && values[i]!="" )
                {
                    MessageBox.Show("YOU WIN!!! HORIZONTAL");
                    InitValues();

                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (values[i] == values[i + 3] && values[i] == values[i + 6] && values[i] != "")
                {
                    MessageBox.Show("YOU WIN!!! VERTICAL");
                    InitValues();
                }
            }
            if ((values[0] == values[4] && values[0] == values[8]) || (values[2] == values[4] && (values[2] == values[6])))
            {
                if (values[4] != "")
                {
                    MessageBox.Show("YOU WIN!!! DIAGONAL");
                    InitValues();
                }
            }
            
        }
    }
}