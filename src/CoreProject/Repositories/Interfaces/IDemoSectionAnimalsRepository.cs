using CoreProject.Models;

namespace CoreProject.Repositories.Interfaces
{
    public interface IDemoSectionAnimalsRepository
    {
        DemoSectionAnimal[] GetAll();
        DemoSectionAnimal GetById(int id);
    }
}