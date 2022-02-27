﻿using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {

            //var lanches = _lancheRepository.Lanches;
            //return View(lanches);

            var lancheslistViewModel = new LancheListViewModel();
            lancheslistViewModel.Lanches = _lancheRepository.Lanches;
            lancheslistViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheslistViewModel);
        }
    }
}
