using FutureTechAcademy.Models;

namespace FutureTechAcademy.Services
{
    public interface ICosmosService
    {
        Task<List<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
        Task<Student> GetStudentByIdAsync(string id);
    }
}
