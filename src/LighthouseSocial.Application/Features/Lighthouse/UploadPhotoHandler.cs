
using LighthouseSocial.Application.Common;
using LighthouseSocial.Application.Dtos;
using LighthouseSocial.Domain.Interfaces;
using LighthouseSocial.Domain.ValueObjects;

namespace LighthouseSocial.Application.Features.Lighthouse;

public class UploadPhotoHandler
{
    private readonly IPhotoStorageService _photoStorageService;
    private readonly IPhotoRepository _photoRepository;

    public UploadPhotoHandler(IPhotoStorageService photoStorageService, IPhotoRepository photoRepository)
    {
        _photoStorageService = photoStorageService;
        _photoRepository = photoRepository;
    }

    public async Task<Result<Guid>> HandleAsync(PhotoDto dto, Stream content)
    {
        if (content == null || content.Length == 0)
            return Result<Guid>.Fail("Photo content is required.");

        var savedPath = await _photoStorageService.SaveAsync(content, dto.FileName);

        var metaData = new PhotoMetada(
            "N/A",
            "Unknown",
            dto.CameraModel,
            dto.UploadedAt
            );

        var photo = new Domain.Entities.Photo(dto.LighthouseId, dto.UserId, savedPath, metaData);

        await _photoRepository.AddAsync(photo);
        return Result<Guid>.Ok(photo.Id);
    }
}
