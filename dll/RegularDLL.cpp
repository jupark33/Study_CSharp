
int n = 0;
CString s = CString(_T("hello dll"));

extern "C" __declspec(dllexport) int GetInt()
{
	return n;
}

extern "C" __declspec(dllexport) LPCTSTR GetString()
{
	return (LPCTSTR)s;
}

extern "C" __declspec(dllexport) WCHAR* GetWchar() 
{
	return L"Hello dll";
}

