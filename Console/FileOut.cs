    public partial class MainForm : Form
    {
        SNMPManager sm;
        private TaskIntervalReq taskInt;
        private Thread threadTask;

        private string ip;
        private int port;
        private string communityRead;
        private string communityWrite;

        private TextWriter save;
        private StreamWriter sw;

        public MainForm()
        {
            InitializeComponent();
            stdOutToFile();
        }
        
        private void fetchConnInfo()
        {
            ip = textBox1.Text;
            port = Int32.Parse(textBox7.Text);
            communityRead = textBox20.Text;
            communityWrite = textBox21.Text;
        }

        private void stdOutToFile()
        {
            // 로그파일 경로 지정
            string tempPath = Path.GetTempPath();
            string logFile = getStrNowYmd() + "_log.txt";
            string path = Path.Combine(tempPath, logFile);

            // 표준출력장치를 파일로 변경
            save = Console.Out;   // 표준 입력장치 저장
            Console.WriteLine("MainForm.stdOutToFile(), tempPath : " + tempPath);
            FileStream fs = File.Open(path, FileMode.Append);
            sw = new StreamWriter(fs);
            Console.SetOut(sw);
            Console.SetError(sw);
            Console.WriteLine(getStrNowYmdHms() + " 파일로 출력합니다.");
            testWriteException();
            //sw.Flush();
            sw.AutoFlush = true;
        }

        /**
         * 표준출력장치로 출력하도록 원복
         */ 
        private void stdOutToConsole()
        {
            Console.SetOut(save);
            Console.WriteLine(getStrNowYmdHms() + " 화면으로 출력합니다.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sw.Close();
        }

        private double testWriteException()
        {
            int mom = 0;
            int child = 1;
            double result = 0;
            try
            {
                result = child / mom;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        private string getStrNowYmd()
        {
            DateTime today = DateTime.Now;
            string result = today.ToString("yyyyMMdd");
            return result;
        }

        private string getStrNowYmdHms()
        {
            DateTime today = DateTime.Now;
            string result = today.ToString("yyyyMMdd HHmmss");
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty) || textBox7.Text.Equals(string.Empty) || textBox20.Text.Equals(string.Empty) || textBox21.Text.Equals(string.Empty))
                return;

            fetchConnInfo();

            sm = new SNMPManager();
            sm.SetCommunity(communityRead, communityWrite);
            if (sm.Kb_GetOnLine(ip, port).Equals("1"))
            {
                updateInfo();
            }
            else
            {
                Console.WriteLine(getStrNowYmdHms() + " 장비가 검색되지 않습니다.");
                MessageBox.Show("장비가 검색되지 않습니다.");
                Clear();
            }
        }
    }
