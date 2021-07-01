using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, PersonModel>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IDataAccess dataAccess, IMediator mediator)
        {
            _dataAccess = dataAccess;
            _mediator = mediator;
        }
        public async Task<PersonModel> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new GetPersonListQuery());
            return await Task.FromResult(result.Where(x => x.Id == request.id).FirstOrDefault());
        }
    }
}
