using System.Text.Json.Nodes;
using SmartMarketplace.DTO;

namespace SmartMarketplace.Service.Interface;

public interface IGroqService
{
  public  Task<AiResponseDto> CallGroqAsync(PromtRequest req);
  public JsonObject GetGroqRequestPromt(PromtRequest promt);


}
