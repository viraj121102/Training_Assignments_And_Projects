﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRazorApp.Data;
using MyRazorApp.Models;

namespace MyRazorApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly MyRazorApp.Data.EcomContext _context;

        public CreateModel(MyRazorApp.Data.EcomContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["categId"] = new SelectList(_context.Categories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
