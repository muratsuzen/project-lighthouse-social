namespace LighthouseSocial.Application.Dtos;

public record class PhotoDto(Guid Id,string FileName,DateTime UploadedAt,string CameraModel,Guid UserId,Guid LighthouseId);
