using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022330051
{
    class KodeProduk
    {
        private static readonly Dictionary<string, string> kodeProdukMap = new Dictionary<string, string>
        {
            {"Laptop", "E100" },
            {"Smartphone", "E101" },
            {"Tablet", "E102" },
            {"Headset", "E103" },
            {"Keyboard", "E104" },
            {"Mouse", "E105" },
            {"Printer", "E106" },
            {"Monitor", "E107" },
            {"Smartwatch", "E108" },
            {"Kamera", "E109" }
        };

        private static string getKodeProduk(string kodeProduk)
        {
            return kodeProdukMap.TryGetValue(kodeProduk, out string kodePeoduk) ? kodeProduk : "kode produk tidak ditemukan";
        }
    }
}

