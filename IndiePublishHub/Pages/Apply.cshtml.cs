using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IndiePublishHub.Data;
using IndiePublishHub.Models;
using System.ComponentModel.DataAnnotations;

namespace IndiePublishHub.Pages
{
    public class ApplyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ApplyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application Application { get; set; } = new();

        [BindProperty]
        [Required(ErrorMessage = "Выберите хотя бы один магазин")]
        public List<string> SelectedStores { get; set; } = new();

        public bool ShowSuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Сохраняем выбранные магазины
            Application.PreferredStores = string.Join(", ", SelectedStores);
            
            _context.Applications.Add(Application);
            await _context.SaveChangesAsync();

            ShowSuccessMessage = true;
            ModelState.Clear();
            Application = new Application();

            return Page();
        }
    }
}