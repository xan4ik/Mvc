using SietReals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SietReals.Models
{
    public class DefaultLoadModel
    {
        private ImageTuple tuple;

        public DefaultLoadModel(ImageTuple tuple)
        {
            this.tuple = tuple;
        }

        public string Header => tuple.text;
        public string ImageName => tuple.imageName;
        public string Messaga => tuple.messaga;
    }
}
