using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class guncellemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;    //K�rm�z� alt�izgide Ctrl+. yap�n�z
        public guncellemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public string? mesaj;   
        public string? guncelIsim;
        public float guncelUcret;
        public int guncelID;

        public void OnGet(int? ID)
        {
            if (ID != null)
            {
                var tablo = _veri.birTablo.Find(ID);    //K�rm�z� alt�izgide Ctrl+. yap�n�z
                if (tablo != null)
                {
                    mesaj = tablo.isim.ToString() + " ki�isi bulundu...";
                    guncelIsim = tablo.isim;
                    guncelUcret = tablo.ucret;
                    guncelID = tablo.ID;
                }
                else
                    mesaj = ID + " numaral� kay�t bulunamad�!";
            }
            else
                mesaj = "G�ncellenecek ki�inin ID'sini giriniz";
        }

        public void OnPostGuncel()
        {
            float sayisal;
            if (!String.IsNullOrEmpty(Request.Form["isim"]) &&
                float.TryParse(Request.Form["ucret"], out sayisal))
            {
                guncelID = Convert.ToInt32(Request.Form["ID"]);
                var tablo = _veri.birTablo.Find(guncelID);       //K�rm�z� alt�izgide Ctrl+. yap�n�z
                if (tablo != null)
                {
                    tablo.isim = Request.Form["isim"];
                    tablo.ucret = (float)Convert.ToDouble(Request.Form["ucret"]);
                    _veri.birTablo.Update(tablo);                   //g�ncelle
                    _veri.SaveChanges();                            //kaydet
                    mesaj = Request.Form["isim"] + " ki�isi g�ncellendi...";
                }else
                    mesaj = guncelID + " numaral� kay�t bulunamad�!";
            }
            else
            {
                mesaj = "Bo� giri� veya say� olmayan giri� vard�!";
            }
        }
    }
}
