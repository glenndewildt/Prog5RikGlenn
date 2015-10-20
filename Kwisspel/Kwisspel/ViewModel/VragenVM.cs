using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
    class VragenVM
    {
        private Model.Vraag vraag;
        public int Id {
            get {
                return vraag.Id;
            }
            set {
                vraag.Id = value;
            }
        }

        public string Vraag
        {
            get
            {
                return vraag.StringVraag;
            }
            set
            {
                vraag.StringVraag = value;
            }
        }

        public string Soort
        {
            get
            {
                return vraag.Soort;
            }
            set
            {
                vraag.Soort = value;
            }
        }

         public VragenVM(Model.Vraag dier)
        {
            // TODO: Complete member initialization
            this.vraag = vraag;
        }

        public VragenVM()
        {
            vraag = new Model.Vraag();
        }

        public Model.Vraag ToPOCO()
        {
            return vraag;
        }

    }
}
