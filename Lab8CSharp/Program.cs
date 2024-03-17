using System;
using System.IO;
using System.IO.Pipes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

Console.WriteLine("Lab#8 ");

Task task1 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(1000);

    Console.WriteLine("Початок виконання завдання 1");

    task1 processor = new task1("C:\\University\\VI_semester\\CSharp\\lab_8\\task1\\read.txt", "C:\\University\\VI_semester\\CSharp\\lab_8\\task1\\output.txt");
    processor.ProcessText();

    Console.WriteLine("Завершення виконання завдання 1");
});

Task task2 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(3000);

    Console.WriteLine("Початок виконання завдання 2");

    task2 task21 = new task2("C:\\University\\VI_semester\\CSharp\\lab_8\\task2\\read.txt", "C:\\University\\VI_semester\\CSharp\\lab_8\\task2\\output.txt");
    task21.ProcessText();

    Console.WriteLine("Завершення виконання завдання 2");
});

Task task3 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(5000);

    Console.WriteLine("Початок виконання завдання 3");

    task3 task31 = new task3("C:\\University\\VI_semester\\CSharp\\lab_8\\task3\\read.txt", "C:\\University\\VI_semester\\CSharp\\lab_8\\task3\\output.txt");
    task31.ProcessText("vasya", "boris");

    Console.WriteLine("Завершення виконання завдання 3");
});

Task task4 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(7000);

    Console.WriteLine("Початок виконання завдання 4");

    task4 task41 = new task4("C:\\University\\VI_semester\\CSharp\\lab_8\\task4\\output.dat");
    task41.ProcessText("-10 20 808 9 105 65 -25 -63 74 32 1 0 5 6 9 8");

    Console.WriteLine("\nЗавершення виконання завдання 4");
});

Task task5 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(10000);

    Console.WriteLine("Початок виконання завдання 5");

    string tempFolderPath = Path.GetTempPath();
    Console.WriteLine("\nШлях до системної тимчасової папки: " + tempFolderPath);
    Console.WriteLine();

    //Створюємо папки Yenakii1 Yenakii2
    string folder1 = @"C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1";
    if (!Directory.Exists(folder1))
    {
        Directory.CreateDirectory(folder1);
        Console.WriteLine("Folder successfully created.");
    }
    else
    {
        Console.WriteLine("The folder already exists.");
    }

    string folder2 = @"C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2";
    if (!Directory.Exists(folder2))
    {
        Directory.CreateDirectory(folder2);
        Console.WriteLine("Folder successfully created.");
    }
    else
    {
        Console.WriteLine("The folder already exists.");
    }

    //Створюємо файл t1 t2
    using (StreamWriter writer = new StreamWriter("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t1.txt"))
    {
        writer.WriteLine("Шевченко Степан Іванович, 2001 року народження, місце проживання м. Суми");
    }
    Console.WriteLine($"\nThe text was successfully recorded in file");

    using (StreamWriter writer = new StreamWriter("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt"))
    {
        writer.WriteLine("Комар Сергій Федорович, 2000 року народження, місце проживання м. Київ");
    }
    Console.WriteLine($"The text was successfully recorded in file");

    //Створюємо файл t3
    using (StreamWriter writer = new StreamWriter("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2\\t3.txt"))
    {
        string t1Content = File.ReadAllText("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t1.txt");
        string t2Content = File.ReadAllText("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt");

        writer.WriteLine(t1Content);
        writer.WriteLine(t2Content);
    }
    Console.WriteLine($"\nThe text was successfully recorded in file\n");

    //Інформація про створені файли
    FileInfo fileInfo1 = new FileInfo("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t1.txt");
    Console.WriteLine($"File name: {fileInfo1.Name}");
    Console.WriteLine($"Way(шлях): {fileInfo1.FullName}");
    Console.WriteLine($"Size: {fileInfo1.Length} байт");
    Console.WriteLine($"Date create: {fileInfo1.CreationTime}");
    Console.WriteLine($"Date of final modification: {fileInfo1.LastWriteTime}");
    Console.WriteLine($"Atributes: {fileInfo1.Attributes}");
    Console.WriteLine();

    FileInfo fileInfo2 = new FileInfo("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt");
    Console.WriteLine($"File name: {fileInfo2.Name}");
    Console.WriteLine($"Way(шлях): {fileInfo2.FullName}");
    Console.WriteLine($"Size: {fileInfo2.Length} байт");
    Console.WriteLine($"Date create: {fileInfo2.CreationTime}");
    Console.WriteLine($"Date of final modification: {fileInfo2.LastWriteTime}");
    Console.WriteLine($"Atributes: {fileInfo2.Attributes}");
    Console.WriteLine();

    //Переміщення файлу
    try
    {
        if (File.Exists("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt"))
        {
            string fileName = Path.GetFileName("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt");

            string destinationFilePath = Path.Combine("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2", fileName);

            File.Move("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt", destinationFilePath);

            Console.WriteLine($"File {fileName} successfully moved to a folder C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2");
        }
        else
        {
            Console.WriteLine("File C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t2.txt doesn't exist.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }

    //Копіювання файлів
    try
    {
        string destinationFilePath = Path.Combine("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2", "t1.txt");

        File.Copy("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1\\t1.txt", destinationFilePath);

        Console.WriteLine("t1.txt successfully copied to the folder C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }

    //Переменовуємо і видаляємо папку
    try
    {
        // Перейменовуємо папку
        Directory.Move("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii2", "C:\\Users\\Vasia\\AppData\\Local\\Temp\\ALL");

        Console.WriteLine($"Folder Yenakii2 rename in All");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }

    try
    {
        Directory.Delete("C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1", true);

        Console.WriteLine($"Folder C:\\Users\\Vasia\\AppData\\Local\\Temp\\Yenakii1 successfully delete");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }
    Console.WriteLine();

    //Інформація про файли в папці ALL
    string folderPath = "C:\\Users\\Vasia\\AppData\\Local\\Temp\\ALL";

    try
    {
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            Console.WriteLine($"Name file: {fileInfo.Name}");
            Console.WriteLine($"Way: {fileInfo.FullName}");
            Console.WriteLine($"Size: {fileInfo.Length} байт");
            Console.WriteLine($"Date create: {fileInfo.CreationTime}");
            Console.WriteLine($"Date of final modification: {fileInfo.LastWriteTime}");
            Console.WriteLine($"Atributes: {fileInfo.Attributes}");
            Console.WriteLine();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Під час виведення інформації про файли в папці виникла помилка: {ex.Message}");
    }

    Console.WriteLine("\nЗавершення виконання завдання 5");
});

Task.WaitAll(task1, task2, task3, task4, task5);
Console.WriteLine("Усi завдання завершено");

class task1
{
    private string readingFilePath;
    private string recordFilePath;

    public task1(string sourceFilePath, string targetFilePath)
    {
        this.readingFilePath = sourceFilePath;
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText()
    {
        try
        {
            using (StreamReader sr = new StreamReader(readingFilePath))
            using (StreamWriter sw = new StreamWriter(recordFilePath))
            {

                if (!File.Exists(recordFilePath))
                {
                    File.Create(recordFilePath).Close();
                }
                int fl = 0;

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (IsCorrectTimeFormat(line))
                    {
                        sw.WriteLine(line);
                        fl++;
                    }
                }
                sw.WriteLine($"Number of time formats = {fl}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static bool IsCorrectTimeFormat(string text)
    {
        string[] parts = text.Split(':');
        if (parts.Length != 3)
        {
            return false;
        }

        foreach (string part in parts)
        {
            if (!int.TryParse(parts[0], out int hour) || hour > 24 || hour < 0)
            {
                return false;
            }

            if (!int.TryParse(part, out int minutes_and_seconds) || minutes_and_seconds < 0 || minutes_and_seconds > 59)
            {
                return false;
            }
        }
        return true;
    }
}

class task2
{
    private string readingFilePath;
    private string recordFilePath;

    public task2(string sourceFilePath, string targetFilePath)
    {
        this.readingFilePath = sourceFilePath;
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText()
    {
        try
        {
            using (StreamReader sr = new StreamReader(readingFilePath))
            using (StreamWriter sw = new StreamWriter(recordFilePath))
            {

                if (!File.Exists(recordFilePath))
                {
                    File.Create(recordFilePath).Close();
                }

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (word.Length >= 3 && word[1] == '-')
                        {
                            char startChar = word[0];
                            char endChar = word[2];

                            if (endChar <= startChar)
                            {
                                sw.WriteLine(word);
                            }

                            string expandedWord = string.Empty;
                            for (char c = startChar; c <= endChar; c++)
                            {
                                expandedWord += c;
                            }
                            sw.Write($"{expandedWord} ");
                        }
                        else
                        {
                            sw.Write($"{word} ");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}


class task3
{
    private string readingFilePath;
    private string recordFilePath;

    public task3(string sourceFilePath, string targetFilePath)
    {
        this.readingFilePath = sourceFilePath;
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText(string word1, string word2)
    {
        try
        {
            using (StreamReader sr = new StreamReader(readingFilePath))
            using (StreamWriter sw = new StreamWriter(recordFilePath))
            {

                if (!File.Exists(recordFilePath))
                {
                    File.Create(recordFilePath).Close();
                }

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    //Створення регулярного виразу
                    Regex regex = new Regex(@"\b\w+\b");
                    foreach (Match match in regex.Matches(line))
                    {
                        if (match.Value == word1) 
                        { 
                            sw.Write($"{word2} ");
                        }
                        else
                        {
                            sw.Write($"{match.Value} ");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

class task4
{
    private string recordFilePath;

    public task4(string targetFilePath)
    {
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText(string numbersString)
    {
        try
        {
            FileStream f = new FileStream(recordFilePath, FileMode.Create, FileAccess.Write);
            BinaryWriter fout = new BinaryWriter(f);

            string[] numbers = numbersString.Split(' ');
            foreach (string numberStr in numbers)
            {
                double number;
                if (double.TryParse(numberStr, out number))
                {
                    fout.Write(number);
                }
            }

            fout.Close();

            FileStream fs = new FileStream(recordFilePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    double number = br.ReadDouble();
                    if (number >= 0)
                    {
                        Console.Write($"{number} ");
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
