using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demoerpnxt.Models;

namespace demoerpnxt.Controllers
{
    public class BillsController : Controller
    {
        private readonly demoerpContext _context;

        public BillsController(demoerpContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var demoerpContext = _context.Bills.Include(b => b.Buyers).Include(b => b.Items).Include(b => b.Sellers);
            return View(await demoerpContext.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Buyers)
                .Include(b => b.Items)
                .Include(b => b.Sellers)
                .FirstOrDefaultAsync(m => m.Billno == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["Buyersid"] = new SelectList(_context.Buyers, "Buyerid", "Buyerid");
            ViewData["Itemsid"] = new SelectList(_context.Items, "Itemid", "Itemid");
            ViewData["Sellersid"] = new SelectList(_context.Sellers, "Sellerid", "Sellerid");

            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Billno,Buyersid,Buyersname,Buydate,Itemsid,Itemsname,Itemsquant,Sellersid,Sellersname,Totalamount,Paidamount,Remainingamount")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                var Found_items=_context.Items.Find(bill.Itemsid);

                    Found_items.Itemquant = Convert.ToInt32(Found_items.Itemquant) - Convert.ToInt32(bill.Itemsquant);
                    _context.Items.Update(Found_items);
                    _context.Add(bill);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Buyersid"] = new SelectList(_context.Buyers, "Buyerid", "Buyerid", bill.Buyersid);
            ViewData["Itemsid"] = new SelectList(_context.Items, "Itemid", "Itemid", bill.Itemsid);
            ViewData["Sellersid"] = new SelectList(_context.Sellers, "Sellerid", "Sellerid", bill.Sellersid);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["Buyersid"] = new SelectList(_context.Buyers, "Buyerid", "Buyerid", bill.Buyersid);
            ViewData["Itemsid"] = new SelectList(_context.Items, "Itemid", "Itemid", bill.Itemsid);
            ViewData["Sellersid"] = new SelectList(_context.Sellers, "Sellerid", "Sellerid", bill.Sellersid);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Billno,Buyersid,Buyersname,Buydate,Itemsid,Itemsname,Itemsquant,Sellersid,Sellersname,Totalamount,Paidamount,Remainingamount")] Bill bill)
        {
            if (id != bill.Billno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Billno))
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
            ViewData["Buyersid"] = new SelectList(_context.Buyers, "Buyerid", "Buyerid", bill.Buyersid);
            ViewData["Itemsid"] = new SelectList(_context.Items, "Itemid", "Itemid", bill.Itemsid);
            ViewData["Sellersid"] = new SelectList(_context.Sellers, "Sellerid", "Sellerid", bill.Sellersid);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.Buyers)
                .Include(b => b.Items)
                .Include(b => b.Sellers)
                .FirstOrDefaultAsync(m => m.Billno == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Billno == id);
        }

        [HttpPost, ActionName("AjaxMethodforbuyer")]
        public JsonResult AjaxMethodforbuyer(int id)
        {

            var buyers_names = _context.Buyers.Find(id).Buyername;

            // ViewData["Sellersname"] = r;
            return Json(buyers_names);
        }
        [HttpPost, ActionName("AjaxMethodforitem")]
        public JsonResult AjaxMethodforitem(int id)
        {

            var items_names = _context.Items.Find(id);

          
            return Json(items_names);
        }
        [HttpPost, ActionName("AjaxMethodforseller")]
        public JsonResult AjaxMethodforseller(int id)
        {

            var sellers_names = _context.Sellers.Find(id).Sellername;
            return Json(sellers_names);
        }
    }
}
