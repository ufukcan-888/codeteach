Console.WriteLine("\n🎮 Seçenekler:");
Console.WriteLine("1. HTML Modülüne Direkt Geç");
Console.WriteLine("2. Kupa Durumu");
Console.WriteLine("3. Yardımcıyı Çağır");
Console.WriteLine("4. Çıkış");

Console.Write("\n🧠 Seçimin: ");
var secim = Console.ReadLine();

switch (secim)
{
    case "1":
        SahneHTML(oyuncu); // Artık doğrudan modül açılıyor
        break;
    case "2":
        Console.WriteLine($"Kupan: {oyuncu.Kupa}");
        break;
    case "3":
        Console.WriteLine("👤 AI Yardımcısı aktif!");
        break;
    case "4":
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("❌ Geçersiz seçim.");
        break;
}
