using Models;

public interface IFoxesRepository
{
    void Add(Fox f);
    Fox Get(int id);
    IEnumerable<Fox> GetAll();
    void Update(int id, Fox f);
    void UpdateLoveHate(Fox fox); 
}