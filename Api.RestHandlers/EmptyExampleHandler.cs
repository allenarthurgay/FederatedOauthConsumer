using Api.Contracts;
using ServiceStack.ServiceInterface;

namespace Api.RestHandlers
{
    public class EmptyExampleHandler: RestServiceBase<EmptyDto>
    {
        public override object OnGet(EmptyDto request)
        {
            return "OK";
        }
    }
}
