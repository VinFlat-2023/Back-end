#region

using Domain.CustomEntities.MomoEntities;

#endregion

namespace Service.IService;

public interface IMoMoService
{
    public Task<MomoResponseEntity> GetMomoResponseEntity(MomoEntity request);
}