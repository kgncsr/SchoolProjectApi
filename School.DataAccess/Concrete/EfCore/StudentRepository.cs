using Microsoft.EntityFrameworkCore;
using School.DataAccess.Abstract;
using School.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Concrete.EfCore
{
    public class StudentRepository : IStudentDal
    {

        public async Task<Student> Create(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();
                return student;
            }
        }

        public async Task Delete(int id)
        {
            using (var context = new SchoolContext())
            {
                var result = await context.Students.FindAsync(id);
                context.Students.Remove(result); 
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAll()
        {
            using (var context = new SchoolContext())
            {
                return await context.Students.ToListAsync();
            }
        }

        public async Task<Student> GetById(int id)
        {
            using (var context = new SchoolContext())
            {
                var result = await context.Students.FindAsync(id);
                return result;
            }
        }

        public async Task<Student> GetByName(string name)
        {
            using (var context = new SchoolContext())
            {
                return await context.Students.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<Student> Update(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Update(student);
                await context.SaveChangesAsync();
                return student;
            }
        }
    }
}
