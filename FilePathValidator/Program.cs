using System;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("코드를 작성하세요.");
string[] allowedExtensions = {".txt", ".csv",".exe" };


Console.WriteLine("=== 경로 검증 테스트 ===");
FilePathValidator file=new FilePathValidator();
try
{
    file.ValidatePath("C:/Users/data/report.txt");
    Console.WriteLine("경로가 유효합니다: {C:/Users/data/report.txt}");

}
catch
{ 
}

Console.WriteLine();
try
{
    file.ValidatePath("C:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/C:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtC:/Users/data/report.txtdata/report.txtC:/Users/data/report.txt");

}
catch (ArgumentOutOfRangeException ov)
{
    Console.WriteLine($"[ArgumentOutOfRangeException 오류]{ov}");
}
Console.WriteLine();

try
{
    file.ValidatePath("뭐라고????");

}
catch (ArgumentException ij)
{
    Console.WriteLine($"[ArgumentException]{ij}");
}

Console.WriteLine();
try
{
    file.ValidatePath(null);

}
catch (ArgumentNullException a)
{
    Console.WriteLine($"[ArgumentNull 오류]{a}");
}


Console.WriteLine("=== 확장자 검증 테스트 ===");

file.ValidateExtension("C:/Users/data/report.txt", allowedExtensions);



class FilePathValidator
{
    public void ValidatePath(string path)
    {

        char[] gold = { '<', '>', '|', '"', '*', '?' };

        if (path == null)
        {
            throw new ArgumentNullException(nameof(path), "경로는 null이거나 비어있을 수 없습니다");
        }

        foreach (char c in gold)
        {
            if (path.Contains(c))
                throw new ArgumentException(nameof(path), $"경로에 금지 문자 '{c}'가 포함되어 있습니다.");
        }

        if (path.Length > 260)
        {
            throw new ArgumentOutOfRangeException(nameof(path),"경로 길이가 260자를 초과합니다.");
        }
     
    }

    public void ValidateExtension(string path, string[] allowedExtensions)
    {
        if (path.Contains(".exe"))
        {
            throw new ArgumentNullException($"허용되지 않은 확장자입니다: {allowedExtensions}");
        }
        else
        {
            Console.WriteLine($"확장자가 유효합니다: {allowedExtensions}");
        }
    }

}




