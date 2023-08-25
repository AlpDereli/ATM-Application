// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.IO;
string filepath = "C:\\Users\\HP\\Desktop\\ATM Uygulaması.txt";
List<kullanici> kisiler = new List<kullanici>();
islemler isle = new islemler();
kullanici kullanici1 = new kullanici();
{
    kullanici1.ad = "Alp";
    kullanici1.soyad = "Dereli";
    kullanici1.Bakiye = 5000;
    kullanici1.Password = 1234;
}
kisiler.Add(kullanici1);
Console.WriteLine("Name: ");
string s = Console.ReadLine();
bool b = isle.Giris(kisiler, s);
while (b)
{
    int kisi = isle.indexfind(s, kisiler);
    Console.WriteLine("Please select operation: ");
    Console.WriteLine("(1) Deposit");
    Console.WriteLine("(2) Withdrawal");
    Console.WriteLine("(3) Send Money");
    Console.WriteLine("(4) End of the Day");
    Console.WriteLine("Your Balance: " + kisiler[kisi].Bakiye);
    int selection = int.Parse(Console.ReadLine());
    if (selection == 1)
    {
        Console.WriteLine("Please enter the amount of money: ");
        float f = float.Parse(Console.ReadLine());
        kisiler[kisi].Bakiye += f;
        isle.WriteToFile(filepath, "Deposit:" + DateTime.Now.ToString("ddMMyyy") + " +" + f);
    }
    if (selection == 2)
    {
        Console.WriteLine("Please enter the amount of money: ");
        float f = float.Parse(Console.ReadLine());
        if (f > kisiler[kisi].Bakiye)
        {
            kisiler[kisi].Bakiye = 0;
            f = kisiler[kisi].Bakiye;
        }
        else
        {
            kisiler[kisi].Bakiye -= f;
        }
        isle.WriteToFile(filepath, "Withdrawal:" + DateTime.Now.ToString("ddMMyyy") + " -" + f);
    }
    if (selection == 3)
    {
        Console.WriteLine("Please enter the IBAN: ");
        Console.ReadLine();
        Console.WriteLine("Please enter the amount of money: ");
        float f = float.Parse(Console.ReadLine());
        if (f > kisiler[kisi].Bakiye)
        {
            kisiler[kisi].Bakiye = 0;
            f = kisiler[kisi ].Bakiye;
        }
        else
        {
            kisiler[kisi].Bakiye -= f;
        }
        isle.WriteToFile(filepath, "Money Sent:" + DateTime.Now.ToString("ddMMyyy") + " -" + f);
    }
    if (selection == 4)
    {
        string fi = File.ReadAllText(filepath);
        Console.WriteLine(fi);
    }
}



class kullanici
{
    public string ad;
    public string soyad;
    private float bakiye;
    private int password;

    public int Password { get => password; set => password = value; }
    public float Bakiye { get => bakiye; set => bakiye = value; }
}
class islemler
{
    public bool Giris(List<kullanici> l,string s)
    {
        string filepath = "C:\\Users\\HP\\Desktop\\ATM Uygulaması.txt";
        foreach (kullanici k in l)
        {
            if (k.ad == s)
            {
                Console.WriteLine("Password: ");
                int i = int.Parse(Console.ReadLine());
                if (k.Password == i)
                {
                    Console.WriteLine("Successesfuly Entered");
                    Console.WriteLine("*********************");
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong password or username");
                }
            }
            else
            {
                Console.WriteLine("Wrong password or username");
            }
        }
        WriteToFile(filepath, "Unsuccessful entry:" + DateTime.Now.ToString("ddMMyyy"));
        return false;
    }
    public int indexfind(string s, List<kullanici> l)
    {
        for (int i = 0; i < l.Count;i++)
        {
            if (l[i].ad == s)
            {
                return i;
            }
        }
        return -1;
    }
    public void WriteToFile(string filePath, string content)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(content);
        }
    }
}