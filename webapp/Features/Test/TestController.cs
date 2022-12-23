using Microsoft.AspNetCore.Mvc;
using webapp.Features.Test.TestModels;
using webapp.Features.Test.TestViews;

namespace webapp.Features.Test;

[ApiController]
[Route("assignments")]

public class TestController : ControllerBase
{
    private static List<TestModel>
        _mockDbTestModels = new List<TestModel>();


    public TestController()
    {
    }



    [HttpPost]
    public TestResponse Add(TestRequest request)
    {
        var test = new TestModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            TestDate = request.TestDate

        };

        _mockDbTestModels.Add(test);
        return new TestResponse
        {
            Id = test.id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }


    [HttpGet]
    public IEnumerable<TestResponse> Get()
    {
        return _mockDbTestModels.Select(
            test => new TestResponse
            {
                Id = test.id,
                Subject = test.Subject,
                TestDate = test.TestDate
            }).ToList();
    }


    [HttpGet("{id}")]

    public TestResponse Get([FromRoute] string id)
    {
        var test = _mockDbTestModels.FirstOrDefault(x => x.id == id);
        if (test is null)
        {
            return null;
        }

        return new TestResponse()
        {
            Id = test.id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }

    [HttpDelete("{id}")]
        
           public TestModel Delete([FromRoute] string id)
        {
            var test = _mockDbTestModels.FirstOrDefault(x => x.id == id);
            if (test is null)
            {
                return null;
            }

            _mockDbTestModels.Remove(test);
            return test;
        }
    }

