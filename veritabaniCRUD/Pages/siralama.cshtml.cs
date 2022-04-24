using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class siralamaModel : PageModel
    {
        private readonly ApplicationDbContext _veri;     //K�rm�z� alt�izgide Ctrl+. yap�n�z
        public IList<birTablo>? _tablo { get; set; }     //K�rm�z� alt�izgide Ctrl+. yap�n�z

        public siralamaModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }
        public string? mesaj { get; set; }

        public void OnGet(string? sirala = null, string? yon = null)
        {
            if (sirala != null && yon != null)
            {
                switch (sirala)
                {
                    case "ID":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.ID).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.ID).ToList();
                        mesaj = "S�ralama yap�ld�";
                        break;
                    case "isim":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.isim).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.isim).ToList();
                        mesaj = "S�ralama yap�ld�";
                        break;
                    case "ucret":
                        if (yon == "az")
                            _tablo = _veri.birTablo.OrderBy(x => x.ucret).ToList();
                        else
                            _tablo = _veri.birTablo.OrderByDescending(x => x.ucret).ToList();
                        mesaj = "S�ralama yap�ld�";
                        break;
                    default:
                        mesaj = "S�ralama do�ru olarak se�ilmedi.";
                        break;
                }

            }
            else
                mesaj = "S�ralama se�iniz.";
        }
    }
}
