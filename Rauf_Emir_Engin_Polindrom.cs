using System;
namespace Rauf_Emir_Engin_Polindrom
{
    public class PalindromeExample
    {
        public static void Main(string[] args)
        {
            {
                Form form1 = new Form();
                form1.Height = 300;
                form1.Width = 300;
                form1.ShowDialog();
            }
            int a, b, toplam = 0, sayi;
            Console.Write("Bir sayı giriniz:");
            a = int.Parse(Console.ReadLine());
            sayi = a;
            while (a > 0)
            {
                b = a % 10;
                toplam = (toplam * 10) + b;
                a = a / 10;
            }
            if (sayi == toplam)
                Console.Write("Girdiğiniz sayı palindrom bir sayıdır.");
            else
                Console.Write("Girdiğiniz sayı palindrom bir sayı değildir.");
        }
    } 

class Program
{
      {
            Form form2 = new Form();
    form2.Height = 300;
            form2.Width = 300;
            form2.ShowDialog();
        }
    static void Main(string[] args)
    {
        int[] dizi = new int[5];

        for (int i = 0; i < dizi.Length; i++)
        {
            Console.Write("Dizinin " + (i + 1) + ". elemanını giriniz: ");
            dizi[i] = Convert.ToInt32(Console.ReadLine());
        }
        // kullanicidan artis miktarini alacagiz
        Console.Write("\nArttırmak istediğiniz değeri giriniz(1,100) : ");
        int artis_miktari = Convert.ToInt32(Console.ReadLine());
        // artis miktarinin alıp degiskene atadık

        Console.WriteLine("\nDizi elemanlarının degerleri arttırıldı !!!\n");
        for (int i = 0; i < dizi.Length; i++)
        {
            dizi[i] = dizi[i] + (int)(dizi[i] * ((double)artis_miktari / 100.0));
            // kullanıcıdan aldıgımız degeri yüzdelik olarak alacagımız icin
            // 100 ile böldükten sonra çarpma işlemi yaptık.
            Console.WriteLine("Dizinin " + (i + 1) + ". elemanını = " + dizi[i]);
        }
        Console.ReadLine();
    }
}

public static void Main(string[] args)
{
    {
    Form form3 = new Form();
    form3.Height = 300;
    form3.Width = 300;
    form3.ShowDialog();
}
    string value = "Merhaba";
    Console.WriteLine("Karakter sayısı : {0}", value.Length);

    string value2 = "";
    Console.WriteLine("Karakter sayısı : {0}", value2.Length);

    Console.WriteLine("Karakter sayısı : {0}", "Merhaba".Length);

    int length = value.Length;

    Console.ReadLine();
    Console.WriteLine("Karakter sayısı : {0}", value.Length);
}
}