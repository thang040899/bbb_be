﻿using Application.DTOs.Tag;
using Application.DTOs.Tag.TagRequest;
using Application.Exceptions;
using Application.Interfaces.Repo;
using Application.Interfaces.UoW;
using Application.Wrappers;
using Domain.Base;
using MediatR;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using ThirdPartyServices.Storage;

namespace Application.Features.Tag.Commands
{
    public class StrongDeleteCommand : IRequest<Response<Domain.Entities.Tag>>
    {
        [JsonIgnore]
        internal int Id { get; set; }
        public void SetId(int id)
        {
            Id = id;
        }
    }
    public class StrongDeleteCommandHandler : IRequestHandler<StrongDeleteCommand, Response<Domain.Entities.Tag>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        public StrongDeleteCommandHandler(IUnitOfWork unitOfWork, IStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public async Task<Response<Domain.Entities.Tag>> Handle(StrongDeleteCommand request, CancellationToken cancellationToken)
        {

            var Tag = await _unitOfWork.TagRepo.GetByIdAsync(request.Id);
            if (Tag == null)
                throw new NotFoundException("Tag not found");
            if (!_unitOfWork.TagRepo.CheckAuthorizeResource(Tag))
                throw new UnauthorizeException();
            var res = _unitOfWork.TagRepo.StrongDelete(Tag);

            if (!_unitOfWork.Commit())
                throw new DeleteRequestException("StrongDelete fail");
            else
            {
                //await _storageService.DeleteFileAsync(Tag.Thumbnail, 0);
                return new CommandOK<Domain.Entities.Tag>()
                {
                    ObjectId = Tag.Id,
                    Msg = "StrongDelete Tag OK",
                };
            }
        }
    }
}
