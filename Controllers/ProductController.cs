using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASM4.Models;

namespace ASM4.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    //private readonly ILogger<ProductController> _logger;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    public IActionResult Add()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        var product = _productRepository.GetById(id); if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public IActionResult Update(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Product product, IFormFile imageUrl)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            if (imageUrl != null)
            {
                product.ImageUrl = await SaveImage(imageUrl);

            }
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetById(id); if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
    {
        if (ModelState.IsValid)
        {
            if (imageUrl != null)
            {
                product.ImageUrl = await SaveImage(imageUrl);
            }
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }
    private async Task<string> SaveImage(IFormFile image)
    {
        var savePath = Path.Combine("wwwroot/images", image.FileName); // Thay đổi đường dẫn theo cấu hình của bạn
        using (var fileStream = new FileStream(savePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }
        return "/images/" + image.FileName; // Trả về đường dẫn tương đối
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

