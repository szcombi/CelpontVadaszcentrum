using System.Collections.Generic;

namespace CelpontVadaszcentrum.Model
{
    public class Category
    {
        public Category()
        {
            Children = new List<Category>();
        }

        public string Name { get; set; }

        public int Id_Category { get; set; }

        public int Id_Parent { get; set; }

        public int Level_Depth { get; set; }

        public List<Category> Children { get; set; }



    }
}