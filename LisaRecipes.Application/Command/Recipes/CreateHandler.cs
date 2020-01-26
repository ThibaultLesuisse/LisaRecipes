using LisaRecipes.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LisaRecipes.Application.Command.Recipes
{
    public class CreateHandler : IRequestHandler<Create, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        

        public async Task<Unit> Handle(Create request, CancellationToken cancellationToken)
        {
            await unitOfWork.recipeRepository.Create(request.Recipe);
            return await Unit.Task;
        }
    }
}
