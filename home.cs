using System;
using System.Collections.Generic;

class Ders
{
    public string Ad { get; set; }
    public bool Tamamlandi { get; set; } = false;
}

class AltModul
{
    public string Ad { get; set; }
    public int DersSayisi => Dersler.Count;
    public List<Ders> Dersler { get; set; } = new();
    public bool Kilitli(Oyuncu o) => Dersler.Exists(d => !d.Tamamlandi);
}

class Modul
{
    public int No { get; set; }
    public string Ad { get; set; }
    public long GerekliKupa { get; set; }
    public List<AltModul> AltModuller { get; set; } = new();
    public bool Kilitli(long kupa) => kupa < GerekliKupa;
}

class Oyuncu
{
    public long Kupa { get; set; } = 0;
    public bool CodeHubAktif => Kupa >= 5_000_000;
}

class Program
{
    static Oyuncu oyuncu = new();
    static Modul htmlModul = new Modul
    {
        No = 1,
        Ad = "HTML",
        GerekliKupa = 0,
        AltModuller = new()
        {
            new AltModul
            {
                Ad = "Temelden Formlar Öncesi",
                Dersler = new List<Ders>
                {
                    new Ders{ Ad = "Temel Etiketler" },
                    new Ders{ Ad = "Metin Biçimlendirme" },
                    new Ders{ Ad = "Görseller & Medya" },
                    new Ders{ Ad = "Link & Navigasyon" },
                    new Ders{ Ad = "Listeler" },
                    new Ders{ Ad = "Tablolar" },
                    // Toplam 57 ders burada tek tek girilebilir
                }
            }
        }
    };

    static void Main()
    {
        Anasayfa();
    }

    static void Anasayfa()
    {
        Console.Clear();
        Console.WriteLine("🌀 CODETEACH | BAŞLANGIÇ SAHNESİ\n");
        Console.WriteLine($"🏆 Kupan: {oyuncu.Kupa}");
        Console.WriteLine($"🔐 CodeHub: {(oyuncu.CodeHubAktif ? "Açık" : "Kapalı")}");
        Console.WriteLine($"\n📘 Aktif Modül: {htmlModul.Ad}");
        Console.WriteLine($"📚 Alt Modül: {htmlModul.AltModuller[0].Ad} ({htmlModul.AltModuller[0].DersSayisi} ders)");
        
        Console.WriteLine("\n🎮 Seçenekler:");
        Console.WriteLine("1. Ders Tamamla (+1 kupa)");
        Console.WriteLine("2. Ders Durumu");
        Console.WriteLine("3. Yardımcıyı Çağır");
        Console.WriteLine("4. Çıkış");

        Console.Write("\n🧠 Seçimin: ");
        var secim = Console.ReadLine();
        switch (secim)
        {
            case "1": DersTamamla(); break;
            case "2": DersDurumu(); break;
            case "3": Console.WriteLine("👤 AI Yardımcısı aktif!"); break;
            case "4": Environment.Exit(0); break;
            default: Console.WriteLine("❌ Geçersiz seçim."); break;
        }

        Console.WriteLine("\n🔁 Devam etmek için tuşa bas...");
        Console.ReadKey();
        Anasayfa();
    }

    static void DersTamamla()
    {
        var alt = htmlModul.AltModuller[0];
        var ilkTamamlanmamis = alt.Dersler.Find(d => !d.Tamamlandi);
        if (ilkTamamlanmamis != null)
        {
            ilkTamamlanmamis.Tamamlandi = true;
            oyuncu.Kupa += 1;
            Console.WriteLine($"📘 \"{ilkTamamlanmamis.Ad}\" tamamlandı! +1 kupa.");
        }
        else
        {
            Console.WriteLine("✅ Tüm dersler tamamlandı!");
        }
    }

    static void DersDurumu()
    {
        Console.WriteLine("\n📜 Ders Durumu:");
        foreach (var ders in htmlModul.AltModuller[0].Dersler)
        {
            var durum = ders.Tamamlandi ? "✅" : "🔒";
            Console.WriteLine($"{durum} {ders.Ad}");
        }
    }
}
