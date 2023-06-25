using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_ClinicasVeterinarias.pt.com.GCV.MODEL
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Default constructor for instanciate
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Id for get by id sql query 
        /// </summary>
        /// <param name="id"></param>
        public User(int id)
        {
            Id = id;
        }

        /// <summary>
        /// login Constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        /// <summary>
        /// full constructor to instance a complete object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="birthDate"></param>
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
