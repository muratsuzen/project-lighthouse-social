namespace LighthouseSocial.Application.Dtos;

public record class Photo(Guid Id,string FileName,DateTime UploadedAt,string CameraModel,Guid UserId,Guid LighthouseId);
