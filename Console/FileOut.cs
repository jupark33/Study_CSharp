/**
 * 표준 출력장치를 파일로 redirect 하여, 소스 상에서 Console 로 출력하는 것을 파일로 저장한다.
 * 파일로 출력을 끝내고 원래대로 Console로 출력하면 표준출력장치로 출력되도록 원복한다.
 */
private void initStdOutToFile() 
{
    // 로그 파일 경로 지정
    string tempPath = Path.GetTempPath();
    string logFile = "log.txt";
    string path = Path.Combine(tempPath, logFile);

    // 표준출력장치를 파일로 변경
    var save = Console.Out;   // 표준 입력장치 저장
    Console.WriteLine("MainForm.fetchConnInfo(), tempPath : " + tempPath);
    FileStream fs = File.Open(path, FileMode.Append);
    StreamWriter sw = new StreamWriter(fs);
    Console.SetOut(sw);
    Console.WriteLine("파일로 출력합니다.");
    sw.Flush();
    sw.Close();
    // 파일에 대한 lock 해제되어 메모장에서 로그파일을 열수 있다.

    // 표준출력장치 원복            
    Console.SetOut(save);
    Console.WriteLine("화면으로 출력합니다.");    
}

private string getNowDate() 
{
}
