using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Abp.Domain.Entities;
using blogger.Blogs;
namespace blogger.Authors
{
    [Table("AppAuthor")]
    public class Author : Entity<long>, IMustHaveTenant
    {
        public const int MaxNameLength = 20;
        public const int MaxEmailLength = 45;
        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string FirstName { protected set; get;}

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string LastName { protected set; get;}

        [StringLength(MaxEmailLength)]
        public virtual string Email { protected set; get;}

        public virtual bool IsDeactivated { get; protected set; }

        [ForeignKey("AuthorId")]
        public virtual ICollection<Blog> Blogs { get; protected set; }
        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Author()
        {

        }
        public static Author Create(int tenantId, string fname, string lname, string mail){
            var @author = new Author{
                TenantId = tenantId,
                FirstName = fname,
                LastName = lname,
                Email = mail
            };
            @author.Blogs = new Collection<Blog>();
            return @author;
        }
        internal void Deactivate()
        {
            IsDeactivated = true;
        }
    }
}