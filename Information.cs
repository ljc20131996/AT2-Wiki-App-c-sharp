using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_Wiki_App
{
    public class DataItem : IComparable<DataItem> // Define the class DataItem with the IComparable interface
    {
        private string term; // I declare some private variables
        private string category;
        private string structure;
        private string definition;
        public string Term // I make public properties for each private variable with get:set methods
        {
            get { return term; }
            set { term = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Structure
        {
            get { return structure; }
            set { structure = value; }
        }
        public string Definition
        {
            get { return definition; }
            set { definition = value; }
        }
        public DataItem(string term, string category, string structure, string definition) // Constructor for the DataItem class, takes 4 parameters
        {
            this.term = term;
            this.category = category;
            this.structure = structure;
            this.definition = definition;
        }

        public int CompareTo(DataItem termCompare) // Method to compare two DataItem objects based on their 'term' 
        {
            return Term.CompareTo(termCompare.Term);
        }
    }
}
