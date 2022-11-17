using UserStoryAir;
using UserStoryAir.Models;

namespace Nuget
{
        public class NugetLogic
        {
            private List<Reys> reyses = new List<Reys>();

            public NugetLogic() { }

            public List<Reys> GetList()
            {
                return reyses;
            }
            public void Add(Reys arg)
            {
                reyses.Add(arg);
            }
            public void Remove(Reys arg)
            {
                reyses.Remove(arg);
            }
            public void Change(Reys id, Reys arg)
            {
                var index = reyses.IndexOf(id);
                reyses[index] = arg;
            }
        }
    
}