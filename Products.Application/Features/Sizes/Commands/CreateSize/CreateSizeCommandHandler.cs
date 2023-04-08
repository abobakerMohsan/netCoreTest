using AutoMapper;
using Products.Application.Contracts.Persistence;
using Products.Domain.Entites;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Products.Domain.Entities;

namespace Products.Application.Features.Sizes.Commands.CreateSize
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, Guid>
    {
        private readonly ISizeRepository _postRepository;
        private readonly IMapper _mapper;

        public CreateSizeCommandHandler(ISizeRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            MainSize post = _mapper.Map<MainSize>(request);

            CreateSizeCommandValidator validator = new CreateSizeCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Size is not valid");
            }

            post = await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}
