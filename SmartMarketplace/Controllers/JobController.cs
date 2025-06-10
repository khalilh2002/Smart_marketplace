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

  [HttpPost("create-from-prompt")]
  [ProducesResponseType(typeof(JobDto), 200)]
  [ProducesResponseType(500)]
  public async Task<ActionResult<JobDto>> CreateJobFromPrompt([FromBody] PromtRequest req)
  {
    if (string.IsNullOrWhiteSpace(req?.text))
    {
      return BadRequest("The request text cannot be empty.");
    }

    try
    {
      var jobDto = await _groqService.CreateJobFromPromptAsync(req);
      return Ok(jobDto);
    }
    catch (Exception ex)
    {
      // Log the exception ex
      return StatusCode(500, "An error occurred while processing your request.");
    }
  }


}
