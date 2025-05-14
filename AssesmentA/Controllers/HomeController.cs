using System.Diagnostics;
using AssesmentA.Data;
using Microsoft.AspNetCore.Mvc;
using AssesmentA.Models;
using Microsoft.EntityFrameworkCore;

namespace AssesmentA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _dbContext;
    
    public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<JsonResult> GetProdukList()
    {
        var draw = Request.Query["draw"].FirstOrDefault();
        var search = Request.Query["search[value]"].FirstOrDefault();

        var produks = await _dbContext.Produks.FromSql(
            $"EXEC sp_GetProdukList @NamaBarang = {search}, @KodeBarang = {search}").ToListAsync();

        var totalRecord = produks.Count;
        
        var returnObj = new {
            draw = draw,
            recordsTotal = totalRecord,
            recordsFiltered = totalRecord,
            data = produks
        };

        return Json(returnObj);
    }

    public IActionResult Create()
    {
        return View(new CreateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel request)
    {
        try
        {
            var rows = await _dbContext.Database.ExecuteSqlAsync(
                $"EXEC sp_CreateProduk @NamaBarang = {request.NamaBarang}, @KodeBarang = {request.KodeBarang}, @JumlahBarang = {request.JumlahBarang}, @Tanggal = {request.Tanggal}");

            if (rows == 0)
            {
                throw new Exception("Failed to update data");
            }

            TempData["alertColor"] = "alert-success";
            TempData["alertMessage"] = "Success create data produk";

        }
        catch (Exception e)
        {
            TempData["alertColor"] = "alert-danger";
            TempData["alertMessage"] = "Failed to create produk";
            
            _logger.LogError(e, e.Message);
        }
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var produks = await _dbContext.Produks.FromSql(
            $"EXEC sp_GetProdukById @Id = {id}").ToListAsync();

        var produk = produks.FirstOrDefault();
        if (produk == null)
        {
            throw new Exception("Data is not found");
        }

        return View(new UpdateViewModel()
        {
            Id = produk.Id,
            Tanggal = produk.Tanggal,
            JumlahBarang = produk.JumlahBarang,
            NamaBarang = produk.NamaBarang,
            KodeBarang = produk.KodeBarang,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateViewModel request)
    {
        try
        {
            var rows = await _dbContext.Database.ExecuteSqlAsync(
                $"EXEC sp_UpdateProduk @Id = {request.Id}, @NamaBarang = {request.NamaBarang}, @KodeBarang = {request.KodeBarang}, @JumlahBarang = {request.JumlahBarang}, @Tanggal = {request.Tanggal}");

            if (rows == 0)
            {
                throw new Exception("Failed to update data");
            }
            
            TempData["alertColor"] = "alert-success";
            TempData["alertMessage"] = $"Success update data produk : {request.NamaBarang}";
        }
        catch (Exception e)
        {
            TempData["alertColor"] = "alert-danger";
            TempData["alertMessage"] = "Failed to update produk";
            
            _logger.LogError(e, e.Message);
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var rows = await _dbContext.Database.ExecuteSqlAsync(
                $"EXEC sp_DeleteProdukById @Id = {id}");

            if (rows == 0)
            {
                throw new Exception("Failed to delete data");
            }

            
            TempData["alertColor"] = "alert-success";
            TempData["alertMessage"] = $"Success delete data produk : {id}";
        }
        catch (Exception e)
        {
            TempData["alertColor"] = "alert-danger";
            TempData["alertMessage"] = "Failed to delete produk";
            
            _logger.LogError(e, e.Message);
        }
        
        return RedirectToAction("Index");
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