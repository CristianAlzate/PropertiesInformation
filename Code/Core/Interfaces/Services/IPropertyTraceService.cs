using Core.DTO.PropertyTrace;


namespace Core.Interfaces.Services
{
    public interface IPropertyTraceService
    {
        Task<CreatePropertyTraceDTO> InsertPropertyTraceAsync(CreatePropertyTraceDTO obj);
    }
}
