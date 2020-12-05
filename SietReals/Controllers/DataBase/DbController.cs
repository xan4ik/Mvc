using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SietReals.Controllers
{
    public class DbController : Controller
    {
        public void ChangeContext(string contexName) 
        {
            DbService.Service().ChangeContexTo(contexName);
        }

        public IActionResult GetCurrentImage() 
        {
            var imageTuple = DbService.Service().GetCurrentImage();
            return Json(imageTuple);
        }

        public IActionResult GetNextImage()
        {
            var imageTuple = DbService.Service().GetNextImage();
            return Json(imageTuple);
        }

        public IActionResult GetPrevImage()
        {
            var imageTuple = DbService.Service().GetPrevImage();
            return Json(imageTuple);
        }
    }

    public interface IDbContext
    {
        ImageTuple CurrentImage { get;}
        ImageTuple GetNext();
        ImageTuple GetPrev();
        bool IsContextName(string contextName);
        void Reset();
    }
    public class DbServiceContext : IDbContext
    {
        private ImageTuple[] tuples;  
        private string name;
        private int index;

        public DbServiceContext(string name, IEnumerable<ImageTuple> tuples)
        {
            this.name = name;
            this.tuples = tuples.ToArray();
            this.index = -1;
        }

        public void Reset() 
        {
            index = -1;
        }

        public bool IsContextName(string contextName)
        {
            return name == contextName;
        }
        public ImageTuple CurrentImage 
        {
            get 
            {
                var _index = Math.Clamp(index, 0, tuples.Length - 1);
                return tuples[_index];
            }
        }


        public ImageTuple GetNext() 
        {
            index = Math.Min(index + 1, tuples.Length - 1);
            return tuples[index];
        }
        public ImageTuple GetPrev() 
        {
            index = Math.Max(index - 1, 0);
            return tuples[index];
        }
    }
    public class DbService
    {
        private static DbService instance;
        private IDbContext[] contexts;
        private IDbContext current;
        private DbConnector connector;
        private DbService()
        {
            connector = new DbConnector();
            contexts = new IDbContext[]
            {
                new DbServiceContext("Default", new List<ImageTuple>()
                    { new ImageTuple()
                        {
                            text = "Default",
                            imageName = "def.jpg",
                            ContextType = 0
                        }
                    }),
                new DbServiceContext("AR", connector.Data.Where(tmp => tmp.ContextType == 1)),
                new DbServiceContext("Soft", connector.Data.Where(tmp => tmp.ContextType == 2)),
                new DbServiceContext("Level", connector.Data.Where(tmp => tmp.ContextType == 3)),
                new DbServiceContext("Rules", connector.Data.Where(tmp => tmp.ContextType == 4)),
                new DbServiceContext("Difficult", connector.Data.Where(tmp => tmp.ContextType == 5))
            };
            current = contexts[0];
        }

        static DbService()
        {
            instance = new DbService();
        }

        public void ChangeContexTo(string contexName)
        {
            foreach (var contex in contexts)
            {
                if (contex.IsContextName(contexName))
                {
                    current = contex;
                    contex.Reset();
                    return;
                }
            }
        }

        public ImageTuple GetNextImage()
        {
            return current.GetNext();
        }
        public ImageTuple GetPrevImage()
        {
            return current.GetPrev();
        }

        public ImageTuple GetCurrentImage()
        {
            return current.CurrentImage;
        }

        public static DbService Service()
        {
            return instance;
        }
    }
}
