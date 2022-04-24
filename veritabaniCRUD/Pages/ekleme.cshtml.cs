using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class eklemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //K�rm�z� alt�izgide Ctrl+. yap�n�z
        public eklemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;
        public void OnPostYeni()
        {
            float sayisal;
            if (!String.IsNullOrEmpty(Request.Form["isim"]) &&
                float.TryParse(Request.Form["ucret"], out sayisal))
            {
                birTablo tablo = new birTablo();        //K�rm�z� alt�izgide Ctrl+. yap�n�z
                tablo.isim = Request.Form["isim"];
                tablo.ucret = (float)Convert.ToDouble(Request.Form["ucret"]);
                _veri.birTablo.Add(tablo);              //ekle
                _veri.SaveChanges();                    //kaydet
                mesaj = Request.Form["isim"] + " ki�isi ba�ar�yla eklendi...";
            }
            else
            {
                mesaj = "Bo� giri� veya say� olmayan giri� vard�!";
            }
        }
        public void OnGet()
        {
            mesaj = "Ekleme formunu doldurunuz";
        }
    }
}
