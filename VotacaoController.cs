﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Urna.Models;

namespace MVC_Urna.Controllers
{
    public class VotacaoController : Controller
    {
        private readonly Context _context;

        public VotacaoController(Context context)
        {
            _context = context;
        }

        // GET: Votacao
        public async Task<IActionResult> Index()
        {
            var context = _context.Votacao.Include(v => v.Candidatos);
            return View(await context.ToListAsync());
        }

        // GET: Votacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votacao = await _context.Votacao
                .Include(v => v.Candidatos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votacao == null)
            {
                return NotFound();
            }

            return View(votacao);
        }

        // GET: Votacao/Create
        public IActionResult Create()
        {
            ViewData["CandidatosId"] = new SelectList(_context.Candidatos, "Id", "Id");
            return View();
        }

        // POST: Votacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Candidato,Data_Cadastro,CandidatosId")] Votacao votacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(votacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatosId"] = new SelectList(_context.Candidatos, "Id", "Id", votacao.CandidatosId);
            return View(votacao);
        }

        // GET: Votacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votacao = await _context.Votacao.FindAsync(id);
            if (votacao == null)
            {
                return NotFound();
            }
            ViewData["CandidatosId"] = new SelectList(_context.Candidatos, "Id", "Id", votacao.CandidatosId);
            return View(votacao);
        }

        // POST: Votacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Candidato,Data_Cadastro,CandidatosId")] Votacao votacao)
        {
            if (id != votacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(votacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotacaoExists(votacao.Id))
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
            ViewData["CandidatosId"] = new SelectList(_context.Candidatos, "Id", "Id", votacao.CandidatosId);
            return View(votacao);
        }

        // GET: Votacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votacao = await _context.Votacao
                .Include(v => v.Candidatos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votacao == null)
            {
                return NotFound();
            }

            return View(votacao);
        }

        // POST: Votacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var votacao = await _context.Votacao.FindAsync(id);
            _context.Votacao.Remove(votacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotacaoExists(int id)
        {
            return _context.Votacao.Any(e => e.Id == id);
        }
    }
}
