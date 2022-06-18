using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResurantApiCore6.Models.Dtos;

namespace Core6.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class ResturantController : Controller
{
    private readonly ILogger<ResturantController> _logger;
    private readonly IResturant _resturant;
    private readonly ResponseResult _result;
    public ResturantController(ILogger<ResturantController> logger, IResturant resturant, ResponseResult result)
    {
        _logger = logger;
        _resturant = resturant;
        _result = result;
    }

    /// <summary>
    /// سرویس دریافت لیست رستوان
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var data = await _resturant.GetList();
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
    /// سرویس ایجاد یک رستوران بر اساس مدل وروردی 
    /// </summary>
    /// <param name="resturant"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Insert([FromQuery] ResturantsInsertModel resturant)
    {
        try
        {

            var data = await _resturant.Insert(new Resturants()
            {
                ID = 0,
                TITLE = resturant.TITLE,
                PHONE = resturant.PHONE,
                MOBILE = resturant.MOBILE,
                ADDRESS = resturant.ADDRESS,
                DESCRIPTIONS = resturant.DESCRIPTIONS
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
    /// سرویس آپدیت یک رستون براساس مدل ورودی
    /// </summary>
    /// <param name="resturant"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Update([FromQuery] ResturantsUpdateModel resturant)
    {
        try
        {
            var data = await _resturant.Update(new Resturants()
            {
                ID = resturant.ID,
                TITLE = resturant.TITLE,
                PHONE = resturant.PHONE,
                MOBILE = resturant.MOBILE,
                ADDRESS = resturant.ADDRESS,
                DESCRIPTIONS = resturant.DESCRIPTIONS
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
    ///  سرویس حذف اطلاعات  یک رستوران با استفاده از شناسه رستوران
    /// </summary>
    /// <param name="resturant_id"></param>
    /// <returns></returns>
    [HttpGet("{resturant_id:int}")]
    public async Task<IActionResult> DeleteById(long resturant_id)
    {
        try
        {
            var data = await _resturant.DeleteById(resturant_id);
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
    /// سرویس دریافت رستوران براساس شناسه رستوران
    /// </summary>
    /// <param name="resturant_id"></param>
    /// <returns></returns>
    [HttpGet("{resturant_id:int}")]
    public IActionResult GetById(long resturant_id)
    {
        try
        {

            var data = _resturant.GetByID(resturant_id);
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