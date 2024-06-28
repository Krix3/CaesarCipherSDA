using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку для шифрования:");
        string input = Console.ReadLine();

        Console.WriteLine("Введите сдвиг (целое число):");
        int shift;
        while (!int.TryParse(Console.ReadLine(), out shift))
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число:");
        }

        string encrypted = Encrypt(input, shift);
        string decrypted = Decrypt(encrypted, shift);

        Console.WriteLine($"\nЗашифрованная строка: {encrypted}");
        Console.WriteLine($"Расшифрованная строка: {decrypted}");
    }

    static string Encrypt(string text, int shift)
    {
        return CaesarCipher(text, shift);
    }

    static string Decrypt(string text, int shift)
    {
        return CaesarCipher(text, -shift);
    }

    static string CaesarCipher(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)((((letter + shift) - offset) % 26 + 26) % 26 + offset);
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }
}