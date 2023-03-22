using System;

namespace AMS.API
{
    public class GroupTagAttribute : Attribute
    {
        public string Name { get; }

        public GroupTagAttribute(string name)
        {
            Name = name;
        }
    }
}
