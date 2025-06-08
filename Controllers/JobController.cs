using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using SmartMarketplace.DTO;
using SmartMarketplace.Service;
using SmartMarketplace.Service.Interface;

namespace SmartMarketplace.Controllers;


[ApiController]
[Route("api/v1/jobs")]
public class JobController : ControllerBase
{
   readonly IGroqService _groqService;
  public JobController(IGroqService groqService)
  {
    _groqService = groqService;
  }

  [HttpGet("")]
  public JsonObject GetJobs()
  {
    var re = new PromtRequest
    {
      text = " ahemd khalil ben hos"
    };
    return _groqService.GetGroqRequestPromt(re);
  }


  [HttpPost]
  public Task<AiResponseDto> GetGroq([FromBody] PromtRequest req)
  {
    return _groqService.CallGroqAsync(req);
  }


}
