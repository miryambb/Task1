using Task1.Models;
using System.Collections.Generic;
using System.Linq;
using Task = Task1.Models.Task;

namespace Task1.Services
{
    public static class Task1Service
    {
        static List<Task> Tasks { get; }
        static int nextId = 3;
        static Task1Service()
        {
            Tasks = new List<Task>
            {
                new Task { Id = 1, firstName = "ayala", IsDone = false },
                new Task { Id = 2, firstName = "myriam", IsDone = true }
            };
        }

        public static List<Task> GetAll() => Tasks;

        public static Task1Service Get(int id) => Tasks.FirstOrDefault()=(p => p.Id == id);

        public static void Add(Task task)
        {
            task.Id = nextId++;
            Tasks.Add(task);
        }

        public static void Delete(int id)
        {
            var task = Get(id);
 
            if (task is null)
                return;

            Tasks.Remove(task);
        }

        public static bool Update(Task task)
        {
            var index = Tasks.FindIndex(p => p.Id == task.Id);
            if (index == -1)
                return false;

            Tasks[index] = task;
            return true;
        }

        public static int Count => Tasks.Count();
    }
}