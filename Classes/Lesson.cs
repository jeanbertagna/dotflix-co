using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotFlix.Classes
{
    public class Lesson : EntityBase
    {
        // Atributtes
        private Category Category { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Excluded { get; set; }

        #region === Methods ===

        // Constructor Methods
        public Lesson(int id, Category category, string title, string description, int year)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        // ToString Override Methods. See: boc-C#-ToString
        public override string ToString()
        {
            string result = "";
            result += "Category: " + this.Category + Environment.NewLine;
            result += "Title: " + this.Title + Environment.NewLine;
            result += "Description: " + this.Description + Environment.NewLine;
            result += "Year: " + this.Year + Environment.NewLine;
            result += "Excluded?: " + this.Excluded + Environment.NewLine;
            return result;
        }

        #region --- Encapsulation Methods --- 
        
        public string resturnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnExcluded()
        {
            return this.Excluded;
        }
        // Marks the register Excluded with True
        public void ToExclude()
        {
            this.Excluded = true;
        }

        #endregion --- Encapsulation Methods ---

        #endregion === Methods ===
    }
}
