using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotFlix.Classes;
using DotFlix.Interfaces;

namespace DotFlix
{
    // The classe LessoRepo is implementing a Irepo of Lesson
    public class LessonRepository : IRepository<Lesson>
    {
        // Instance new list of lesson
        private List<Lesson> listLesson = new List<Lesson>();
        // Will receive the object and put him in the position of the Array listLesson
        public void Update(int id, Lesson obj)
        {
            listLesson[id] = obj;
        }
        public void Delete(int id)
        {
            listLesson[id].ToExclude();
        }

        public void Insert(Lesson entity)
        {
            listLesson.Add(entity);
        }
        public List<Lesson> Relation()
        {
            return listLesson;
        }
       
        public int NextId()
        {
            return listLesson.Count;
        }

        public Lesson ReturnById(int id)
        {
            return listLesson[id];
        }

    }
}