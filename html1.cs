using System;

class Oyuncu
{
    public long Kupa { get; set; } = 0;
    public void KupaEkle(int miktar)
    {
        Kupa += miktar;
        Console.WriteLine($"🏆 Toplam Kupa: {Kupa}");
    }
}

class DersSahnesi
{
    public string Ad { get; set; } = "Frontend Nedir?";
    public bool Tamamlandi { get; private set; } = false;
    private readonly string icerik =
@"🧠 DERS: Frontend Nedir?

Frontend, bir web sitesinin kullanıcının doğrudan gördüğü ve etkileşime geçtiği yüzüdür.
Tarayıcıda çalışan arayüz kodlarıdır: HTML yapıyı, CSS tasarımı, JavaScript davranışı sağlar.

🔹 Kullanıcı tıklaması, kaydırması, yazması gibi eylemler frontend'de gerçekleşir.
🔹 Mobil ve masaüstü uyumluluğu tasarımın parçasıdır.
🔹 HTML: yapısal iskelet (ilk adım)
🔹 CSS: görsel düzenlemeler
🔹 JS: dinamik tepkiler, etkileşimler

Bu ders tamamlandığında +1 kupa kazanılır.";

    public void Baslat(Oyuncu oyuncu)
    {
        Console.Clear();
        Console.WriteLine($"📘 Ders: {Ad}\n");
        Console.WriteLine(icerik);

        if (!Tamamlandi)
        {
            Tamamlandi = true;
            Console.WriteLine("\n✅ Ders tamamlandı! +1 kupa.");
            oyuncu.KupaEkle(1);
        }
        else
        {
            Console.WriteLine("\n✅ Bu dersi zaten tamamladınız.");
        }

        Console.WriteLine("\n🔁 Ana sahneye dönmek için bir tuşa bas...");
        Console.ReadKey();
    }
}

class Program
{
    static Oyuncu oyuncu = new();
    static DersSahnesi frontendDersi = new();

    static void Main()
    {
        Anasayfa();
    }

    static void Anasayfa()
    {
        Console.Clear();
        Console.WriteLine("🌌 CODETEACH — HTML MODÜLÜ\n");
        Console.WriteLine($"🏆 Mevcut Kupa: {oyuncu.Kupa}\n");

        Console.WriteLine("🎮 Seçenekler:");
        Console.WriteLine("1. Frontend Nedir? (1. Ders)");
        Console.WriteLine("2. Çıkış");

        Console.Write("\n🧠 Seçimin: ");
        var secim = Console.ReadLine();
        switch (secim)
        {
            case "1":
                frontendDersi.Baslat(oyuncu);
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("❌ Geçersiz seçim.");
                break;
        }

        Console.WriteLine("\n🔁 Devam etmek için bir tuşa bas...");
        Console.ReadKey();
        Anasayfa();
    }
}
