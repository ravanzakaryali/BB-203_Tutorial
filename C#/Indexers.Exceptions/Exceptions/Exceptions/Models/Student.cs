﻿namespace Exceptions.Models
{
    internal class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
