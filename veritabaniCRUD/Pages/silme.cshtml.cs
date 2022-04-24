using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class silmeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //K�rm�z� alt�izgide Ctrl+. yap�n�z
        public silmeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;
        public void OnPostSil()
        {
            int sayisal;
            if (int.TryParse(Request.Form["ID"], out sayisal))
            {
                var tablo = _veri.birTablo.Find(sayisal);    //K�rm�z� alt�izgide Ctrl+. yap�n�z
                if (tablo != null)
                {
                    mesaj = tablo.isim.ToString() + " ki�isi silindi...";
                    _veri.birTablo.Remove(tablo);           //sil
                    _veri.SaveChanges();                    //kaydet
                }
                else
                    mesaj = sayisal + " numaral� silinecek kay�t bulunamad�!";
            }
            else
                mesaj = "Bo� giri� veya say� olmayan giri� vard�!";
        }
        public void OnGet()
        {
            mesaj = "Silinecek ID'yi giriniz";
        }
    }
}
