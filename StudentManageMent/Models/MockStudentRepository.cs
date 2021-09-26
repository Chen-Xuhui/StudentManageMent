﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageMent.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        List<Student> _students;
        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student(){ Id=1,Name="张三",ClassName=ClassNameEnum.FirstGrade,Email="zhangsan@sunell.com" },
                new Student(){ Id=2,Name="李四",ClassName=ClassNameEnum.SecondGrade,Email="lisi@sunell.com" },
                new Student(){ Id=3,Name="王五",ClassName=ClassNameEnum.GradeThree,Email="wangwu@sunell.com" },
            };
        }
        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _students;
        }
    }
}
