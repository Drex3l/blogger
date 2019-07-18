using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using blogger.Authorization;
using blogger.Authorization.Roles;
using blogger.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using blogger.Blogs;

namespace blogger.EntityFrameworkCore.Seed.Host
{
    public class InitialCategory
    {
          private readonly bloggerDbContext _context;

        public InitialCategory(bloggerDbContext context)
        {
            _context = context;
        }
        public void Create(){
            CreateCategories();
        }

        private  void CreateCategories(){
            var categories = _context.Categorie.FirstOrDefault(x => x.Title == "Lifestyle");
            if(categories == null){
                _context.Categorie.Add(new Category{Title = "Lifestyle"});
                _context.Categorie.Add(new Category{Title = "Technology"});
                _context.Categorie.Add(new Category{Title = "Politics"});

                _context.SaveChanges();
            }
        }
    }
}