using System.Threading.Tasks;

namespace Task1.Interfaces
{
    public interface Itask
    {
        List<Task1> GetAll();
        Task1 Get(int id);
        void add(Task1 task);
        void delet(int id);
        void Update(Task1 task);
        int count {get;}


    }
}