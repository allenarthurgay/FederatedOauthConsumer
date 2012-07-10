using Api.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.Implementations.Handlers
{
    public class EmptyExampleHandler: RestServiceBase<EmptyDto>
    {
        public override object OnGet(EmptyDto request)
        {
            return "OK";
        }
    }
}
