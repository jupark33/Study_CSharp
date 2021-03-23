// C# 에서 DLL 불러오기

class Program
{
    [DllImport("RegularDll.dll")]
    public static extern int GetInt();

    [DllImport("RegularDll.dll")]
    public static extern IntPtr GetString();

    [DllImport("RegularDll.dll")]
    public static extern IntPtr GetWchar();


    public static string _GetString()
    {
        return Marshal.PtrToStringUni(GetString());
    }

    public static string _GetWchar()
    {
        return Marshal.PtrToStringUni(GetWchar());
    }

    static void Main(string[] args)
    {
        int a = GetInt();
        Console.WriteLine("a : " + a);

        string b = _GetString();
        Console.WriteLine("b : " + b);

        string c = _GetWchar();
        Console.WriteLine("c : " + c);
    }
}

// 결과
// a : 0
// b : hello dll
// c : Hello dll
