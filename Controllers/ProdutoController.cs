using Microsoft.AspNetCore.Mvc;
using desafioIbid.Models;
using desafioIbid.Data;

namespace desafioIbid.Controllers


{
    public class ProdutoController : Controller
    {
        private readonly Contexto _context;

        //o contexto é uma classe que representa o banco de dados, e é injetado no construtor do controller
        public ProdutoController(Contexto context)
        {
            _context = context;
        }
    
        [HttpGet]
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Produtos.ToList());
        }

        [HttpGet] 
        public IActionResult Criar()
        {
            return View();
        }  


    //o metodo criar recebe um objeto do tipo produto, e verifica se o estado do model é valido, 
    //se for, ele adiciona o produto no banco de dados e redireciona para a pagina index, 
    //se não for, ele retorna a view com o produto
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(produto);
    }


    //o metodo editar[GET] recebe um id, e busca no banco de dados um produto com esse id,
    //se ele não encontrar, retorna um erro 404, se encontrar, retorna a view com o produto
    [HttpGet]
    public IActionResult Editar(int id)
    {
        var produto = _context.Produtos.Find(id);

        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    //o metodo editar[POST] recebe um produto, e verifica se o estado do model é valido,
    //se for, ele atualiza o produto no banco de dados e redireciona para a pagina index,
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Update(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(produto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Deletar(int id)
    {
        var produto = _context.Produtos.Find(id);
        if(produto == null)
        {
            return NotFound();
        }
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    }
}