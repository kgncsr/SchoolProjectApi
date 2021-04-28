using School.Business.Abstract;
using School.DataAccess.Abstract;
using School.DataAccess.Concrete.EfCore;
using School.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal; /*new StudentRepository()*/
        }
        public async Task<Student> Create(Student student)
        {
           return await _studentDal.Create(student);
        }

        public async Task Delete(int id)
        {
            await _studentDal.Delete(id);
        }

        public async Task<List<Student>> GetAllHotel()
        {
            return await _studentDal.GetAll();
        }

        public async Task<Student> GetById(int id)
        {
            return await _studentDal.GetById(id);
        }

        public async Task<Student> GetByName(string name)
        {
            return await _studentDal.GetByName(name);
        }

        public async Task<Student> Update(Student student)
        {
            return await _studentDal.Update(student);
        }
    }
}
