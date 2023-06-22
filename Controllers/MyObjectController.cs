[ApiController]
[Route("[controller]")]
public class MyObjectController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly ITopicClient _topicClient;

    public MyObjectController(IRepository repository, ITopicClient topicClient)
    {
        _repository = repository;
        _topicClient = topicClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MyObjectDto dto)
    {
        await _repository.Save(dto);
        var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto)));
        await _topicClient.SendAsync(message);

        return Ok();
    }
}
