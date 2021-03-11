using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetImageById(imageId);
            if (result.Success) return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(carImage, formFile);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm(Name = "Image")] IFormFile formFile)
        {
            var result = _carImageService.UpdateCarImage(carImage, formFile);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int imageId)
        {
            var carImage = _carImageService.GetImageById(imageId).Data;
            var result = _carImageService.DeleteCarImage(carImage);
            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
