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
                case "總表":
                    ParsetTotalTableDate(streamReader.ReadToEnd());
                    break;
                case "區期選":
                    ParsetFutAndOptDate(streamReader.ReadToEnd());
                    break;
                case "期貨":
                    break;
                case "期貨夜":
                    break;
                case "期貨大額":
                    break;
                case "選擇權":
                    break;
                case "選擇權夜":
                    break;
                case "選擇權大額":
                    break;
                case "選擇權買賣":
                    break;
                case "選擇權買賣夜":
                    break;
                case "選PCR":
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

            if (!lines[0].StartsWith("日期,身份別,多方交易口數,多方交易契約金額(百萬元),空方交易口數,空方交易契約金額(百萬元),多空交易口數淨額,多空交易契約金額淨額(百萬元),多方未平倉口數,多方未平倉契約金額(百萬元),空方未平倉口數,空方未平倉契約金額(百萬元),多空未平倉口數淨額,多空未平倉契約金額淨額(百萬元)"))
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

            if (!lines[0].StartsWith("日期,身份別,期貨多方交易口數,選擇權多方交易口數,期貨多方交易契約金額(千元),選擇權多方交易契約金額(千元),期貨空方交易口數,選擇權空方交易口數,期貨空方交易契約金額(千元),選擇權空方交易契約金額(千元),期貨多空交易口數淨額,選擇權多空交易口數淨額,期貨多空交易契約金額淨額(千元),選擇權多空交易契約金額淨額(千元),期貨多方未平倉口數,選擇權多方未平倉口數,期貨多方未平倉契約金額(千元),選擇權多方未平倉契約金額(千元),期貨空方未平倉口數,選擇權空方未平倉口數,期貨空方未平倉契約金額(千元),選擇權空方未平倉契約金額(千元),期貨多空未平倉口數淨額,選擇權多空未平倉口數淨額,期貨多空未平倉契約金額淨額(千元),選擇權多空未平倉契約金額淨額(千元)"))
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