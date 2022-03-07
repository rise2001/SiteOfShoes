using SiteOfShoes.Entities.Ordering.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteOfShoes.Entities.Accounting
{
    public class User
    {
        public User()
        {
        }
        /// <summary>
        /// Получает или задает ИД
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Получает или задает Имя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Получает или задает День рождения пользователя
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Получаеи или задаеи Роль пользователя
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Получает или задаеи Id роли
        /// </summary>
        public int? RoleId { get; set; } = 2;


    }
}
