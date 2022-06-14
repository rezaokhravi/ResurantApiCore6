using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core6.Controllers;

public class FoodController : Controller {
    private readonly ILogger<ResturantController> _logger;
    private readonly IFood _food;
    private readonly ResponseResult _result;
    public FoodController(ILogger<ResturantController> logger, IFood food, ResponseResult result) {
        _logger = logger;
        _food = food;
        _result = result;
    }

    [HttpGet]
    public async Task<IActionResult> GetList () {
        try {
            var data = await _food.GetList ();
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
    public async Task<IActionResult> Insert ([FromBody] Foods food) {
        try {
            var data = await _food.Insert (food);
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
    public async Task<IActionResult> Update ([FromBody] Foods food) {
        try {
            var data = await _food.Update(food);
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
    public async Task<IActionResult> DeleteById([FromBody] int foodId) {
        try {
            var data = await _food.DeleteById(foodId);
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