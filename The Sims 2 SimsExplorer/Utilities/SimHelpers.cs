using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Sims_2_SimsExplorer.Models;

namespace The_Sims_2_SimsExplorer.Utilities
{
    public class SimHelpers
    {

        public static Sim FindSim(string simId, List<Sim> simList)
        {
            foreach (Sim sim in simList)
            {
                if (sim.SimId == simId)
                    return sim;
            }
            return null;
        }

        public static void InitializeRelatedSims(List<Sim> simList)
        {

            foreach (var sim in simList)
            {
                InitializeRelatedSim(sim, simList);
            }
        }

        public static void InitializeRelatedSim(Sim sim,List<Sim> simList)
        {
            Sim spouse = SimHelpers.FindSim(sim.SpouseId, simList);
            if (spouse != null)
            {
                sim.Spouse = spouse;
                spouse.SpouseReverse = sim;
            }


            Sim parentA = SimHelpers.FindSim(sim.ParentAId, simList);
            if (parentA != null)
            {
                sim.ParentA = parentA;
                parentA.ParentAChildren.Add(sim);
            }


            Sim parentB = SimHelpers.FindSim(sim.ParentBId, simList);
            if (parentB != null)
            {
                sim.ParentB = parentB;
                parentB.ParentBChildren.Add(sim);
            }
        }
    }
}
