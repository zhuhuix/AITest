using System;
using System.Drawing;
using System.Windows.Forms;



namespace AITest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTX_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {

                    clear();

                    txAIApi txAIApi = new txAIApi();
                    richTextBox1.Text = txAIApi.GetOCR(getType(),openFileDialog1.FileName);

                    Image image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = image;

                }
            }
        }


        private void btnBD_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    clear();

                    bdAIApi bdAIApi = new bdAIApi();
                    richTextBox1.Text = bdAIApi.GetOcr(getType(),openFileDialog1.FileName);

                    Image image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = image;
                }
            }
        }

        #region 清除信息 
        private void clear()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            richTextBox1.Text = "";
        }
        #endregion

        #region 判断选项
        private string  getType()
        {
            string type = "";
            foreach (Control control in this.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.RadioButton")
                {
                   if( (control as RadioButton).Checked)
                    {
                        type=(control as RadioButton).Text;
                    }
                }
            }
            return type;
        }
        #endregion

        private void btnAL_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    clear();

                    aliAIApi aliAIApi = new aliAIApi();
                    richTextBox1.Text = aliAIApi.GetOcr(getType(), openFileDialog1.FileName);

                    Image image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = image;
                }
            }
        }
    }
}

