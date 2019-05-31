using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
	public class AccountsController : Controller
	{
		private readonly MvcMovieContext _context;

		public AccountsController(MvcMovieContext context)
		{
			_context = context;
		}

		// GET: Accounts
		public async Task<IActionResult> Index()
		{
			return View(await _context.Account.ToListAsync());
		}

		public IActionResult GoToSummary()
		{
			return RedirectToAction("Summary", new { Id = Account.ID });
		}

		// GET: Accounts/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var account = await _context.Account
				.FirstOrDefaultAsync(m => m.ID == id);
			if (account == null)
			{
				return NotFound();
			}

			return View(account);
		}

		public async Task<IActionResult> Summary(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var account = await _context.Account
				.FirstOrDefaultAsync(m => m.ID == id);
			if (account == null && id != 0)
			{
				return NotFound();
			}

			return View(account);
		}

		// GET: Accounts/Create
		public IActionResult Create()
		{
			IsNew = true;
			return View();
		}

		public IActionResult CreateSuccess()
		{
			IsNew = false;
			return View();
		}

		// POST: Accounts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,Password,ConfirmPassword,Address,PhoneNumber")] Account account)
		{
			if (ModelState.IsValid)
			{
				_context.Add(account);
				await _context.SaveChangesAsync();
				Account = account;
				return RedirectToAction("Summary", new { Id = account.ID });

			}
			return View(account);
		}

		public static bool LoginFailed { get; set; }

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([Bind("Email,Password")] Account account)
		{
			var user = _context.Account.FirstOrDefault(acct => acct.Email == account.Email && acct.Password == account.Password);
			LoginFailed = false;
			if (user != null)
			{
				Account = user;
			}
			else if (account.Email == "mvcSupport@mvcSupport" && account.Password == "mvcSupport")
			{
				Account = new Account() { FirstName = "Movie Support", IsAdmin = true };
			}
			else if (account.Email != null)
			{
				LoginFailed = true;
			}

			if (Account != null)
			{
				_context.Timestamps.Load();
				_context.Add(new Timestamp() { AccountID = Account.ID, LoginTime = DateTime.UtcNow });
				await _context.SaveChangesAsync();
				_context.Timestamps.Load();
				Account.Timestamps = new List<Timestamp>(_context.Timestamps.Where(t => t.AccountID == Account.ID));
				return View("../Home/Index");
			}
			return View(account);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout([Bind("Email,Password")] Account account)
        {
            Account = null;
            LoginFailed = false;
            return View("../Home/Index");

        }
        public IActionResult Logout()
        {
            Account = null;
            LoginFailed = false;
            return View("../Home/Index");
        }

        public static bool IsSupport => Account?.IsAdmin ?? false;
		public static Account Account { get; set; }
		public static bool IsNew { get; set; }

		// GET: Accounts/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Password,ConfirmPassword,Address,PhoneNumber,IsAdmin")] Account account)
        {
            if (id != account.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Changes(int? id)
        {
			IsNew = false;
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Changes(int id, [Bind("ID,FirstName,LastName,Email,Password,ConfirmPassword,Address,PhoneNumber")] Account account)
        {
            if (id != account.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Summary", new { Id = account.ID });
            }
            return View(account);
        }


        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.ID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
			IsNew = false;
			var account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.ID == id);
        }
    }
}
