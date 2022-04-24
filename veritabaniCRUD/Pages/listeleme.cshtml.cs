using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using veritabaniCRUD.Data;
using veritabaniCRUD.Models;

namespace veritabaniCRUD.Pages
{
    public class listelemeModel : PageModel
    {
        private readonly ApplicationDbContext _veri;     //K�rm�z� alt�izgide Ctrl+. yap�n�z
        public IList<birTablo>? _tablo { get; set; }     //K�rm�z� alt�izgide Ctrl+. yap�n�z

        public listelemeModel(ApplicationDbContext icerik)
        {
            _veri = icerik;
        }

        public void OnGet()
        {
            _tablo = _veri.birTablo.ToList();
        }
    }
}
