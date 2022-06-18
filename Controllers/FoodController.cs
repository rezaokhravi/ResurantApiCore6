using System.Net;
using AutoMapper;
using Core6.Models.Dtos;
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
    private readonly IMapper _mapper; 

    public FoodController(ILogger<ResturantController> logger, IFood food, ResponseResult result,IMapper mapper)
    {
        _logger = logger;
        _food = food;
        _result = result;
        _mapper=mapper;
    }

    /// <summary>
    /// سرویس دریافت لیست منوی غذا
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var data = await _food.GetList();
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = _mapper.Map<List<FoodListDtos>>(data) ;
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
            var data = await _food.Insert(_mapper.Map<Foods>(food));
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data =  _mapper.Map<FoodListDtos>(data);
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
            var data = await _food.Update(_mapper.Map<Foods>(food));
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data =  _mapper.Map<FoodListDtos>(data);
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
            _result.Data =  _mapper.Map<FoodListDtos>(data);
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
            _result.Data =  _mapper.Map<FoodListDtos>(data);
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