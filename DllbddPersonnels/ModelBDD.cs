using BddpersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllbddPersonnels
{
    public class ModelBDD
    {
        private BddpersonnelDataContext bdd;

        public ModelBDD(String user, String mdp, String serveurIP, String port)
        {
            bdd = new BddpersonnelDataContext("User Id=" + user + ";Password=" + mdp + ";Host=" + serveurIP + ";Port=" + port + ";Database=bddpersonnels;Persist Security Info=True");
        }
        public List<Personnel> GetAllPersonnel()
        {
            try
            {
                return bdd.Personnels.ToList();
            }
            catch { throw; }
        }
        public List<Fonction> GetAllFonctions()
        {
            try
            {
                return bdd.Fonctions.ToList();
            }
            catch { throw; }
        }
        public List<Service> GetAllServices()
        {
            try
            {
                return bdd.Services.ToList();
            }
            catch { throw; }
        }
    }
}
