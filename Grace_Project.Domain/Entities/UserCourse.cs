﻿namespace Grace_Project.Domain.Entities
{
    public class UserCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set;}
        public User User { get; set;}
    }
}
