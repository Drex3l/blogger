using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;

using blogger.Authors;

namespace blogger.Blogs
{
    [Table("AppBlog")]
    public class Blog : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxContentLength = 4096;
        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; protected set; }

        [Required]
        [StringLength(MaxContentLength)]
        public virtual string Content { get; protected set; }
        public virtual DateTime Date { get; protected set; }

        public virtual string Image { get; protected set; }
        public virtual bool IsCancelled { get; protected set; }


        
        public virtual Author Author { get; protected set; }
        public virtual long AuthorId { get; protected set; }
        
        
        public virtual int CategoryId { get; protected set; }
        public virtual Category Category { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Blog()
        {

        }
        public static Blog Create(int tenantId, string title, string content, DateTime date, long authorID, int categoryID, string image = null)
        {
            var @blog = new Blog
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Title = title,
                Content = content,
                CategoryId = categoryID,
                AuthorId = authorID,
                Image = image
            };

            @blog.SetDate(date);
            return @blog;
        }
        internal void Cancel()
        {
            IsCancelled = true;
        }
        private void SetDate(DateTime date)
        {
            if (date < Clock.Now)
            {
                throw new UserFriendlyException("Can not set an blog date in the past!");
            }
            Date = date;
        }
    }
}