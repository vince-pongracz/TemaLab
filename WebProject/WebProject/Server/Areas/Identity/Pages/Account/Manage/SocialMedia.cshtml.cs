using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Server.Services;

namespace WebProject.Server.Areas.Identity.Pages.Account.Manage
{
    public class SocialMediaModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public SocialMediaModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [DataType(DataType.Url)]
            [Display(Name = "Facebook Link")]
            public string FacebookLink { get; set; }

            [DataType(DataType.Url)]
            [Display(Name = "Instagram Link")]
            public string InstagramLink { get; set; }
        }

        private async Task LoadAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            Input = new InputModel
            {
                FacebookLink = user.FacebookLink == null ? "" : user.FacebookLink,
                InstagramLink = user.InstagramLink == null ? "" : user.InstagramLink,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.FacebookLink = Input.FacebookLink;
            user.InstagramLink = Input.InstagramLink;
            await _context.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your social media links has been set.";

            return Page();
        }
    }
}
