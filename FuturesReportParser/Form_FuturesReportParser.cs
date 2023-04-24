using MySqlConnector;
using System.Data;
using System.Text;

namespace FuturesReportParser
{
    public partial class Form_FuturesReportParser : Form
    {
        const string ConnString = "server=127.0.0.1;port=3306;user id=root;password=admin;database=futures;charset=utf8;";
        MySqlConnection conn = new MySqlConnection(ConnString);

        public Form_FuturesReportParser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox_1.Text == "")
            {
                richTextBox1.Text = "Select file type";
                return;
            } 
            else if (textBox1.Text == "")
            {
                richTextBox1.Text = "Select file";
                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding big5 = Encoding.GetEncoding("big5");
            FileStream fs = File.OpenRead(textBox1.Text);
            StreamReader streamReader = new StreamReader(fs, big5);

            switch (comboBox_1.Text)
            {
                case "�`��":
                    ParsetTotalTableDate(streamReader.ReadToEnd());
                    break;
                case "�ϴ���":
                    ParsetFutAndOptDate(streamReader.ReadToEnd());
                    break;
                case "���f":
                    break;
                case "���f�]":
                    break;
                case "���f�j�B":
                    break;
                case "����v":
                    break;
                case "����v�]":
                    break;
                case "����v�j�B":
                    break;
                case "����v�R��":
                    break;
                case "����v�R��]":
                    break;
                case "��PCR":
                    break;
                default:
                    return;
            }

        }

        bool InsertInto(in string table, in string row)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            string sql = $@"REPLACE INTO `{table}` () VALUES ({row})";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int index = cmd.ExecuteNonQuery();

            conn.Close();

            return index > 0;
        }

        void ParsetTotalTableDate(string content)
        {
            string[] lines = content.Split("\r\n");

            if (lines.Length == 0) {
                richTextBox1.Text = "Failed line == 0";
                return;
            }

            if (!lines[0].StartsWith("���,�����O,�h�����f��,�h�����������B(�ʸU��),�Ť����f��,�Ť����������B(�ʸU��),�h�ť���f�Ʋb�B,�h�ť���������B�b�B(�ʸU��),�h�襼���ܤf��,�h�襼���ܫ������B(�ʸU��),�Ť襼���ܤf��,�Ť襼���ܫ������B(�ʸU��),�h�ť����ܤf�Ʋb�B,�h�ť����ܫ������B�b�B(�ʸU��)"))
            {
                richTextBox1.Text = "Failed line[0] content error";
                return;
            }

            int successLines = 0;

            for (int line = 1; line < lines.Length; line++)
            {
                string[] fields = lines[line].Split(",");
                if (fields.Length < 14)
                    break;

                string row = "";

                foreach (string field in fields)
                {
                    if (row.Length > 0)
                        row += ",";

                    row += $"\"{field}\"";
                }

                if (InsertInto("totalTableDate", row))
                    ++successLines;
            }

            richTextBox1.Text = $"Success insert {successLines} rows to db";
        }

        void ParsetFutAndOptDate(string content)
        {
            string[] lines = content.Split("\r\n");

            if (lines.Length == 0)
            {
                richTextBox1.Text = "Failed line == 0";
                return;
            }

            if (!lines[0].StartsWith("���,�����O,���f�h�����f��,����v�h�����f��,���f�h�����������B(�d��),����v�h�����������B(�d��),���f�Ť����f��,����v�Ť����f��,���f�Ť����������B(�d��),����v�Ť����������B(�d��),���f�h�ť���f�Ʋb�B,����v�h�ť���f�Ʋb�B,���f�h�ť���������B�b�B(�d��),����v�h�ť���������B�b�B(�d��),���f�h�襼���ܤf��,����v�h�襼���ܤf��,���f�h�襼���ܫ������B(�d��),����v�h�襼���ܫ������B(�d��),���f�Ť襼���ܤf��,����v�Ť襼���ܤf��,���f�Ť襼���ܫ������B(�d��),����v�Ť襼���ܫ������B(�d��),���f�h�ť����ܤf�Ʋb�B,����v�h�ť����ܤf�Ʋb�B,���f�h�ť����ܫ������B�b�B(�d��),����v�h�ť����ܫ������B�b�B(�d��)"))
            {
                richTextBox1.Text = "Failed line[0] content error";
                return;
            }

            int successLines = 0;

            for (int line = 1; line < lines.Length; line++)
            {
                string[] fields = lines[line].Split(",");
                if (fields.Length < 26)
                    break;

                string row = "";

                foreach (string field in fields)
                {
                    if (row.Length > 0)
                        row += ",";

                    row += $"\"{field}\"";
                }

                if (InsertInto("futAndOptDate", row))
                    ++successLines;
            }

            richTextBox1.Text = $"Success insert {successLines} rows to db";
        }
    }
}