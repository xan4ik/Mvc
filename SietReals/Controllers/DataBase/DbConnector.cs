using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SietReals.Controllers
{
    public class ImageTuple
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string imageName { get; set; }
        public string messaga { get; set; }
        public int ContextType { get; set; }
    }

    public class DbConnector : DbContext
    {
        public DbSet<ImageTuple> Data { get; set; }
        //public DbSet<ImageTuple> HelpSoftwareTuples { get; set; }
        //public DbSet<ImageTuple> TutorialLevelTuples { get; set; }
        //public DbSet<ImageTuple> TutorialDifficultTuples { get; set; }
        //public DbSet<ImageTuple> TutorialRuleTuples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=imageInfo; Trusted_Connection=True");
        }

        public void Init() // тестовые данные
        {
            Data.AddRange(
                    new ImageTuple()
                    {
                        imageName = "ar.jpg",
                        text = "AR",
                        ContextType = 1
                    },
                    new ImageTuple()
                    {
                        imageName = "def.jpg",
                        text = "AR",
                        ContextType = 1
                    }
                );
            Data.AddRange(
                    new ImageTuple()
                    {
                        imageName = "piano.jpg",
                        text = "Software",
                        ContextType = 2
                    },
                    new ImageTuple()
                    {
                        imageName = "def.jpg",
                        text = "Software",
                        ContextType = 2
                    }
                );
            Data.AddRange(
                    new ImageTuple()
                    {
                        imageName = "piano.jpg",
                        text = "Level",
                        ContextType = 3
                    }
                );
            Data.AddRange(
                    new ImageTuple()
                    {
                        imageName = "ar.jpg",
                        text = "Rule",
                        ContextType = 4
                    },
                    new ImageTuple()
                    {
                        imageName = "piano.jpg",
                        text = "Rule",
                        ContextType = 4
                    }
                );
            Data.AddRange(
                    new ImageTuple()
                    {
                        imageName = "ar.jpg",
                        text = "Difficult",
                        ContextType = 5
                    }
                );

            SaveChanges();
        }
    }
}
