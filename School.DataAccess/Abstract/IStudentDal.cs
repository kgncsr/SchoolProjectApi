using School.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Abstract
{
    public interface IStudentDal
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> GetByName(string name);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task Delete(int id);
    }
}
