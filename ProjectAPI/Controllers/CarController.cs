using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;
using ProjectAPI.Service;
using ProjectAPI.Sharecomponent;
using System;
using System.Linq;

namespace ProjectAPI.Controllers
{
    [Route("api/web/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _CarService;
        ResponseModel model = new ResponseModel();

        public CarController(ICarService service)
        {
            _CarService = service;
        }

        /// <summary>
        /// get all CARs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("view")]
        public IActionResult GetAllCARs()
        {
            try
            {
                var CARs = _CarService.GetCARList();
                if (CARs == null || CARs.Count==0) return NotFound(model.Messsage = "Error : Khong tim CAR nao! ");
                return Ok(CARs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get CAR details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("detail")]
        public IActionResult GetCARById(int id)
        {
            try
            {
                var CAR = _CarService.GetCARDetailsById(id);
                if (CAR == null) return NotFound(model.Messsage = "Error : Khong tim thay ID !");
                return Ok(CAR);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save CAR
        /// </summary>
        /// <param name="CARModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddOrUp")]
        public IActionResult SaveCAR(CAR CARModel)
        {
            try
            {
                var model = _CarService.SaveCAR(CARModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(model.Messsage = "Error : loi them/sua !");
            }
        }

        /// <summary>
        /// delete CAR
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteCAR(int id)
        {
            try
            {
                var model = _CarService.DeleteCAR(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(model.Messsage = "Error : loi xoa !");
            }
        }
    }
}
