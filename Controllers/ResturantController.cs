using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core6.Controllers;

public class ResturantController : Controller {
    private readonly ILogger<ResturantController> _logger;
    private readonly IResturant _resturant;
    private readonly ResponseResult _result;
    public ResturantController (ILogger<ResturantController> logger, IResturant resturant, ResponseResult result) {
        _logger = logger;
        _resturant = resturant;
        _result = result;
    }

    [HttpGet]
    public async Task<IActionResult> GetList () {
        try {
            var data = await _resturant.GetList ();
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok (_result);
        } catch (Exception ex) {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok (_result);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert ([FromBody] Resturants resturant) {
        try {
            var data = await _resturant.Insert (resturant);
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok (_result);
        } catch (Exception ex) {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok (_result);
        }
    }

     [HttpPost]
    public async Task<IActionResult> Update ([FromBody] Resturants resturant) {
        try {
            var data = await _resturant.Update(resturant);
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok (_result);
        } catch (Exception ex) {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok (_result);
        }
    }

    
     [HttpPost]
    public async Task<IActionResult> DeleteById([FromBody] int resturantId) {
        try {
            var data = await _resturant.DeleteById(resturantId);
            _result.IsSucess = true;
            _result.StatusCode = 200;
            _result.Message = "عملیات با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = data;
            return Ok (_result);
        } catch (Exception ex) {
            _result.IsSucess = false;
            _result.StatusCode = 500;
            _result.Error = ex.Message;
            _result.Message = "عملیات با خطا مواجه شد";
            _result.Data = null;
            return Ok (_result);
        }
    }

}