using MediatR;
using Bookeasy.Application.Common.Exceptions;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
        {
            private readonly INorthwindDbContext _context;

            public DeleteCategoryCommandHandler(INorthwindDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Categories
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                _context.Categories.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
