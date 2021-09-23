using System;
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
                new Student(){ Id=1,Name="张三",ClassName="一年级",Email="zhangsan@sunell.com" },
                new Student(){ Id=2,Name="李四",ClassName="二年级",Email="lisi@sunell.com" },
                new Student(){ Id=3,Name="王五",ClassName="三年纪",Email="wangwu@sunell.com" },
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
