using System.Collections.Generic;

namespace WTF.TreeGame.Info
{
    public class AnimalInfoAnalized
    {
        public int id;
        public string name;
        public int picture_id;
        public int number;
        public string location;
        public List<int> species_id;
        public List<int> species_relationship;
        public List<int> black_species_id;
        public List<int> black_species_relationship;

        public AnimalInfoAnalized(AnimalInfo animalInfoInstance)
        {
            id = animalInfoInstance.id;
            name = animalInfoInstance.name;
            picture_id = animalInfoInstance.picture_id;
            number = animalInfoInstance.number;
            location = animalInfoInstance.location;
        }
    }
}