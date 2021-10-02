using Loja.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<DbDataContext>
    {
        public DbDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbDataContext>();
            optionsBuilder.UseSqlServer("Data Source=INSPIRON5458\\SQLEXPRESS;Initial Catalog=BancaVilaFolha;Persist Security Info=True;User ID=sa;Password=123456");

            return new DbDataContext(optionsBuilder.Options);
        }
    }
}
