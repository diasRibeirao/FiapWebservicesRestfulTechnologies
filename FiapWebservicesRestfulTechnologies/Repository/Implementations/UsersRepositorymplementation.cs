using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiapWebservicesRestfulTechnologies.Repository.Implementations
{
    public class UsersRepositoryImplementation : IUsersRepository
    {
        private MySQLContext _context;

        public UsersRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Users Create(Users user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            } 
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public void Delete(long id)
        {
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Users.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<Users> FindAll()
        {
            return _context.Users.ToList();
        }

        public Users FindById(long id)
        {
            return _context.Users.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Users Update(Users user)
        {
            if (!Exists(user.Id)) return null;
            
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return user;
        }

        public bool Exists(long id)
        {
            return _context.Users.Any(p => p.Id.Equals(id));
        }
    }
}
