using Models;

public interface IFoxService
{
    void Add(Fox f);
    Fox Get(int id);
    IEnumerable<Fox> GetAll();
    void Update(int id);
    void Love(int id); 
    void Hate(int id);
}