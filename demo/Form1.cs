using System.Text;

namespace demo
{
    public partial class Form1 : Form
    {
        public bool loginOK = false;
        public Form1()
        {
            InitializeComponent();
            loginOK = false;
            btn_download.Enabled = loginOK;
            btn_login.Enabled = !loginOK;
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.ToUpper() == "ADMIN" && txtSenha.Text.ToUpper() == "ADMIN")
                loginOK = true;

            btn_download.Enabled = loginOK;
            btn_login.Enabled = !loginOK;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string caminho = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\demo.csv";

            if (File.Exists(caminho))
                File.Delete(caminho);

            using (StreamWriter arquivo = new StreamWriter(caminho, false, Encoding.GetEncoding("iso-8859-1")))
            {
                arquivo.WriteLine("Opened;Número;Caller;Assigned to;Service Level;Short description;Description;Business service;Category;Resolution code;Impact Type;Date/hour impact start;Date/hour impact finish;Assignment group;Resolution notes;State;Porcentagem SLA");
                arquivo.WriteLine("2/12/21 9:19;INC1934234;Splunk Integration Service;;N3;Endpoint;desc HOSTNAME = PAD01 IP = 20.206.141.254;Segurança;Segurança;;;;;Projetos End User;;New;16,76");
                arquivo.WriteLine("2/12/21 9:19;INC1934234;Splunk Integration Service;;N3;Endpoint;desc HOSTNAME = PAD02 IP = 20.206.141.254;Segurança;Segurança;;;;;Projetos End User;;New;16,76");
                arquivo.WriteLine("2/12/21 9:19;INC1934234;Splunk Integration Service;;N3;Endpoint;desc HOSTNAME = PAD03 IP = 20.206.141.254;Segurança;Segurança;;;;;Projetos End User;;New;16,76");
                MessageBox.Show($"arquivo exportado para {caminho}");
            }
        }
    }
}