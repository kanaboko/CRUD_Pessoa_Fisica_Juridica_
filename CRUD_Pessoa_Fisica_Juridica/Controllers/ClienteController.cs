using AutoMapper;
using CRUD_Pessoa_Fisica_Juridica.Models;
using CRUD_Pessoa_Fisica_Juridica.Service;
using CRUD_Pessoa_Fisica_Juridica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Pessoa_Fisica_Juridica.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Service_CRUD _service;
        public ClienteController()
        {
            _service = new Service_CRUD();
        }
        // GET: PessoaFisica
        public ActionResult Index()
        {

            return View(_service.ObterTodos());
        }

        // GET: PessoaFisica/Details/5
        public ActionResult Details(Guid id)
        {            
            var pessoa = _service.ObterPorIdPessoa(id);
            ViewBag.PessoaId = id;
            return View(pessoa);
        }

        // GET: PessoaFisica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaFisica/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _service.Adicionar(obj);
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.PessoaId = id;
            var pessoa = _service.ObterPorIdPessoa(id);
            ViewBag.PessoaFisicaId = pessoa.PessoaFisica.Id;            

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _service.AtualizarPessoa(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult ListarPessoaFisica(Guid id)
        {
            return PartialView("_ListarPessoaFisica", _service.ObterPorIdPessoaFisica(id).PessoaFisica);
        }

        public ActionResult ListarEnderecoPessoaFisica(Guid id)
        {
            return PartialView("_ListarEndereco", _service.ObterEnderecoPorPessoaFisica(id).Enderecos);
        }

        public ActionResult ListarEnderecoPessoaJuridica(Guid id)
        {
            return PartialView("_ListarEnderecoJuridico", _service.ObterEnderecoPorPessoaJuridica(id).Enderecos);
        }

        public ActionResult ListarPessoaJuridica(Guid id)
        {
            return PartialView("_ListarJuridica", _service.ObterPorIdPessoa(id).PessoaJuridica);
        }

        // GET: PessoaFisica/Edit/5
        public ActionResult EditPessoaFisica(Guid id)
        {
            ViewBag.PessoaFisicaId = id;
            var pessoa = _service.ObterPorIdPessoaFisica(id);
            //var pessoaFisica = pessoa.PessoaFisica;
            return PartialView("_EditarPessoaFisica", pessoa.PessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaFisica(PessoaFisicaViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _service.AtualizarPessoaFisica(pessoa);
                string url = Url.Action("ListarPessoaFisica", "Cliente", new { id = pessoa.Id });
                return Json(new { success = true, url = url, tipo = "pf" });
            }
            return PartialView("_EditarPessoaFisica", pessoa);
        }

        public ActionResult EditPessoaJuridica(Guid id)
        {
            var pessoa = _service.ObterPorIdPessoaJuridica(id);
            return PartialView("_EditarPessoaJuridica", pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaJuridica(PessoaJuridicaViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _service.AtualizarPessoaJuridica(pessoa);
                string url = Url.Action("ListarPessoaJuridica", "Cliente", new { id = pessoa.PessoaId });
                return Json(new { success = true, url = url, tipo = "pj" });
            }
            return PartialView("_EditarPessoaFisica", pessoa);
        }

        // GET: Endereco/Edit/5
        public ActionResult EditEndereco(Guid id, Guid pessoaId, Guid indice, string tipo = null)
        {
            ViewBag.PessoaFisicaId = pessoaId;
            ViewBag.Tipo = tipo;
            ViewBag.PessoaJuridicaCNPJ = indice;
            var endereco = _service.ObterEnderecoPorId(id);
            return PartialView("_EditarEndereco", endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEndereco(EnderecoViewModel endereco, Guid pessoaId, Guid indice, string tipo = null)
        {
            if (ModelState.IsValid)
            {
                _service.AtualizarEndereco(endereco);
                if(tipo!=null && tipo == "enderecoJuridico")
                {
                    string url = Url.Action("ListarEnderecoPessoaJuridica", "Cliente", new { id = pessoaId });
                    return Json(new { success = true, url = url, tipo = tipo, indice = indice });
                }
                else
                {
                    string url = Url.Action("ListarEnderecoPessoaFisica", "Cliente", new { id = pessoaId });
                    return Json(new { success = true, url = url, tipo = "enderecoFisico" });
                }
                
            }
            return PartialView("_EditarEndereco", endereco);
        }

        public ActionResult AdicionarEndereco(Guid pessoaId, string tipo, Guid indice)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.Tipo = tipo;
            ViewBag.PessoaJuridicaCNPJ = indice;
            return PartialView("_AdicionarEndereco");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel endereco, Guid pessoaId, Guid indice, string tipo = null )
        {
            if (ModelState.IsValid)
            {
                _service.AdicionarEndereco(endereco, pessoaId, tipo);

                if (tipo != null && tipo == "enderecoJuridico")
                {
                    string url = Url.Action("ListarEnderecoPessoaJuridica", "Cliente", new { id = pessoaId });
                    return Json(new { success = true, url = url, tipo = tipo, indice = indice });
                }
                else if (tipo != null && tipo == "enderecoFisico")
                {
                    string url = Url.Action("ListarEnderecoPessoaFisica", "Cliente", new { id = pessoaId });
                    return Json(new { success = true, url = url, tipo = "enderecoFisico" });
                }

            }
            return PartialView("_AdicionarEndereco", endereco);
        }

        public ActionResult AdicionarPessoaJuridica(Guid pessoaId)
        {
            ViewBag.PessoaId = pessoaId;            
            return PartialView("_AdicionarPessoaJuridica");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarPessoaJuridica(AdicionarPessoaJuridicaViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _service.AdicionarPessoaJuridica(obj);

                if (obj != null)
                {
                    string url = Url.Action("ListarPessoaJuridica", "Cliente", new { id = obj.PessoaJuridica.PessoaId });
                    return Json(new { success = true, url = url, tipo = "pj" });
                }
                
            }
            return PartialView("_AdicionarPessoaJuridica", obj);
        }

        // GET: PessoaFisica/Delete/5
        public ActionResult Delete(Guid id, Guid pessoaId, Guid indice, string tipo = null)
        {
            PessoaViewModel pessoa = _service.ObterPorIdPessoa(id);
            return View(pessoa);
        }

        // POST: PessoaFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _service.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEndereco(Guid id, Guid pessoaId, Guid indice, string tipo = null)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.Tipo = tipo;
            ViewBag.PessoaJuridicaCNPJ = indice;
            EnderecoViewModel endereco = _service.ObterEnderecoPorId(id);
            return PartialView("_DeletarEndereco", endereco);
        }

        // POST: PessoaFisica/Delete/5
        [HttpPost, ActionName("DeleteEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnderecoConfirmed(Guid id, Guid pessoaId, Guid indice, string tipo = null)
        {
            _service.RemoverEndereco(id);
            if (tipo != null && tipo == "enderecoJuridico")
            {
                string url = Url.Action("ListarEnderecoPessoaJuridica", "Cliente", new { id = pessoaId });
                return Json(new { success = true, url = url, tipo = tipo, indice = indice });
            }
            else if (tipo != null && tipo == "enderecoFisico")
            {
                string url = Url.Action("ListarEnderecoPessoaFisica", "Cliente", new { id = pessoaId });
                return Json(new { success = true, url = url, tipo = "enderecoFisico" });
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeletePessoaJuridica(Guid id, Guid pessoaId, string tipo = null)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.Tipo = tipo;
            PessoaJuridicaViewModel pessoaJuridica = _service.ObterPorIdPessoaJuridica(id);
            return PartialView("_DeletarPessoaJuridica", pessoaJuridica);
        }

        // POST: PessoaFisica/Delete/5
        [HttpPost, ActionName("DeletePessoaJuridica")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePessoaJuridicaConfirmed(Guid id, Guid pessoaId, string tipo = null)
        {
            _service.RemoverPessoaJuridica(id);
            if (tipo != null && tipo == "pj")
            {
                string url = Url.Action("ListarPessoaJuridica", "Cliente", new { id = pessoaId });
                return Json(new { success = true, url = url, tipo = tipo });
            }
            else if (tipo != null && tipo == "enderecoFisico")
            {
                string url = Url.Action("ListarEnderecoPessoaFisica", "Cliente", new { id = pessoaId });
                return Json(new { success = true, url = url, tipo = "enderecoFisico" });
            }
            return RedirectToAction("Index");
        }

    }
}
