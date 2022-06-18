
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core6.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StackOverflowController : Controller
{
    private readonly ILogger<ResturantController> _logger;
    private readonly IStackOverflow _stackOverflow;
    private readonly ResponseResult _result;
    public StackOverflowController(ILogger<ResturantController> logger, IStackOverflow stackOverflow ,ResponseResult result)
    {
        _logger = logger;
        _stackOverflow = stackOverflow;
        _result = result;
    }

    /// <summary>
    /// سرویس دریافت لیست پست های یک کاربر
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetListPostByUserId(int userId)
    {
        try
        {
            var data = await _stackOverflow.GetListPostByUserId(userId);
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