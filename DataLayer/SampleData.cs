using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                context.Directory.Add(new Entities.Directory() { Title="First Directory", HTML= "<b>Directory Content 1</b>" });
                context.Directory.Add(new Entities.Directory() { Title = "Second Directory", HTML = "<b>Directory Content 2</b>" });
                context.SaveChanges();

                context.Material.Add(new Entities.Material() { Title = "First Directory", HTML = "<i>Material Content 1</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Entities.Material() { Title = "Second Directory", HTML = "<i>Material Content 2</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Entities.Material() { Title = "Third Directory", HTML = "<i>Material Content 3</i>", DirectoryId = context.Directory.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
