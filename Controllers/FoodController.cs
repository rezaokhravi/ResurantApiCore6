using System.Net;
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResurantApiCore6.Models.Dtos;

namespace Core6.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class FoodController : Controller
{
    private readonly ILogger<ResturantController> _logger;
    private readonly IFood _food;
    private readonly ResponseResult _result;
    public FoodController(ILogger<ResturantController> logger, IFood food, ResponseResult result)
    {
        _logger = logger;
        _food = food;
        _result = result;
    }

    /// <summary>
    /// سرویس دریافت لیست منوی غذا
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var data = await _food.GetList();
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok(_result);
        }
        catch (Exception ex)
        {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok(_result);
        }
    }

    /// <summary>
    /// سرویس ایجاد یک غذا بر اساس مدل وروردی
    /// </summary>
    /// <param name="food"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> Insert([FromQuery] FoodsInsertModel food)
    {
        try
        {
            var data = await _food.Insert(new Foods(){
                ID=0,
                PRICE=food.PRICE,
                TITLE=food.TITLE,
                DESCRIPTIONS=food.DESCRIPTIONS,
                RES_ID = food.RES_ID
            });
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok(_result);
        }
        catch (Exception ex)
        {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok(_result);
        }
    }

    /// <summary>
    /// سرویس آپدیت یک غذا براساس مدل ورودی
    /// </summary>
    /// <param name="food"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Update([FromQuery] FoodsUpdateModel food)
    {
        try
        {
            var data = await _food.Update(new Foods(){
                ID=food.ID,
                TITLE=food.TITLE,
                PRICE=food.PRICE,
                DESCRIPTIONS=food.DESCRIPTIONS,
                RES_ID = food.RES_ID
            });
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok(_result);
        }
        catch (Exception ex)
        {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok(_result);
        }
    }

    /// <summary>
    /// سرویس حذف اطلاعات  یک غذا با استفاده از شناسه غذا
    /// </summary>
    /// <param name="food_id"></param>
    /// <returns></returns>
    [HttpGet("{food_id:int}")]
    public async Task<IActionResult> DeleteById(int food_id)
    {
        try
        {
            var data = await _food.DeleteById(food_id);
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok(_result);
        }
        catch (Exception ex)
        {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok(_result);
        }
    }

    /// <summary>
    ///  سرویس دریافت غذا براساس شناسه غذا
    /// </summary>
    /// <param name="food_id"></param>
    /// <returns></returns>
    [HttpGet("{food_id:int}")]
    public IActionResult GetById(long food_id)
    {
        try
        {
            var data = _food.GetByID(food_id);
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok(_result);
        }
        catch (Exception ex)
        {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok(_result);
        }
    }

}